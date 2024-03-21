using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsGuestsCommandInternal : IRequest
{
    public DeleteCstatiEventsWorkflowsGuestsCommandInternal(string eventId, string guestId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        GuestId = guestId;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string GuestId { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
