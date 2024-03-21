namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

public enum CstatiEventWorkflowGuestPaymentStatusBff
{
    None = 0,
    Pending = 1,
    Cancelled = 2,
    Paid = 3,
    RefundRequested = 4,
    Refunded = 5
}
