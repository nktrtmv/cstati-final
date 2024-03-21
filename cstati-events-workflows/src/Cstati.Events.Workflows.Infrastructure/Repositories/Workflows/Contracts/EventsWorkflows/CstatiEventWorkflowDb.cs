namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows;

public sealed class CstatiEventWorkflowDb
{
    public required string EventId { get; init; }
    public required string Data { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
}
