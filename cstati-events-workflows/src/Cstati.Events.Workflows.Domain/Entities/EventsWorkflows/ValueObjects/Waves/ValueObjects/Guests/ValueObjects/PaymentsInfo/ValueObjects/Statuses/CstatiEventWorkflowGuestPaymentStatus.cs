namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

public enum CstatiEventWorkflowGuestPaymentStatus
{
    None = 0,
    Pending = 1,
    Cancelled = 2,
    Paid = 3,
    RefundRequested = 4,
    Refunded = 5
}
