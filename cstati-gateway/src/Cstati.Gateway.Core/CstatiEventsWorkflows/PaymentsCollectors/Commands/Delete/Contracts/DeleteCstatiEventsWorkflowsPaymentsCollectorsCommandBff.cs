namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBff
{
    public required string EventId { get; init; }
    public required string PersonLogin { get; init; }
    public required string ConcurrencyToken { get; init; }
}
