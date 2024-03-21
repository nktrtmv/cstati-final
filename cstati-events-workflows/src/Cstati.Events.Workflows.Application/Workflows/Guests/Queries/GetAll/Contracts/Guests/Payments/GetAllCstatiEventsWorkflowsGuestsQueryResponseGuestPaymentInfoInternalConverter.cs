using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments.AuditRecords;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal FromDomain(CstatiEventWorkflowGuestPaymentInfo info)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal status = CstatiEventWorkflowGuestPaymentStatusInternalConverter.FromDomain(info.Status);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal[] auditRecords =
            info.AuditRecords.Select(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal(status, auditRecords);

        return result;
    }
}
