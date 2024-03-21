using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsTasksCommandBff
{
    public required string EventId { get; init; }
    public required string TaskId { get; init; }
    public required string Name { get; init; }
    public required string ExecutorLogin { get; init; }
    public required string Description { get; init; }
    public required DateTime? Deadline { get; init; }
    public required CstatiEventTaskStatusBff Status { get; init; }
    public required string ConcurrencyToken { get; init; }
}
