using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands;

public abstract class CstatiEventsWorkflowsWavesCommandInternal : IRequest
{
    protected CstatiEventsWorkflowsWavesCommandInternal(string eventId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        ConcurrencyToken = concurrencyToken;
    }

    public string EventId { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
