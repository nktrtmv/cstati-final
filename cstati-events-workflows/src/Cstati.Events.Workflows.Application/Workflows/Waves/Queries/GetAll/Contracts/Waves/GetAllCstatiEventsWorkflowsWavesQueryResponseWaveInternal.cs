using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts.Waves;

public sealed class GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal
{
    internal GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal(int ordinal, UtcDateTime? startedAt, UtcDateTime? completedAt)
    {
        Ordinal = ordinal;
        StartedAt = startedAt;
        CompletedAt = completedAt;
    }

    public int Ordinal { get; }
    public UtcDateTime? StartedAt { get; private set; }
    public UtcDateTime? CompletedAt { get; private set; }
}
