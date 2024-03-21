using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts;

public sealed class AddCstatiEventsWorkflowsGuestsCommandInternal : IRequest
{
    public AddCstatiEventsWorkflowsGuestsCommandInternal(string eventId, AddCstatiEventsWorkflowsGuestsCommandGuestInternal[] guests, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        Guests = guests;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal AddCstatiEventsWorkflowsGuestsCommandGuestInternal[] Guests { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
