using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.AuditRecords;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments.AuditRecords;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal FromDomain(CstatiEventWorkflowGuestPaymentAuditRecord record)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal statusChangeTo = CstatiEventWorkflowGuestPaymentStatusInternalConverter.FromDomain(record.StatusChangedTo);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal(record.Date, statusChangeTo);

        return result;
    }
}
