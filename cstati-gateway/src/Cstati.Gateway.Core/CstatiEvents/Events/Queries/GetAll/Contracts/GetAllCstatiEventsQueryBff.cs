using Cstati.Gateway.Core.CstatiEvents.Events.Contracts.Events.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsQueryBff
{
    public string? Query { get; init; }
    public required CstatiEventStatusBff[] StatusesFilter { get; init; }
}
