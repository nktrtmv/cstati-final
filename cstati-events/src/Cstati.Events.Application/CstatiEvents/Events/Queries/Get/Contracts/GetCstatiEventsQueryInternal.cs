using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;

public sealed class GetCstatiEventsQueryInternal : IRequest<GetCstatiEventsQueryResponseInternal>
{
    public GetCstatiEventsQueryInternal(string eventId)
    {
        EventId = eventId;
    }

    internal string EventId { get; }
}
