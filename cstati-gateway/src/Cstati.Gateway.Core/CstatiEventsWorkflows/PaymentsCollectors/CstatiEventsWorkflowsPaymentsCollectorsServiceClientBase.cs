using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors;

public abstract class CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase
{
    protected CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase(
        CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient paymentsCollectors)
    {
        PaymentsCollectors = paymentsCollectors;
    }

    protected CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient PaymentsCollectors { get; }
}
