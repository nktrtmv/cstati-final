using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves;

public sealed class CstatiEventWorkflowWaveDb
{
    public required int Ordinal { get; init; }
    public required CstatiEventWorkflowTicketDb[] Tickets { get; init; }
    public required CstatiEventWorkflowGuestDb[] Guests { get; init; }
    public required CstatiEventWorkflowGuestDb[] DeletedGuests { get; init; }
    public DateTime? StartedAt { get; init; }
    public DateTime? CompletedAt { get; init; }
}
