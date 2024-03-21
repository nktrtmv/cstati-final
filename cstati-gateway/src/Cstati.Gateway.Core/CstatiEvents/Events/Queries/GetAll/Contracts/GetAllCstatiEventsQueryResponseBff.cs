using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsQueryResponseBff
{
    public required GetAllCstatiEventsQueryResponseEventBff[] Events { get; init; }
}
