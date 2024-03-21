using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsQueryResponseInternal
{
    internal GetAllCstatiEventsQueryResponseInternal(GetAllCstatiEventsQueryResponseEventInternal[] events)
    {
        Events = events;
    }

    public GetAllCstatiEventsQueryResponseEventInternal[] Events { get; }
}
