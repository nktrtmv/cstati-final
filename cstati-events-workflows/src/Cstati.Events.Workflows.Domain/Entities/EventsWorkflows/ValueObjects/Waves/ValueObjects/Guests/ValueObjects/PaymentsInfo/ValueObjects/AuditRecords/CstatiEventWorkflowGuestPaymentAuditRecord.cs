using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;

public sealed class CstatiEventWorkflowGuestPaymentAuditRecord
{
    public CstatiEventWorkflowGuestPaymentAuditRecord(UtcDateTime date, CstatiEventWorkflowGuestPaymentStatus statusChangedTo)
    {
        Date = date;
        StatusChangedTo = statusChangedTo;
    }

    public UtcDateTime Date { get; }
    public CstatiEventWorkflowGuestPaymentStatus StatusChangedTo { get; }
}
