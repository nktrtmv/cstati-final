using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Publisher.CstatiEventsWorkflows.Events.Converters.GuestsPaymentsStatuses;

internal static class CstatiEventWorkflowGuestPaymentStatusDtoConverter
{
    internal static CstatiEventWorkflowGuestPaymentStatusDto FromDomain(CstatiEventWorkflowGuestPaymentStatus status)
    {
        CstatiEventWorkflowGuestPaymentStatusDto result = status switch
        {
            CstatiEventWorkflowGuestPaymentStatus.Pending => CstatiEventWorkflowGuestPaymentStatusDto.Pending,
            CstatiEventWorkflowGuestPaymentStatus.Cancelled => CstatiEventWorkflowGuestPaymentStatusDto.Cancelled,
            CstatiEventWorkflowGuestPaymentStatus.Paid => CstatiEventWorkflowGuestPaymentStatusDto.Paid,
            CstatiEventWorkflowGuestPaymentStatus.RefundRequested => CstatiEventWorkflowGuestPaymentStatusDto.RefundRequested,
            CstatiEventWorkflowGuestPaymentStatus.Refunded => CstatiEventWorkflowGuestPaymentStatusDto.Refunded,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
