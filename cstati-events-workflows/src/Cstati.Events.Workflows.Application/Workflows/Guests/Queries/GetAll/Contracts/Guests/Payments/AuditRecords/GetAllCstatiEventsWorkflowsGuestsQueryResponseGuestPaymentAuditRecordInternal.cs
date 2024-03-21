using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments.AuditRecords;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal
{
    internal GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal(
        UtcDateTime date,
        CstatiEventWorkflowGuestPaymentStatusInternal statusChangedTo)
    {
        Date = date;
        StatusChangedTo = statusChangedTo;
    }

    public UtcDateTime Date { get; }
    public CstatiEventWorkflowGuestPaymentStatusInternal StatusChangedTo { get; }
}
