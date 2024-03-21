using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryBffConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQuery ToDto(GetAllCstatiEventsWorkflowsGuestsQueryBff query)
    {
        var result = new GetAllCstatiEventsWorkflowsGuestsQuery
        {
            EventId = query.EventId,
            WaveOrdinal = query.WaveOrdinal
        };

        return result;
    }
}
