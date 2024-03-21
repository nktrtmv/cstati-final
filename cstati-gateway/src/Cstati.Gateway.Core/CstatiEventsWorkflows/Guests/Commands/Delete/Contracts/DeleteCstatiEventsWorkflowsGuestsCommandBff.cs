namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required string GuestId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
