using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;

internal static class CstatiEventWorkflowGuestPaymentStatusDtoConverter
{
    internal static CstatiEventWorkflowGuestPaymentStatusDto FromInternal(CstatiEventWorkflowGuestPaymentStatusInternal status)
    {
        CstatiEventWorkflowGuestPaymentStatusDto result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatusInternal.Pending => CstatiEventWorkflowGuestPaymentStatusDto.Pending,
            CstatiEventWorkflowGuestPaymentStatusInternal.Cancelled => CstatiEventWorkflowGuestPaymentStatusDto.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusInternal.Paid => CstatiEventWorkflowGuestPaymentStatusDto.Paid,
            CstatiEventWorkflowGuestPaymentStatusInternal.RefundRequested => CstatiEventWorkflowGuestPaymentStatusDto.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusInternal.Refunded => CstatiEventWorkflowGuestPaymentStatusDto.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentStatusInternal ToInternal(CstatiEventWorkflowGuestPaymentStatusDto status)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatusDto.Pending => CstatiEventWorkflowGuestPaymentStatusInternal.Pending,
            CstatiEventWorkflowGuestPaymentStatusDto.Cancelled => CstatiEventWorkflowGuestPaymentStatusInternal.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusDto.Paid => CstatiEventWorkflowGuestPaymentStatusInternal.Paid,
            CstatiEventWorkflowGuestPaymentStatusDto.RefundRequested => CstatiEventWorkflowGuestPaymentStatusInternal.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusDto.Refunded => CstatiEventWorkflowGuestPaymentStatusInternal.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
