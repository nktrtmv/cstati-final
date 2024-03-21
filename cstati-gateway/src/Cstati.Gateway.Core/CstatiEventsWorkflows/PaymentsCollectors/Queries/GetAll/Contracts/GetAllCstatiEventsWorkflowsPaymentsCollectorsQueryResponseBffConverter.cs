using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBffConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff FromDto(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse response,
        EnrichersContext enrichers)
    {
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBff[] paymentCollectors = response.PaymentCollectors
            .Select(c => GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBffConverter.FromDto(c, enrichers))
            .ToArray();

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff
        {
            PaymentsCollectors = paymentCollectors,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
