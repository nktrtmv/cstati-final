using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves.Guests;

internal static class CstatiEventWorkflowWaveGuestsValidator
{
    internal static void Validate(CstatiEventWorkflowGuest[] guests)
    {
        ValidateDuplicates(guests);
    }

    private static void ValidateDuplicates(CstatiEventWorkflowGuest[] guests)
    {
        string[] duplicates = guests
            .GroupBy(c => c.TelegramLogin)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();

        if (duplicates.Length > 0)
        {
            throw new ApplicationException($"Duplicates of guest are found: {string.Join(", ", duplicates)}");
        }
    }
}
