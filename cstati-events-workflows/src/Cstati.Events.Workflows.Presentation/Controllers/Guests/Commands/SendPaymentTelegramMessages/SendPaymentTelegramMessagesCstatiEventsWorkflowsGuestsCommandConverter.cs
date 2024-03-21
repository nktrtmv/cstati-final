using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.SendPaymentTelegramMessages;

internal static class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandConverter
{
    internal static SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal ToInternal(
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommand command)
    {
        UtcDateTime deadline = UtcDateTimeConverterFrom.FromTimestamp(command.Deadline);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal(command.EventId, command.Message, deadline, concurrencyToken);

        return result;
    }
}
