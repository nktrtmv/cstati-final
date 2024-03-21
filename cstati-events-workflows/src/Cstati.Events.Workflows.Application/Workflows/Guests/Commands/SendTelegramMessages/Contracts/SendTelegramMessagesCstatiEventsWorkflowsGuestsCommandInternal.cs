using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendTelegramMessages.Contracts;

public sealed class SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal : IRequest
{
    public SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal(
        string eventId,
        CstatiEventWorkflowGuestPaymentStatusInternal[] recipientsPaymentStatuses,
        string message)
    {
        EventId = eventId;
        RecipientsPaymentStatuses = recipientsPaymentStatuses;
        Message = message;
    }

    internal string EventId { get; }
    internal CstatiEventWorkflowGuestPaymentStatusInternal[] RecipientsPaymentStatuses { get; }
    internal string Message { get; }
}
