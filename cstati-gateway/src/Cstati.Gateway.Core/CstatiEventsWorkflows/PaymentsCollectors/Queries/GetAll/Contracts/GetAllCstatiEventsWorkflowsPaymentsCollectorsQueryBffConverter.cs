using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryBffConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQuery ToDto(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryBff query)
    {
        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQuery
        {
            EventId = query.EventId
        };

        return result;
    }
}
