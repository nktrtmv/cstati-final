using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsTasksQueryBff
{
    public required string EventId { get; init; }
    public required CstatiEventTaskStatusBff[] StatusesFilter { get; init; }
}
