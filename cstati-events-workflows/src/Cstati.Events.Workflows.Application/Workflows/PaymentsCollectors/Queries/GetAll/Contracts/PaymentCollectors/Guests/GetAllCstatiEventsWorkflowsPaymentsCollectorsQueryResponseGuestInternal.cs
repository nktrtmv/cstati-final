using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors.Guests;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal
{
    internal GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal(
        string id,
        string fullName,
        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatus)
    {
        Id = id;
        FullName = fullName;
        PaymentStatus = paymentStatus;
    }

    public string Id { get; }
    public string FullName { get; }
    public CstatiEventWorkflowGuestPaymentStatusInternal PaymentStatus { get; }
}
