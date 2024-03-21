namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create.Contracts;

public sealed class CreateCstatiEventsWorkflowsWavesCommandBff
{
    public required string EventId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
