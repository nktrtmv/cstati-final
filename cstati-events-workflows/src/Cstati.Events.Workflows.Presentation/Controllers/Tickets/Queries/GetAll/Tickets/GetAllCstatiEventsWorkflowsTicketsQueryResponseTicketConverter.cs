using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts.Tickets;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets.Queries.GetAll.Tickets;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponseTicket FromInternal(GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal ticket)
    {
        CstatiEventWorkflowTicketTypeDto ticketType = CstatiEventWorkflowTicketTypeDtoConverter.FromInternal(ticket.Type);

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponseTicket
        {
            Type = ticketType,
            Price = ticket.Price
        };

        return result;
    }
}
