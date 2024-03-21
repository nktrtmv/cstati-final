using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts.Tickets;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseBffConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponseBff FromDto(GetAllCstatiEventsWorkflowsTicketsQueryResponse response)
    {
        GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBff[] tickets =
            response.Tickets.Select(GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponseBff
        {
            Tickets = tickets,
            ConcurrencyToken = response.ConcurrencyToken
        };

        return result;
    }
}
