namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsWavesCommandBff
{
    public required string EventId { get; init; }
    public required int Ordinal { get; init; }
    public required string ConcurrencyToken { get; init; }
}
