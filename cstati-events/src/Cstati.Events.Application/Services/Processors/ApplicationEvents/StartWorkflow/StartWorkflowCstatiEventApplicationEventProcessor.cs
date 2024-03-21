using Cstati.Events.Domain.ValueObjects.ApplicationEvents.StartWorkflow;
using Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;

namespace Cstati.Events.Application.Services.Processors.ApplicationEvents.StartWorkflow;

internal sealed class StartWorkflowCstatiEventApplicationEventProcessor : IApplicationEventProcessor
{
    public StartWorkflowCstatiEventApplicationEventProcessor(ICstatiEventsWorkflowsEventsSender workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsEventsSender Workflows { get; }

    public async Task Process<TApplicationEvent>(TApplicationEvent applicationEvent, CancellationToken cancellationToken)
    {
        if (applicationEvent is not StartWorkflowCstatiEventApplicationEvent startWorkflow)
        {
            return;
        }

        await Workflows.SendStartRequest(startWorkflow.EventId, startWorkflow.EventName, cancellationToken);
    }
}
