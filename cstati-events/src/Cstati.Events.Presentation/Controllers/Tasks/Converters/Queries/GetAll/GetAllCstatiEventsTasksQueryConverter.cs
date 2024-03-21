using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Contracts.Statuses;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Queries.GetAll;

internal static class GetAllCstatiEventsTasksQueryConverter
{
    internal static GetAllCstatiEventsTasksQueryInternal ToInternal(GetAllCstatiEventsTasksQuery query)
    {
        CstatiEventTaskStatusInternal[] statusesFilter =
            query.StatusesFilter.Select(CstatiEventTaskStatusDtoConverter.ToInternal).ToArray();

        var result = new GetAllCstatiEventsTasksQueryInternal(query.EventId, statusesFilter, query.Limit);

        return result;
    }
}
