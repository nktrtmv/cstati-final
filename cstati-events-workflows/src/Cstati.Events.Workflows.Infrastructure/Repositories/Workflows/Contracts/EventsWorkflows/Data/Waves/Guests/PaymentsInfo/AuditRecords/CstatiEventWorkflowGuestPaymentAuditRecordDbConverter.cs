using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.AuditRecords;

internal static class CstatiEventWorkflowGuestPaymentAuditRecordDbConverter
{
    internal static CstatiEventWorkflowGuestPaymentAuditRecordDb FromDomain(CstatiEventWorkflowGuestPaymentAuditRecord auditRecord)
    {
        CstatiEventWorkflowGuestPaymentStatusDb statusChangedTo =
            CstatiEventWorkflowGuestPaymentStatusDbConverter.FromDomain(auditRecord.StatusChangedTo);

        var result = new CstatiEventWorkflowGuestPaymentAuditRecordDb
        {
            Date = auditRecord.Date,
            StatusChangedTo = statusChangedTo
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentAuditRecord ToDomain(CstatiEventWorkflowGuestPaymentAuditRecordDb auditRecord)
    {
        CstatiEventWorkflowGuestPaymentStatus statusChangedTo =
            CstatiEventWorkflowGuestPaymentStatusDbConverter.ToDomain(auditRecord.StatusChangedTo);

        var result = new CstatiEventWorkflowGuestPaymentAuditRecord(auditRecord.Date, statusChangedTo);

        return result;
    }
}
