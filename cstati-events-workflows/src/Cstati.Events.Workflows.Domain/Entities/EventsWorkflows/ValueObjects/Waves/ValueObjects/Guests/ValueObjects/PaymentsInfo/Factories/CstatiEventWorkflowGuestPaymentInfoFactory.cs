using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.Factories;

internal static class CstatiEventWorkflowGuestPaymentInfoFactory
{
    internal static CstatiEventWorkflowGuestPaymentInfo CreateNew()
    {
        const CstatiEventWorkflowGuestPaymentStatus status = CstatiEventWorkflowGuestPaymentStatus.Pending;

        CstatiEventWorkflowGuestPaymentAuditRecord[] auditRecords = Array.Empty<CstatiEventWorkflowGuestPaymentAuditRecord>();

        var result = new CstatiEventWorkflowGuestPaymentInfo(status, auditRecords);

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentInfo CreateFrom(CstatiEventWorkflowGuestPaymentInfo info, CstatiEventWorkflowGuestPaymentStatus statusChangeTo)
    {
        CstatiEventWorkflowGuestPaymentAuditRecord newAuditRecord = CstatiEventWorkflowGuestPaymentAuditRecordFactory.CreateNew(statusChangeTo);

        CstatiEventWorkflowGuestPaymentAuditRecord[] auditRecords = info.AuditRecords.Append(newAuditRecord).ToArray();

        var result = new CstatiEventWorkflowGuestPaymentInfo(statusChangeTo, auditRecords);

        return result;
    }
}
