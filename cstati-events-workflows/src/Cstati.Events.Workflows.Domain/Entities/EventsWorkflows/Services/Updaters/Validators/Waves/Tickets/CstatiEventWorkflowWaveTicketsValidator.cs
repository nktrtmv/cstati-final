using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves.Tickets;

internal static class CstatiEventWorkflowWaveTicketsValidator
{
    internal static void Validate(CstatiEventWorkflowTicket[] tickets)
    {
        ValidateDuplicates(tickets);

        ValidatePrices(tickets);
    }

    private static void ValidateDuplicates(CstatiEventWorkflowTicket[] tickets)
    {
        CstatiEventWorkflowTicketType[] duplicates = tickets
            .GroupBy(c => c.Type)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();

        if (duplicates.Length > 0)
        {
            throw new ApplicationException($"Duplicates of tickets by types are found: {string.Join(", ", duplicates)}");
        }
    }

    private static void ValidatePrices(CstatiEventWorkflowTicket[] tickets)
    {
        CstatiEventWorkflowTicket? standard = tickets.SingleOrDefault(t => t.Type == CstatiEventWorkflowTicketType.Standard);

        CstatiEventWorkflowTicket? comfort = tickets.SingleOrDefault(t => t.Type == CstatiEventWorkflowTicketType.Comfort);

        if (standard is null)
        {
            return;
        }

        if (standard.Price <= 0)
        {
            throw new ApplicationException("Price of standard ticket cannot be equal or less than 0");
        }

        if (comfort is null)
        {
            return;
        }

        if (comfort.Price <= 0)
        {
            throw new ApplicationException("Price of comfort ticket cannot be equal or less than 0");
        }

        if (standard.Price > comfort.Price)
        {
            throw new ApplicationException("Comfort ticket cannot have price less than standard");
        }
    }
}
