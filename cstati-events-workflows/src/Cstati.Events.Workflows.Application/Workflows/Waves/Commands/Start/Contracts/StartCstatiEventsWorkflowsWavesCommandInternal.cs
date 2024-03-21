using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Start.Contracts;

public sealed class StartCstatiEventsWorkflowsWavesCommandInternal : CstatiEventsWorkflowsWavesCommandInternal
{
    public StartCstatiEventsWorkflowsWavesCommandInternal(string eventId, int ordinal, ConcurrencyToken concurrencyToken) : base(eventId, concurrencyToken)
    {
        Ordinal = ordinal;
    }

    internal int Ordinal { get; }
}
