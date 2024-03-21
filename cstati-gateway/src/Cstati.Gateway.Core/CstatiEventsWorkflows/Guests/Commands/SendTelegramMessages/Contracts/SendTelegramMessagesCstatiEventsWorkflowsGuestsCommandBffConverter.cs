using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages.Contracts;

internal static class SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static SendTelegramMessagesCstatiEventsWorkflowsGuestsCommand ToDto(SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff command)
    {
        CstatiEventWorkflowGuestPaymentStatusDto[] recipientsPaymentStatuses =
            command.RecipientsPaymentStatuses.Select(CstatiEventWorkflowGuestPaymentStatusBffConverter.ToDto).ToArray();

        var result = new SendTelegramMessagesCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            RecipientsPaymentStatuses = { recipientsPaymentStatuses },
            Message = command.Message
        };

        return result;
    }
}
