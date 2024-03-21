using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts.Tickets;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBffConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBff FromDto(GetAllCstatiEventsWorkflowsTicketsQueryResponseTicket ticket)
    {
        CstatiEventWorkflowTicketTypeBff type = CstatiEventWorkflowTicketTypeBffConverter.FromDto(ticket.Type);

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBff
        {
            Type = type,
            Price = ticket.Price
        };

        return result;
    }
}
