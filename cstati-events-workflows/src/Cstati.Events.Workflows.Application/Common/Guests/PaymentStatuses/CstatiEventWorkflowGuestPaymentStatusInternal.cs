namespace Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;

public enum CstatiEventWorkflowGuestPaymentStatusInternal
{
    None = 0,
    Pending = 1,
    Cancelled = 2,
    Paid = 3,
    RefundRequested = 4,
    Refunded = 5
}
