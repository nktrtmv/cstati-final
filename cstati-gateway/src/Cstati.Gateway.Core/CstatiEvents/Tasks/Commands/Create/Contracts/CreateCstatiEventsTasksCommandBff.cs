namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create.Contracts;

public sealed class
    CreateCstatiEventsTasksCommandBff
{
    public required string EventId { get; init; }
    public required string Name { get; init; }
    public required string ExecutorLogin { get; init; }
    public required string Description { get; init; }
    public required DateTime Deadline { get; init; }
    public required string ConcurrencyToken { get; init; }
}
