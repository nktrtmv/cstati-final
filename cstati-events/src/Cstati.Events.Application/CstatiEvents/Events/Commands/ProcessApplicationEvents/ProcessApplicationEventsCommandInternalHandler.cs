using Cstati.Events.Application.CstatiEvents.Events.Commands.ProcessApplicationEvents.Contracts;
using Cstati.Events.Application.Services.Processors.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.ProcessApplicationEvents;

[UsedImplicitly]
internal sealed class ProcessApplicationEventsCommandInternalHandler : IRequestHandler<ProcessApplicationEventsCommandInternal>
{
    private readonly IEnumerable<IApplicationEventProcessor> _applicationEventsProcessors;
    private readonly ICstatiEventsRepository _eventsRepository;

    public ProcessApplicationEventsCommandInternalHandler(IEnumerable<IApplicationEventProcessor> applicationEventsProcessors, ICstatiEventsRepository eventsRepository)
    {
        _applicationEventsProcessors = applicationEventsProcessors;
        _eventsRepository = eventsRepository;
    }

    public async Task Handle(ProcessApplicationEventsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent cstatiEvent = await _eventsRepository.GetRequired(request.EventId, cancellationToken);

        foreach (ApplicationEvent applicationEvent in cstatiEvent.ApplicationEvents.Where(e => e.Status == ApplicationEventStatus.InProcess))
        {
            IApplicationEventProcessor processor = _applicationEventsProcessors.Single(p => p.Type == applicationEvent.GetType());

            await processor.Process(request.EventId, applicationEvent.Id, cancellationToken);
        }
    }
}
