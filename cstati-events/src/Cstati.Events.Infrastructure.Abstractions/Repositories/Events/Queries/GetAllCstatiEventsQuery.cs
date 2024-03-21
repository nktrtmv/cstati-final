using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;

namespace Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;

public sealed class GetAllCstatiEventsQuery
{
    public GetAllCstatiEventsQuery(string? query, CstatiEventStatus[] statusesFilter, int limit)
    {
        Query = query;
        StatusesFilter = statusesFilter;
        Limit = limit;
    }

    public string? Query { get; }
    public CstatiEventStatus[] StatusesFilter { get; }
    public int Limit { get; }
}
