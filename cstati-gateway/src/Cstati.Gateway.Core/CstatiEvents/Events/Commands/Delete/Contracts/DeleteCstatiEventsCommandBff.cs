namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsCommandBff
{
    public required string EventId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
