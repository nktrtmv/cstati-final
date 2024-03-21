using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsQueryInternal : IRequest<GetAllCstatiEventsQueryResponseInternal>
{
    public GetAllCstatiEventsQueryInternal(string? query, CstatiEventStatusInternal[] statusesFilter, int limit)
    {
        Query = query;
        StatusesFilter = statusesFilter;
        Limit = limit;
    }

    internal string? Query { get; }
    internal CstatiEventStatusInternal[] StatusesFilter { get; }
    internal int Limit { get; }
}
