namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;

public sealed class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required string Message { get; init; }
    public required DateTime Deadline { get; init; }
    public required string ConcurrencyToken { get; init; }
}
