using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts.Waves;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal FromDomain(CstatiEventWorkflowWave wave)
    {
        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal(wave.Ordinal, wave.StartedAt, wave.CompletedAt);

        return result;
    }
}
