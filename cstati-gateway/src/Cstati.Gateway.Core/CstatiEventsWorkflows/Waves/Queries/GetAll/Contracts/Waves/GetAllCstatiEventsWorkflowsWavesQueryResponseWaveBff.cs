namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts.Waves;

public sealed class GetAllCstatiEventsWorkflowsWavesQueryResponseWaveBff
{
    public required int Ordinal { get; init; }
    public required DateTime? StartedAt { get; init; }
    public required DateTime? CompletedAt { get; init; }
}
