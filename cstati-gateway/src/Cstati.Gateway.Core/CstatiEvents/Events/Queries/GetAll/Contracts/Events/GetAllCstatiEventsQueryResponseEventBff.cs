using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts.Events;

public sealed class GetAllCstatiEventsQueryResponseEventBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required CstatiEventStatusBff Status { get; init; }
}
