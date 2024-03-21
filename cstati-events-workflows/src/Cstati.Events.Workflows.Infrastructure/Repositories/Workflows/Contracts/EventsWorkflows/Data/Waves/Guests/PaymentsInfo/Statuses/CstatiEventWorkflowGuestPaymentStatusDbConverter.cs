using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

internal static class CstatiEventWorkflowGuestPaymentStatusDbConverter
{
    internal static CstatiEventWorkflowGuestPaymentStatusDb FromDomain(CstatiEventWorkflowGuestPaymentStatus status)
    {
        CstatiEventWorkflowGuestPaymentStatusDb result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatus.Pending => CstatiEventWorkflowGuestPaymentStatusDb.Pending,
            CstatiEventWorkflowGuestPaymentStatus.Cancelled => CstatiEventWorkflowGuestPaymentStatusDb.Cancelled,
            CstatiEventWorkflowGuestPaymentStatus.Paid => CstatiEventWorkflowGuestPaymentStatusDb.Paid,
            CstatiEventWorkflowGuestPaymentStatus.RefundRequested => CstatiEventWorkflowGuestPaymentStatusDb.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatus.Refunded => CstatiEventWorkflowGuestPaymentStatusDb.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentStatus ToDomain(CstatiEventWorkflowGuestPaymentStatusDb status)
    {
        CstatiEventWorkflowGuestPaymentStatus result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatusDb.Pending => CstatiEventWorkflowGuestPaymentStatus.Pending,
            CstatiEventWorkflowGuestPaymentStatusDb.Cancelled => CstatiEventWorkflowGuestPaymentStatus.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusDb.Paid => CstatiEventWorkflowGuestPaymentStatus.Paid,
            CstatiEventWorkflowGuestPaymentStatusDb.RefundRequested => CstatiEventWorkflowGuestPaymentStatus.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusDb.Refunded => CstatiEventWorkflowGuestPaymentStatus.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
