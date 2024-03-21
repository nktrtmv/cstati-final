using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff
{
    public required GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBff[] PaymentsCollectors { get; init; }
    public required string ConcurrencyToken { get; init; }
}
