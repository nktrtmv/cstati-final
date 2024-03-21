using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsTasksQueryBffConverter
{
    internal static GetAllCstatiEventsTasksQuery ToDto(GetAllCstatiEventsTasksQueryBff query, int limit)
    {
        CstatiEventTaskStatusDto[] statuses = query.StatusesFilter.Select(CstatiEventTaskStatusBffConverter.ToDto).ToArray();

        var result = new GetAllCstatiEventsTasksQuery
        {
            EventId = query.EventId,
            StatusesFilter = { statuses },
            Limit = limit
        };

        return result;
    }
}
