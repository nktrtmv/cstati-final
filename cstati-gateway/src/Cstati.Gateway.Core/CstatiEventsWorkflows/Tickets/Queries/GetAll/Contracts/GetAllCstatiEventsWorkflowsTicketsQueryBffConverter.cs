using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryBffConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQuery ToDto(GetAllCstatiEventsWorkflowsTicketsQueryBff query)
    {
        var result = new GetAllCstatiEventsWorkflowsTicketsQuery
        {
            EventId = query.EventId,
            WaveOrdinal = query.WaveOrdinal
        };

        return result;
    }
}
