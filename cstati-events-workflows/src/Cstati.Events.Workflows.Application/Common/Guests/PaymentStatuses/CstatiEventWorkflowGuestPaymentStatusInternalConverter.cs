using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;

internal static class CstatiEventWorkflowGuestPaymentStatusInternalConverter
{
    internal static CstatiEventWorkflowGuestPaymentStatusInternal FromDomain(CstatiEventWorkflowGuestPaymentStatus paymentStatus)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal result = paymentStatus switch
        {
            CstatiEventWorkflowGuestPaymentStatus.Pending => CstatiEventWorkflowGuestPaymentStatusInternal.Pending,
            CstatiEventWorkflowGuestPaymentStatus.Cancelled => CstatiEventWorkflowGuestPaymentStatusInternal.Cancelled,
            CstatiEventWorkflowGuestPaymentStatus.Paid => CstatiEventWorkflowGuestPaymentStatusInternal.Paid,
            CstatiEventWorkflowGuestPaymentStatus.RefundRequested => CstatiEventWorkflowGuestPaymentStatusInternal.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatus.Refunded => CstatiEventWorkflowGuestPaymentStatusInternal.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(paymentStatus)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentStatus ToDomain(CstatiEventWorkflowGuestPaymentStatusInternal paymentStatus)
    {
        CstatiEventWorkflowGuestPaymentStatus result = paymentStatus switch
        {
            CstatiEventWorkflowGuestPaymentStatusInternal.Pending => CstatiEventWorkflowGuestPaymentStatus.Pending,
            CstatiEventWorkflowGuestPaymentStatusInternal.Cancelled => CstatiEventWorkflowGuestPaymentStatus.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusInternal.Paid => CstatiEventWorkflowGuestPaymentStatus.Paid,
            CstatiEventWorkflowGuestPaymentStatusInternal.RefundRequested => CstatiEventWorkflowGuestPaymentStatus.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusInternal.Refunded => CstatiEventWorkflowGuestPaymentStatus.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(paymentStatus)
        };

        return result;
    }
}
