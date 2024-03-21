using Cstati.Events.Workflows.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;

internal static class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommand ToDto(SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff command)
    {
        Timestamp? deadline = Timestamp.FromDateTime(command.Deadline);

        var result = new SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            Message = command.Message,
            Deadline = deadline,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
