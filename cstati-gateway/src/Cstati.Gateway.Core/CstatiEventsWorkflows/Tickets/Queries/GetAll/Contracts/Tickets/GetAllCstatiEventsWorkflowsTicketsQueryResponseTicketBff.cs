using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts.Tickets;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBff
{
    public required CstatiEventWorkflowTicketTypeBff Type { get; init; }
    public required double Price { get; init; }
}
