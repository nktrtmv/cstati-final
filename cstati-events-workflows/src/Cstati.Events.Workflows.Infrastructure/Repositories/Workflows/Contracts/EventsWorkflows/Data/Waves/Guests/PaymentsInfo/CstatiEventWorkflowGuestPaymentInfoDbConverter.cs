using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.AuditRecords;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo;

internal static class CstatiEventWorkflowGuestPaymentInfoDbConverter
{
    internal static CstatiEventWorkflowGuestPaymentInfoDb FromDomain(CstatiEventWorkflowGuestPaymentInfo paymentInfo)
    {
        CstatiEventWorkflowGuestPaymentStatusDb status = CstatiEventWorkflowGuestPaymentStatusDbConverter.FromDomain(paymentInfo.Status);

        CstatiEventWorkflowGuestPaymentAuditRecordDb[] auditRecords =
            paymentInfo.AuditRecords.Select(CstatiEventWorkflowGuestPaymentAuditRecordDbConverter.FromDomain).ToArray();

        var result = new CstatiEventWorkflowGuestPaymentInfoDb
        {
            Status = status,
            AuditRecords = auditRecords
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentInfo ToDomain(CstatiEventWorkflowGuestPaymentInfoDb paymentInfo)
    {
        CstatiEventWorkflowGuestPaymentStatus status = CstatiEventWorkflowGuestPaymentStatusDbConverter.ToDomain(paymentInfo.Status);

        CstatiEventWorkflowGuestPaymentAuditRecord[] auditRecords =
            paymentInfo.AuditRecords.Select(CstatiEventWorkflowGuestPaymentAuditRecordDbConverter.ToDomain).ToArray();

        var result = new CstatiEventWorkflowGuestPaymentInfo(status, auditRecords);

        return result;
    }
}
