using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.GenericSubdomain;
using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves;

internal static class CstatiEventWorkflowWaveDbConverter
{
    internal static CstatiEventWorkflowWaveDb FromDomain(CstatiEventWorkflowWave wave)
    {
        CstatiEventWorkflowTicketDb[] tickets = wave.Tickets.Select(CstatiEventWorkflowTicketDbConverter.FromDomain).ToArray();

        CstatiEventWorkflowGuestDb[] guests = wave.Guests.Select(CstatiEventWorkflowGuestDbConverter.FromDomain).ToArray();

        CstatiEventWorkflowGuestDb[] deletedGuests = wave.DeletedGuests.Select(CstatiEventWorkflowGuestDbConverter.FromDomain).ToArray();

        DateTime? startedAt = NullableConverter.Convert(wave.StartedAt, UtcDateTimeConverterTo.ToDateTime);

        DateTime? completedAt = NullableConverter.Convert(wave.CompletedAt, UtcDateTimeConverterTo.ToDateTime);

        var result = new CstatiEventWorkflowWaveDb
        {
            Ordinal = wave.Ordinal,
            Tickets = tickets,
            Guests = guests,
            DeletedGuests = deletedGuests,
            StartedAt = startedAt,
            CompletedAt = completedAt
        };

        return result;
    }

    internal static CstatiEventWorkflowWave ToDomain(CstatiEventWorkflowWaveDb wave)
    {
        CstatiEventWorkflowTicket[] tickets = wave.Tickets.Select(CstatiEventWorkflowTicketDbConverter.ToDomain).ToArray();

        CstatiEventWorkflowGuest[] guests = wave.Guests.Select(CstatiEventWorkflowGuestDbConverter.ToDomain).ToArray();

        CstatiEventWorkflowGuest[] deletedGuests = wave.DeletedGuests.Select(CstatiEventWorkflowGuestDbConverter.ToDomain).ToArray();

        UtcDateTime? startedAt = NullableConverter.Convert(wave.StartedAt, UtcDateTimeConverterFrom.FromUtcDateTime);

        UtcDateTime? completedAt = NullableConverter.Convert(wave.CompletedAt, UtcDateTimeConverterFrom.FromUtcDateTime);

        var result = new CstatiEventWorkflowWave(wave.Ordinal, tickets, guests, deletedGuests, startedAt, completedAt);

        return result;
    }
}
