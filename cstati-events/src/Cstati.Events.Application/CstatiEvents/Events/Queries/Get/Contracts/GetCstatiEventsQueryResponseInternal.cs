using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts.Events;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;

public sealed class GetCstatiEventsQueryResponseInternal
{
    internal GetCstatiEventsQueryResponseInternal(GetCstatiEventsQueryResponseEventInternal @event)
    {
        Event = @event;
    }

    public GetCstatiEventsQueryResponseEventInternal Event { get; }
}
