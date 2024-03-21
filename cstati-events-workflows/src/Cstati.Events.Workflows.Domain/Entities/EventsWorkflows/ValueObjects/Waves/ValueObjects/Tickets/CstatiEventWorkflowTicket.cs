using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;

public sealed class CstatiEventWorkflowTicket
{
    public CstatiEventWorkflowTicket(CstatiEventWorkflowTicketType type, double price)
    {
        Type = type;
        Price = price;
    }

    public CstatiEventWorkflowTicketType Type { get; }
    public double Price { get; }
}
