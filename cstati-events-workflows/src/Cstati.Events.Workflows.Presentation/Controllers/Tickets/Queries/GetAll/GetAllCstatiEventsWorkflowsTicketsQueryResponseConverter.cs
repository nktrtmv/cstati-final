using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Tickets.Queries.GetAll.Tickets;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsTicketsQueryResponseConverter
{
    internal static GetAllCstatiEventsWorkflowsTicketsQueryResponse FromInternal(GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal response)
    {
        GetAllCstatiEventsWorkflowsTicketsQueryResponseTicket[] tickets =
            response.Tickets.Select(GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(response.ConcurrencyToken);

        var result = new GetAllCstatiEventsWorkflowsTicketsQueryResponse
        {
            Tickets = { tickets },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
