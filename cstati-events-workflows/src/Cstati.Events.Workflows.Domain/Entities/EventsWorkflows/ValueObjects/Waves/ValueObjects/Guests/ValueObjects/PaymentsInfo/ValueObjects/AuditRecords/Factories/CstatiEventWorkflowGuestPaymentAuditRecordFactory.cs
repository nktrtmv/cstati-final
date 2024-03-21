using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords.Factories;

internal static class CstatiEventWorkflowGuestPaymentAuditRecordFactory
{
    internal static CstatiEventWorkflowGuestPaymentAuditRecord CreateNew(CstatiEventWorkflowGuestPaymentStatus statusChangeTo)
    {
        UtcDateTime date = UtcDateTime.Now;

        var result = new CstatiEventWorkflowGuestPaymentAuditRecord(date, statusChangeTo);

        return result;
    }
}
