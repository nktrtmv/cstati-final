using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal FromDomain(CstatiEventWorkflowTicket[] tickets, ConcurrencyToken concurrencyToken)
    {
        GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal[] ticketsInternal =
            tickets.Select(GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal(ticketsInternal, concurrencyToken);

        return result;
    }
}
