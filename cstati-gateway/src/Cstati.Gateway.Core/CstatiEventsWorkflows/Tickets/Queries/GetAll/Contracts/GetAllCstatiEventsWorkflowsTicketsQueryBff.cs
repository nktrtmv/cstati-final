namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryBff
{
    public required string EventId { get; init; }
    public required int WaveOrdinal { get; init; }
}
