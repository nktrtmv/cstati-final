using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts.Waves;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseBffConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponseBff FromDto(GetAllCstatiEventsWorkflowsWavesQueryResponse response)
    {
        GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBff[] waves = response.Waves.Select(GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBffConverter.FromDto)
            .ToArray();

        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponseBff
        {
            Waves = waves,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
