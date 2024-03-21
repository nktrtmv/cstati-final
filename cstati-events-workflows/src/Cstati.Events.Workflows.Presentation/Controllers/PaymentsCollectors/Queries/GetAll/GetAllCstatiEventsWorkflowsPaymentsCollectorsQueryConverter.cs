using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal ToInternal(GetAllCstatiEventsWorkflowsPaymentsCollectorsQuery query)
    {
        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal(query.EventId);

        return result;
    }
}
