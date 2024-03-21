using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets.Types;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets;

internal static class CstatiEventWorkflowTicketDbConverter
{
    internal static CstatiEventWorkflowTicketDb FromDomain(CstatiEventWorkflowTicket ticket)
    {
        CstatiEventWorkflowTicketTypeDb ticketType = CstatiEventWorkflowTicketTypeDbConverter.FromDomain(ticket.Type);

        var result = new CstatiEventWorkflowTicketDb
        {
            Type = ticketType,
            Price = ticket.Price
        };

        return result;
    }

    internal static CstatiEventWorkflowTicket ToDomain(CstatiEventWorkflowTicketDb ticket)
    {
        CstatiEventWorkflowTicketType ticketType = CstatiEventWorkflowTicketTypeDbConverter.ToDomain(ticket.Type);

        var result = new CstatiEventWorkflowTicket(ticketType, ticket.Price);

        return result;
    }
}
