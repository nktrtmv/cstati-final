using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts.Tickets;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal FromDomain(CstatiEventWorkflowTicket ticket)
    {
        CstatiEventWorkflowTicketTypeInternal type = CstatiEventWorkflowTicketTypeInternalConverter.FromDomain(ticket.Type);

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal(type, ticket.Price);

        return result;
    }
}
