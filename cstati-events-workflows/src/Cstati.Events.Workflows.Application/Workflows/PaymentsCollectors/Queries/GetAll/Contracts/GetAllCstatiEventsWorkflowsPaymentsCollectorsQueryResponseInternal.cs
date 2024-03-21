using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal
{
    internal GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal[] paymentCollectors,
        ConcurrencyToken concurrencyToken)
    {
        PaymentCollectors = paymentCollectors;
        ConcurrencyToken = concurrencyToken;
    }

    public GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal[] PaymentCollectors { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
