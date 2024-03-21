using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryInternal ToInternal(GetAllCstatiEventsWorkflowsGuestsQuery query)
    {
        var result = new GetAllCstatiEventsWorkflowsGuestsQueryInternal(query.EventId, query.WaveOrdinal);

        return result;
    }
}
