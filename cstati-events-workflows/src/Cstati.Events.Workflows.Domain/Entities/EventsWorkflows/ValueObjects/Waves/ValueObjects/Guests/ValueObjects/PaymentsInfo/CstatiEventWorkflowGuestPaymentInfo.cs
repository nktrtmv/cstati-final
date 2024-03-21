using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;

public sealed class CstatiEventWorkflowGuestPaymentInfo
{
    public CstatiEventWorkflowGuestPaymentInfo(CstatiEventWorkflowGuestPaymentStatus status, CstatiEventWorkflowGuestPaymentAuditRecord[] auditRecords)
    {
        Status = status;
        AuditRecords = auditRecords;
    }

    public CstatiEventWorkflowGuestPaymentStatus Status { get; }
    public CstatiEventWorkflowGuestPaymentAuditRecord[] AuditRecords { get; }
}
