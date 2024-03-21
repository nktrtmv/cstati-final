using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsQueryInternalConverter
{
    internal static GetAllCstatiEventsQuery ToDomain(GetAllCstatiEventsQueryInternal query)
    {
        CstatiEventStatus[] statusesFilter =
            query.StatusesFilter.Select(CstatiEventStatusInternalConverter.ToDomain).ToArray();

        var result = new GetAllCstatiEventsQuery(query.Query, statusesFilter, query.Limit);

        return result;
    }
}
