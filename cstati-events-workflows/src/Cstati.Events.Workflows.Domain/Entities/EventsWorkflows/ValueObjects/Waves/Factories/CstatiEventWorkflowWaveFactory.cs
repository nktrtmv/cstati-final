using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.GenericSubdomain.Dates;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.Factories;

internal static class CstatiEventWorkflowWaveFactory
{
    internal static CstatiEventWorkflowWave CreateNew(int ordinal)
    {
        CstatiEventWorkflowTicket[] tickets = Array.Empty<CstatiEventWorkflowTicket>();

        CstatiEventWorkflowGuest[] guests = Array.Empty<CstatiEventWorkflowGuest>();

        CstatiEventWorkflowGuest[] deletedGuests = Array.Empty<CstatiEventWorkflowGuest>();

        UtcDateTime? startedAt = null;

        UtcDateTime? completedAt = null;

        var result = new CstatiEventWorkflowWave(ordinal, tickets, guests, deletedGuests, startedAt, completedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateStarted(CstatiEventWorkflowWave wave)
    {
        UtcDateTime startedAt = UtcDateTime.Now;

        var result = new CstatiEventWorkflowWave(wave.Ordinal, wave.Tickets, wave.Guests, wave.DeletedGuests, startedAt, null);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateCompleted(CstatiEventWorkflowWave wave)
    {
        UtcDateTime completedAt = UtcDateTime.Now;

        CstatiEventWorkflowGuest[] guests = wave.Guests
            .Where(
                g => g.PaymentInfo.Status is
                    CstatiEventWorkflowGuestPaymentStatus.Paid or
                    CstatiEventWorkflowGuestPaymentStatus.RefundRequested)
            .ToArray();

        CstatiEventWorkflowGuest[] deletedGuests = wave.DeletedGuests
            .Concat(
                wave.Guests
                    .Where(
                        g => g.PaymentInfo.Status is not
                            (CstatiEventWorkflowGuestPaymentStatus.Paid or
                            CstatiEventWorkflowGuestPaymentStatus.RefundRequested)))
            .ToArray();

        var result = new CstatiEventWorkflowWave(wave.Ordinal, wave.Tickets, guests, deletedGuests, wave.StartedAt, completedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateWithNewTicket(CstatiEventWorkflowWave wave, CstatiEventWorkflowTicket ticket)
    {
        CstatiEventWorkflowTicket[] tickets = wave.Tickets.Append(ticket).ToArray();

        var result = new CstatiEventWorkflowWave(wave.Ordinal, tickets, wave.Guests, wave.DeletedGuests, wave.StartedAt, wave.CompletedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateWithoutTicket(CstatiEventWorkflowWave wave, CstatiEventWorkflowTicketType ticketType)
    {
        CstatiEventWorkflowTicket[] tickets = wave.Tickets.Where(t => t.Type != ticketType).ToArray();

        var result = new CstatiEventWorkflowWave(wave.Ordinal, tickets, wave.Guests, wave.DeletedGuests, wave.StartedAt, wave.CompletedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateWithNewGuests(CstatiEventWorkflowWave wave, CstatiEventWorkflowGuest[] guestsToAdd)
    {
        CstatiEventWorkflowGuest[] guests = wave.Guests.Concat(guestsToAdd).ToArray();

        var result = new CstatiEventWorkflowWave(wave.Ordinal, wave.Tickets, guests, wave.DeletedGuests, wave.StartedAt, wave.CompletedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateWithoutGuest(CstatiEventWorkflowWave wave, string guestId)
    {
        CstatiEventWorkflowGuest guestToDelete = wave.Guests.Single(g => g.Id == guestId);

        CstatiEventWorkflowGuest[] deletedGuests = wave.DeletedGuests.Append(guestToDelete).ToArray();

        CstatiEventWorkflowGuest[] guests = wave.Guests.Where(g => g.Id != guestId).ToArray();

        var result = new CstatiEventWorkflowWave(wave.Ordinal, wave.Tickets, guests, deletedGuests, wave.StartedAt, wave.CompletedAt);

        return result;
    }

    internal static CstatiEventWorkflowWave CreateWithUpdatedGuest(CstatiEventWorkflowWave wave, CstatiEventWorkflowGuest updatedGuest)
    {
        CstatiEventWorkflowGuest[] guests = wave.Guests.ToArray();

        CstatiEventWorkflowGuest[] deletedGuests = wave.DeletedGuests.ToArray();

        if (updatedGuest.PaymentInfo.Status == CstatiEventWorkflowGuestPaymentStatus.Refunded)
        {
            if (guests.Any(g => g.Id == updatedGuest.Id))
            {
                guests = guests.Where(g => g.Id != updatedGuest.Id).ToArray();

                deletedGuests = deletedGuests.Append(updatedGuest).ToArray();
            }
            else
            {
                deletedGuests = deletedGuests.Where(g => g.Id != updatedGuest.Id).Append(updatedGuest).ToArray();
            }
        }
        else
        {
            guests = guests.Where(g => g.Id != updatedGuest.Id).Append(updatedGuest).ToArray();
        }

        var result = new CstatiEventWorkflowWave(wave.Ordinal, wave.Tickets, guests, deletedGuests, wave.StartedAt, wave.CompletedAt);

        return result;
    }
}
