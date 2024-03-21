using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts.Waves;
using Cstati.Events.Workflows.GenericSubdomain;
using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Queries.GetAll.Waves;

internal static class GetAllCstatiEventsWorkflowsWavesQueryResponseWaveConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryResponseWave FromInternal(GetAllCstatiEventsWorkflowsWavesQueryResponseWaveInternal wave)
    {
        Timestamp? startedAt = NullableConverter.Convert(wave.StartedAt, UtcDateTimeConverterTo.ToTimeStamp);

        Timestamp? completedAt = NullableConverter.Convert(wave.CompletedAt, UtcDateTimeConverterTo.ToTimeStamp);

        var result = new GetAllCstatiEventsWorkflowsWavesQueryResponseWave
        {
            Ordinal = wave.Ordinal,
            StartedAt = startedAt,
            CompletedAt = completedAt
        };

        return result;
    }
}
