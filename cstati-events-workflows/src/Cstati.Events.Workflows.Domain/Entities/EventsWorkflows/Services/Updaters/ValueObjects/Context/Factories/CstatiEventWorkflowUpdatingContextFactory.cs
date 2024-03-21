using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents;
using Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents.GuestPaymentStatusChanged;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;

public static class CstatiEventWorkflowUpdatingContextFactory
{
    public static CstatiEventWorkflowUpdatingContext CreateWithNewWave(CstatiEventWorkflow workflow)
    {
        int ordinal = workflow.Waves.Any() ? workflow.Waves.Select(w => w.Ordinal).Max() + 1 : 1;

        CstatiEventWorkflowWave wave = CstatiEventWorkflowWaveFactory.CreateNew(ordinal);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Append(wave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithoutWave(CstatiEventWorkflow workflow, int waveOrdinal)
    {
        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveOrdinal).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithStartedWave(CstatiEventWorkflow workflow, int waveOrdinal)
    {
        CstatiEventWorkflowWave waveToStart = workflow.Waves.Single(w => w.Ordinal == waveOrdinal);

        CstatiEventWorkflowWave startedWave = CstatiEventWorkflowWaveFactory.CreateStarted(waveToStart);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveOrdinal).Append(startedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithCompletedWave(CstatiEventWorkflow workflow, int waveOrdinal)
    {
        CstatiEventWorkflowWave waveToComplete = workflow.Waves.Single(w => w.Ordinal == waveOrdinal);

        CstatiEventWorkflowWave completedWave = CstatiEventWorkflowWaveFactory.CreateCompleted(waveToComplete);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveOrdinal).Append(completedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithNewTicket(CstatiEventWorkflow workflow, int waveOrdinal, CstatiEventWorkflowTicket ticket)
    {
        CstatiEventWorkflowWave waveToUpdate = workflow.Waves.Single(w => w.Ordinal == waveOrdinal);

        CstatiEventWorkflowWave updatedWave = CstatiEventWorkflowWaveFactory.CreateWithNewTicket(waveToUpdate, ticket);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveOrdinal).Append(updatedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithoutTicket(CstatiEventWorkflow workflow, int waveOrdinal, CstatiEventWorkflowTicketType ticketType)
    {
        CstatiEventWorkflowWave waveToUpdate = workflow.Waves.Single(w => w.Ordinal == waveOrdinal);

        CstatiEventWorkflowWave updatedWave = CstatiEventWorkflowWaveFactory.CreateWithoutTicket(waveToUpdate, ticketType);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveOrdinal).Append(updatedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithNewPaymentCollector(CstatiEventWorkflow workflow, CstatiEventWorkflowPaymentCollector paymentCollector)
    {
        CstatiEventWorkflowPaymentCollector[] paymentCollectors = workflow.PaymentCollectors.Append(paymentCollector).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(workflow.Waves, paymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithUpdatedPaymentCollector(CstatiEventWorkflow workflow, CstatiEventWorkflowPaymentCollector paymentCollector)
    {
        CstatiEventWorkflowPaymentCollector[] paymentCollectors = workflow.PaymentCollectors
            .Where(c => c.PersonLogin != paymentCollector.PersonLogin)
            .Append(paymentCollector)
            .ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(workflow.Waves, paymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithoutPaymentCollector(CstatiEventWorkflow workflow, string personLogin)
    {
        CstatiEventWorkflowPaymentCollector[] paymentCollectors = workflow.PaymentCollectors.Where(c => c.PersonLogin != personLogin).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(workflow.Waves, paymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithNewGuests(CstatiEventWorkflow workflow, CstatiEventWorkflowGuest[] guests)
    {
        CstatiEventWorkflowWave waveToUpdate = workflow.Waves.Single(w => w.IsActive);

        CstatiEventWorkflowWave updatedWave = CstatiEventWorkflowWaveFactory.CreateWithNewGuests(waveToUpdate, guests);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveToUpdate.Ordinal).Append(updatedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithoutGuest(CstatiEventWorkflow workflow, string guestId)
    {
        CstatiEventWorkflowWave waveToUpdate = workflow.Waves.Single(w => w.Guests.Any(g => g.Id == guestId));

        CstatiEventWorkflowWave updatedWave = CstatiEventWorkflowWaveFactory.CreateWithoutGuest(waveToUpdate, guestId);

        CstatiEventWorkflowWave[] waves = workflow.Waves.Where(w => w.Ordinal != waveToUpdate.Ordinal).Append(updatedWave).ToArray();

        CstatiEventWorkflowUpdatingContext result = CreateFrom(waves, workflow.PaymentCollectors);

        return result;
    }

    public static CstatiEventWorkflowUpdatingContext CreateWithUpdatedGuest(CstatiEventWorkflow workflow, CstatiEventWorkflowGuest updatedGuest)
    {
        CstatiEventWorkflowWave waveToUpdate = workflow.Waves.Single(w => w.Guests.Any(g => g.Id == updatedGuest.Id));

        CstatiEventWorkflowGuest guestToUpdate = waveToUpdate.Guests.Single(g => g.Id == updatedGuest.Id);

        CstatiEventWorkflowApplicationEvent? guestPaymentStatusChanged = null;

        if (updatedGuest.PaymentInfo.Status != guestToUpdate.PaymentInfo.Status)
        {
            string guestTelegramLogin = updatedGuest.TelegramLogin;

            CstatiEventWorkflowGuestPaymentStatus guestPaymentStatus = updatedGuest.PaymentInfo.Status;

            CstatiEventWorkflowTicket ticket = waveToUpdate.Tickets.Single(t => t.Type == updatedGuest.TicketType);

            guestPaymentStatusChanged = new GuestPaymentStatusChangedCstatiEventWorkflowApplicationEvent(
                workflow.EventId,
                guestTelegramLogin,
                guestPaymentStatus,
                ticket.Price);
        }

        CstatiEventWorkflowWave updatedWave = CstatiEventWorkflowWaveFactory.CreateWithUpdatedGuest(waveToUpdate, updatedGuest);

        CstatiEventWorkflowWave[] waves = workflow.Waves
            .Where(w => w.Ordinal != waveToUpdate.Ordinal)
            .Append(updatedWave)
            .ToArray();

        CstatiEventWorkflowUpdatingContext result = guestPaymentStatusChanged is null
            ? CreateFrom(waves, workflow.PaymentCollectors)
            : CreateFrom(waves, workflow.PaymentCollectors, guestPaymentStatusChanged);

        return result;
    }

    internal static CstatiEventWorkflowUpdatingContext CreateFrom(
        CstatiEventWorkflowWave[] waves,
        CstatiEventWorkflowPaymentCollector[] paymentCollectors,
        params CstatiEventWorkflowApplicationEvent[] applicationEvents)
    {
        var result = new CstatiEventWorkflowUpdatingContext(waves, paymentCollectors, applicationEvents);

        return result;
    }
}
