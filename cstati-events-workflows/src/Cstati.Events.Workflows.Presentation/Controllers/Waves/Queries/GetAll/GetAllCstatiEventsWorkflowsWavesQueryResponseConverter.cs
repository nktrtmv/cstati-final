using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Queries.GetAll.Waves;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponse FromInternal(GetAllCstatiEventsWorkflowsWavesQueryResponseInternal response)
    {
        GetAllCstatiEventsWorkflowsWavesQueryResponseWave[] waves =
            response.Waves.Select(GetAllCstatiEventsWorkflowsWavesQueryResponseWaveConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponse
        {
            Waves = { waves },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
