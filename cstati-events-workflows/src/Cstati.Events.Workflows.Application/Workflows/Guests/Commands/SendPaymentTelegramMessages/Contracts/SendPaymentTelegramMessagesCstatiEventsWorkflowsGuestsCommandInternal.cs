using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;

public sealed class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal : IRequest
{
    public SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal(string eventId, string message, UtcDateTime deadline, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        Message = message;
        Deadline = deadline;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string Message { get; }
    internal UtcDateTime Deadline { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
