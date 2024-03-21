using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsTasksQueryInternal : IRequest<GetAllCstatiEventsTasksQueryResponseInternal>
{
    public GetAllCstatiEventsTasksQueryInternal(string eventId, CstatiEventTaskStatusInternal[] statusesFilter, int limit)
    {
        EventId = eventId;
        StatusesFilter = statusesFilter;
        Limit = limit;
    }

    internal string EventId { get; }
    internal CstatiEventTaskStatusInternal[] StatusesFilter { get; }
    internal int Limit { get; }
}
