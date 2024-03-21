namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsTasksCommandBff
{
    public required string EventId { get; init; }
    public required string TaskId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
