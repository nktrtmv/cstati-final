using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

namespace Cstati.Events.Application.Services.Processors.ApplicationEvents;

internal abstract class ApplicationEventProcessor<T> : IApplicationEventProcessor where T : ApplicationEvent
{
    private readonly ICstatiEventsRepository _eventsRepository;

    protected ApplicationEventProcessor(ICstatiEventsRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    public Type Type => typeof(T);

    public async Task Process(string eventId, Guid applicationEventId, CancellationToken cancellationToken)
    {
        CstatiEvent cstatiEvent = await _eventsRepository.GetRequired(eventId, cancellationToken);

        ApplicationEvent? baseApplicationEvent = cstatiEvent.ApplicationEvents.Single(e => e.Id == applicationEventId);

        if (baseApplicationEvent is null)
        {
            throw new ApplicationException(
                $"Cannot process application event (id: {applicationEventId}." +
                $"Reason: Application event is not found.");
        }

        if (baseApplicationEvent is not T applicationEvent)
        {
            throw new ApplicationException(
                $"Cannot process application event (id: {applicationEventId}." +
                $"Reason: Application event type is not equal to processor type.");
        }

        await Process(cstatiEvent, applicationEvent, cancellationToken);

        applicationEvent.Complete();

        await _eventsRepository.Upsert(cstatiEvent, cancellationToken);
    }

    protected abstract Task Process(CstatiEvent cstatiEvent, T applicationEvent, CancellationToken cancellationToken);
}
