using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

internal static class CstatiEventWorkflowGuestPaymentStatusBffConverter
{
    internal static CstatiEventWorkflowGuestPaymentStatusBff FromDto(CstatiEventWorkflowGuestPaymentStatusDto status)
    {
        CstatiEventWorkflowGuestPaymentStatusBff result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatusDto.Pending => CstatiEventWorkflowGuestPaymentStatusBff.Pending,
            CstatiEventWorkflowGuestPaymentStatusDto.Cancelled => CstatiEventWorkflowGuestPaymentStatusBff.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusDto.Paid => CstatiEventWorkflowGuestPaymentStatusBff.Paid,
            CstatiEventWorkflowGuestPaymentStatusDto.RefundRequested => CstatiEventWorkflowGuestPaymentStatusBff.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusDto.Refunded => CstatiEventWorkflowGuestPaymentStatusBff.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestPaymentStatusDto ToDto(CstatiEventWorkflowGuestPaymentStatusBff status)
    {
        CstatiEventWorkflowGuestPaymentStatusDto result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatusBff.Pending => CstatiEventWorkflowGuestPaymentStatusDto.Pending,
            CstatiEventWorkflowGuestPaymentStatusBff.Cancelled => CstatiEventWorkflowGuestPaymentStatusDto.Cancelled,
            CstatiEventWorkflowGuestPaymentStatusBff.Paid => CstatiEventWorkflowGuestPaymentStatusDto.Paid,
            CstatiEventWorkflowGuestPaymentStatusBff.RefundRequested => CstatiEventWorkflowGuestPaymentStatusDto.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatusBff.Refunded => CstatiEventWorkflowGuestPaymentStatusDto.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
