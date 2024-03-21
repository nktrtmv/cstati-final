using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts.Waves;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsWavesQueryResponseBff
{
    public required GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBff[] Waves { get; init; }
    public required string ConcurrencyToken { get; init; }
}
