using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts.Waves;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsWavesQueryResponseInternal
{
    internal GetAllCstatiEventsWorkflowsWavesQueryResponseInternal(GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal[] waves, ConcurrencyToken concurrencyToken)
    {
        Waves = waves;
        ConcurrencyToken = concurrencyToken;
    }

    public GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal[] Waves { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
