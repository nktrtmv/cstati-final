using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;

public sealed class CstatiEventWorkflowWave
{
    public CstatiEventWorkflowWave(
        int ordinal,
        CstatiEventWorkflowTicket[] tickets,
        CstatiEventWorkflowGuest[] guests,
        CstatiEventWorkflowGuest[] deletedGuests,
        UtcDateTime? startedAt,
        UtcDateTime? completedAt)
    {
        Ordinal = ordinal;
        Tickets = tickets;
        Guests = guests;
        DeletedGuests = deletedGuests;
        StartedAt = startedAt;
        CompletedAt = completedAt;
    }

    public int Ordinal { get; }
    public CstatiEventWorkflowTicket[] Tickets { get; }
    public CstatiEventWorkflowGuest[] Guests { get; }
    public CstatiEventWorkflowGuest[] DeletedGuests { get; }
    public UtcDateTime? StartedAt { get; }
    public UtcDateTime? CompletedAt { get; }

    public bool IsActive => StartedAt is not null && CompletedAt is null;
}
