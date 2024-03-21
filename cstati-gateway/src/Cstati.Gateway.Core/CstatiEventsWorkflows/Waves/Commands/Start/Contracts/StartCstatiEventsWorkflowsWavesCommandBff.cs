namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start.Contracts;

public sealed class StartCstatiEventsWorkflowsWavesCommandBff
{
    public required string EventId { get; init; }
    public required int Ordinal { get; init; }
    public required string ConcurrencyToken { get; init; }
}
