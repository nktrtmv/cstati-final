using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;
using Cstati.Events.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestsPaymentsStatusesChanged.GuestsPaymentsStatuses;

internal static class CstatiEventWorkflowGuestPaymentStatusDtoConverter
{
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
