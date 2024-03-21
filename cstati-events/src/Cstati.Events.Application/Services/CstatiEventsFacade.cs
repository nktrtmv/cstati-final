using Cstati.Events.Application.Services.Processors.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.ValueObjects.ApplicationEvents;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

namespace Cstati.Events.Application.Services;

internal sealed class CstatiEventsFacade
{
    public CstatiEventsFacade(ICstatiEventsRepository events, IEnumerable<IApplicationEventProcessor> processors)
    {
        Events = events;
        Processors = processors;
    }

    private ICstatiEventsRepository Events { get; }
    private IEnumerable<IApplicationEventProcessor> Processors { get; }

    internal async Task Update(CstatiEvent @event, CstatiEventUpdatingContext updatingContext, CancellationToken cancellationToken)
    {
        CstatiEventApplicationEvent[] applicationEvents = CstatiEventUpdater.Update(@event, updatingContext);

        await Events.Upsert(@event, cancellationToken);

        await ProcessApplicationEvents(applicationEvents, cancellationToken);
    }

    internal Task<CstatiEvent> GetRequired(string eventId, CancellationToken cancellationToken)
    {
        return Events.GetRequired(eventId, cancellationToken);
    }

    private async Task ProcessApplicationEvents<TApplicationEvent>(IEnumerable<TApplicationEvent> applicationEvents, CancellationToken cancellationToken)
    {
        foreach (TApplicationEvent applicationEvent in applicationEvents)
        {
            foreach (IApplicationEventProcessor processor in Processors)
            {
                await processor.Process(applicationEvent, cancellationToken);
            }
        }
    }
}
