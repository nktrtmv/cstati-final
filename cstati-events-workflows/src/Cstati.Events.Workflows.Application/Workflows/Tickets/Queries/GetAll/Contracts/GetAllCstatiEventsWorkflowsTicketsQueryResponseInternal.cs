using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts.Tickets;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal
{
    internal GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal(
        GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal[] tickets,
        ConcurrencyToken concurrencyToken)
    {
        Tickets = tickets;
        ConcurrencyToken = concurrencyToken;
    }

    public GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal[] Tickets { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
