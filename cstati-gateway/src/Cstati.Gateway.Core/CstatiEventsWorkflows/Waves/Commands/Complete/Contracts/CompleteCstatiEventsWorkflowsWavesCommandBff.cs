namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete.Contracts;

public sealed class CompleteCstatiEventsWorkflowsWavesCommandBff
{
    public required string EventId { get; init; }
    public required int Ordinal { get; init; }
    public required string ConcurrencyToken { get; init; }
}
