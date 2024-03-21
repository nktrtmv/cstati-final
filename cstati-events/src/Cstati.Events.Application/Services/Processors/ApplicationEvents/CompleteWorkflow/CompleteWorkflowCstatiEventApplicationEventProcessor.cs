using Cstati.Events.Domain.ValueObjects.ApplicationEvents.CompleteWorkflow;
using Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;

namespace Cstati.Events.Application.Services.Processors.ApplicationEvents.CompleteWorkflow;

internal sealed class CompleteWorkflowCstatiEventApplicationEventProcessor : IApplicationEventProcessor
{
    public CompleteWorkflowCstatiEventApplicationEventProcessor(ICstatiEventsWorkflowsEventsSender workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsEventsSender Workflows { get; }

    public async Task Process<TApplicationEvent>(TApplicationEvent applicationEvent, CancellationToken cancellationToken)
    {
        if (applicationEvent is not CompleteWorkflowCstatiEventApplicationEvent completeWorkflow)
        {
            return;
        }

        await Workflows.SendCompleteRequest(completeWorkflow.EventId, cancellationToken);
    }
}
