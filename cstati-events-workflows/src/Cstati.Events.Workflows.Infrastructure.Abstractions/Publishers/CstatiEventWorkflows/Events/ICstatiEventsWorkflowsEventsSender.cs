using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;

namespace Cstati.Events.Workflows.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;

public interface ICstatiEventsWorkflowsEventsSender
{
    Task SendGuestPaymentStatusChangedEvent(
        string eventId,
        string guestTelegramLogin,
        CstatiEventWorkflowGuestPaymentStatus guestPaymentStatus,
        double ticketPrice,
        CancellationToken cancellationToken);
}
