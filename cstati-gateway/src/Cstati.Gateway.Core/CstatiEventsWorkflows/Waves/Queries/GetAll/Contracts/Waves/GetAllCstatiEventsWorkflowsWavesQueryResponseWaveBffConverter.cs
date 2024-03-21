using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts.Waves;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBffConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBff FromDto(GetAllCstatiEventsWorkflowsWavesQueryResponseWave wave)
    {
        var startedAt = wave.StartedAt?.ToDateTime();

        var finishedAt = wave.CompletedAt?.ToDateTime();

        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBff
        {
            Ordinal = wave.Ordinal,
            StartedAt = startedAt,
            CompletedAt = finishedAt
        };

        return result;
    }
}
