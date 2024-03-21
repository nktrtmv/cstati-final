using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsWavesCommandInternal : CstatiEventsWorkflowsWavesCommandInternal
{
    public DeleteCstatiEventsWorkflowsWavesCommandInternal(string eventId, int ordinal, ConcurrencyToken concurrencyToken) : base(eventId, concurrencyToken)
    {
        Ordinal = ordinal;
    }

    internal int Ordinal { get; }
}
