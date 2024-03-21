namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryBff
{
    public required string EventId { get; init; }
    public int? WaveOrdinal { get; init; }
}
