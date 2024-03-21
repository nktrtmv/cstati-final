using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsQueryBffConverter
{
    internal static GetAllCstatiEventsQuery ToDto(GetAllCstatiEventsQueryBff query, int limit)
    {
        CstatiEventStatusDto[] statusesFilter = query.StatusesFilter.Select(CstatiEventStatusBffConverter.ToDto).ToArray();

        var result = new GetAllCstatiEventsQuery
        {
            Query = query.Query,
            StatusesFilter = { statusesFilter },
            Limit = limit
        };

        return result;
    }
}
