using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

namespace Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents.GuestPaymentStatusChanged;

public sealed class GuestPaymentStatusChangedCstatiEventWorkflowApplicationEvent : CstatiEventWorkflowApplicationEvent
{
    public GuestPaymentStatusChangedCstatiEventWorkflowApplicationEvent(
        string eventId,
        string guestTelegramLogin,
        CstatiEventWorkflowGuestPaymentStatus guestPaymentStatus,
        double ticketPrice) : base(eventId)
    {
        GuestTelegramLogin = guestTelegramLogin;
        GuestPaymentStatus = guestPaymentStatus;
        TicketPrice = ticketPrice;
    }

    public string GuestTelegramLogin { get; }
    public CstatiEventWorkflowGuestPaymentStatus GuestPaymentStatus { get; }
    public double TicketPrice { get; }
}
