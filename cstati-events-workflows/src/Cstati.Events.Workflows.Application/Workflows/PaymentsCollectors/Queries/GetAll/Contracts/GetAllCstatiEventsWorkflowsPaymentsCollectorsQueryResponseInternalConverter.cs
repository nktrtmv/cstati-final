using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal FromDomain(
        CstatiEventWorkflowPaymentCollector[] paymentCollectors,
        IReadOnlyDictionary<string, CstatiEventWorkflowGuest> guests,
        ConcurrencyToken concurrencyToken)
    {
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal[] paymentCollectorsInternal =
            paymentCollectors.Select(c => GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternalConverter.FromDomain(c, guests)).ToArray();

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal(paymentCollectorsInternal, concurrencyToken);

        return result;
    }
}
