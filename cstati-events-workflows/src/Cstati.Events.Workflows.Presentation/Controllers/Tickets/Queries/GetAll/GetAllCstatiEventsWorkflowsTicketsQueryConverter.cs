using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryInternal ToInternal(GetAllCstatiEventsWorkflowsTicketsQuery query)
    {
        var result = new GetAllCstatiEventsWorkflowsTicketsQueryInternal(query.EventId, query.WaveOrdinal);

        return result;
    }
}
