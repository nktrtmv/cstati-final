using Cstati.Gateway.Core.Common.Persons;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;

public sealed class GetAllCstatiEventsTasksQueryResponseTaskBff
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public required PersonBff Executor { get; init; }
    public required string Description { get; init; }
    public required DateTime Deadline { get; init; }
    public required CstatiEventTaskStatusBff Status { get; init; }
}
