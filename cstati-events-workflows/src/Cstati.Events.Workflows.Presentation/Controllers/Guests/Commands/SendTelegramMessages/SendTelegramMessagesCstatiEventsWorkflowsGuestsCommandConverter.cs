using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendTelegramMessages.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.SendTelegramMessages;

internal static class SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandConverter
{
    internal static SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal ToInternal(SendTelegramMessagesCstatiEventsWorkflowsGuestsCommand command)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal[] recipientPaymentStatuses =
            command.RecipientsPaymentStatuses.Select(CstatiEventWorkflowGuestPaymentStatusDtoConverter.ToInternal).ToArray();

        var result = new SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal(command.EventId, recipientPaymentStatuses, command.Message);

        return result;
    }
}
