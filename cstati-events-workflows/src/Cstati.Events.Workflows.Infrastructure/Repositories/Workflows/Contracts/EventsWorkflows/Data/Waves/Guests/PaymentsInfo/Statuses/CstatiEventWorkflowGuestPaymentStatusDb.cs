namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

public enum CstatiEventWorkflowGuestPaymentStatusDb
{
    None = 0,
    Pending = 1,
    Cancelled = 2,
    Paid = 3,
    RefundRequested = 4,
    Refunded = 5
}
