using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages.Contracts;

public sealed class SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required CstatiEventWorkflowGuestPaymentStatusBff[] RecipientsPaymentStatuses { get; init; }
    public required string Message { get; init; }
}
