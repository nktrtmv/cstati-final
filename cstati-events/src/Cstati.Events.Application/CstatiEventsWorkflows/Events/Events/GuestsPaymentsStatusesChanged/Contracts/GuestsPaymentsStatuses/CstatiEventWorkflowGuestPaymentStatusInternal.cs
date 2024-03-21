namespace Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;

public enum CstatiEventWorkflowGuestPaymentStatusInternal
{
    None = 0,
    Pending = 1,
    Cancelled = 2,
    Paid = 3,
    RefundRequested = 4,
    Refunded = 5
}
