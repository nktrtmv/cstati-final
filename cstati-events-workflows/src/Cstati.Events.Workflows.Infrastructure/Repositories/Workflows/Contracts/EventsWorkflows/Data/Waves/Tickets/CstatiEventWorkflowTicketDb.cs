using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets.Types;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets;

public sealed class CstatiEventWorkflowTicketDb
{
    public required CstatiEventWorkflowTicketTypeDb Type { get; init; }
    public required double Price { get; init; }
}
