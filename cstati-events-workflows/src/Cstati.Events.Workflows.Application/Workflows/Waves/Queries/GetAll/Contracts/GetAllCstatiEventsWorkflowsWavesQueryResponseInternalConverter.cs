using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponseInternal FromDomain(CstatiEventWorkflowWave[] waves, ConcurrencyToken concurrencyToken)
    {
        GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal[] wavesInternal =
            waves.Select(GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponseInternal(wavesInternal, concurrencyToken);

        return result;
    }
}
