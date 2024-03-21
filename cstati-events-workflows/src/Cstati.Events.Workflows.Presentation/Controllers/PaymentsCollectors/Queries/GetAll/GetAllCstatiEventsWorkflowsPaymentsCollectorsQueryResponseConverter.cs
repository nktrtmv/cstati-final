using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll.PaymentsCollectors;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse FromInternal(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal response)
    {
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollector[] paymentCollectors =
            response.PaymentCollectors.Select(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse
        {
            PaymentCollectors = { paymentCollectors },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
