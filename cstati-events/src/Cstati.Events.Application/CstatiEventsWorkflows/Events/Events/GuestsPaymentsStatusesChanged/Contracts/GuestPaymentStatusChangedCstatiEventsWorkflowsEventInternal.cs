using Cstati.Events.Application.CstatiEventsWorkflows.Events.Abstractions;
using Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts.GuestsPaymentsStatuses;

namespace Cstati.Events.Application.CstatiEventsWorkflows.Events.Events.GuestsPaymentsStatusesChanged.Contracts;

public sealed class GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal : CstatiEventsWorkflowsEventInternal
{
    public GuestPaymentStatusChangedCstatiEventsWorkflowsEventInternal(
        string eventId,
        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatus,
        double ticketPrice) : base(eventId)
    {
        PaymentStatus = paymentStatus;
        TicketPrice = ticketPrice;
    }

    internal CstatiEventWorkflowGuestPaymentStatusInternal PaymentStatus { get; }
    internal double TicketPrice { get; }
}
