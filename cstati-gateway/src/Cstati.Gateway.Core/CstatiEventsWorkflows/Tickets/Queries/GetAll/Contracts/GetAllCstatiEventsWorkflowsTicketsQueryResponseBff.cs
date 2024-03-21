using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts.Tickets;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryResponseBff
{
    public required GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBff[] Tickets { get; init; }
    public required string ConcurrencyToken { get; init; }
}
