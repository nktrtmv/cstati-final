using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments.AuditRecords;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal
{
    internal GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal(
        CstatiEventWorkflowGuestPaymentStatusInternal status,
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal[] auditRecords)
    {
        Status = status;
        AuditRecords = auditRecords;
    }

    public CstatiEventWorkflowGuestPaymentStatusInternal Status { get; }
    public GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal[] AuditRecords { get; }
}
