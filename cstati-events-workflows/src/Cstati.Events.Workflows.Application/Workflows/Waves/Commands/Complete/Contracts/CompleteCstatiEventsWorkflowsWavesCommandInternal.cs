using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Complete.Contracts;

public sealed class CompleteCstatiEventsWorkflowsWavesCommandInternal : CstatiEventsWorkflowsWavesCommandInternal
{
    public CompleteCstatiEventsWorkflowsWavesCommandInternal(string eventId, int ordinal, ConcurrencyToken concurrencyToken) : base(eventId, concurrencyToken)
    {
        Ordinal = ordinal;
    }

    internal int Ordinal { get; }
}
