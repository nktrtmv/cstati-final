using Cstati.Events.Workflows.Application.Services.Processors.ApplicationEvents;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

namespace Cstati.Events.Workflows.Application.Services;

internal sealed class CstatiEventsWorkflowsFacade
{
    public CstatiEventsWorkflowsFacade(ICstatiEventsWorkflowsRepository workflows, IEnumerable<IApplicationEventProcessor> processors)
    {
        Workflows = workflows;
        Processors = processors;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }
    private IEnumerable<IApplicationEventProcessor> Processors { get; }

    internal async Task Update(CstatiEventWorkflow workflow, CstatiEventWorkflowUpdatingContext context, CancellationToken cancellationToken)
    {
        CstatiEventWorkflowUpdater.Update(workflow, context);

        await Workflows.Upsert(workflow, cancellationToken);

        await ProcessApplicationEvents(context.ApplicationEvents, cancellationToken);
    }

    internal Task<CstatiEventWorkflow> GetRequired(string eventId, CancellationToken cancellationToken)
    {
        return Workflows.GetRequired(eventId, cancellationToken);
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
