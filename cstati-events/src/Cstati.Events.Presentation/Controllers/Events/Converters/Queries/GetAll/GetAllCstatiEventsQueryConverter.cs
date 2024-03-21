using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Contracts.Statuses;

namespace Cstati.Events.Presentation.Controllers.Events.Converters.Queries.GetAll;

internal static class GetAllCstatiEventsQueryConverter
{
    internal static GetAllCstatiEventsQueryInternal ToInternal(GetAllCstatiEventsQuery query)
    {
        CstatiEventStatusInternal[] statusesFilter = query.StatusesFilter.Select(CstatiEventStatusDtoConverter.ToInternal).ToArray();

        var result = new GetAllCstatiEventsQueryInternal(query.Query, statusesFilter, query.Limit);

        return result;
    }
}
