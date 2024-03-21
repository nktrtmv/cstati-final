using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts;
using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;
using Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestsPaymentsStatusesChanged.GuestsPaymentsStatuses;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events.GuestsPaymentsStatusesChanged;

internal static class GuestPaymentStatusChangedCstatiEventsWorkflowsEventConverter
{
    internal static GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal? ToInternal(CstatiEventsWorkflowsEventValue @event)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatus =
            CstatiEventWorkflowGuestPaymentStatusDtoConverter.ToInternal(@event.GuestPaymentStatusChanged.GuestPaymentStatus);

        if (paymentStatus is not (CstatiEventWorkflowGuestPaymentStatusInternal.Paid or CstatiEventWorkflowGuestPaymentStatusInternal.Refunded))
        {
            return null;
        }

        var result = new GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal(@event.EventId, paymentStatus, @event.GuestPaymentStatusChanged.TicketPrice);

        return result;
    }
}
