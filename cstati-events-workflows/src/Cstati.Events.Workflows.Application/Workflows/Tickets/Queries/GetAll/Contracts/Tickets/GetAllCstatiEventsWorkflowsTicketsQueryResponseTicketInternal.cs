using Cstati.Events.Workflows.Application.Common.Tickets.Types;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts.Tickets;

public sealed class GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal
{
    internal GetAllCstatiEventsWorkflowsTicketsQueryResponseTicketInternal(CstatiEventWorkflowTicketTypeInternal type, double price)
    {
        Type = type;
        Price = price;
    }

    public CstatiEventWorkflowTicketTypeInternal Type { get; }
    public double Price { get; }
}
