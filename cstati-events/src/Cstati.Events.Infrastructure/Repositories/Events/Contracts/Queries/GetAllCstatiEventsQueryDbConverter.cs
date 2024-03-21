using Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Statuses;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Queries;

internal static class GetAllCstatiEventsQueryDbConverter
{
    internal static GetAllCstatiEventsQueryDb FromDomain(GetAllCstatiEventsQuery query)
    {
        string[] statusesFilter = query.StatusesFilter.Select(CstatiEventStatusDbConverter.ToString).ToArray();

        var result = new GetAllCstatiEventsQueryDb
        {
            Query = query.Query,
            StatusesFilter = statusesFilter,
            Limit = query.Limit
        };

        return result;
    }
}
