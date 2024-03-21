using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts.Events;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts;

public sealed class GetCstatiEventsQueryResponseBff
{
    public required GetCstatiEventsQueryResponseEventBff Event { get; init; }
}
