using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsCommandInternal : IRequest
{
    public DeleteCstatiEventsCommandInternal(string eventId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
