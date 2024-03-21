using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves;

internal static class CstatiEventWorkflowWavesValidator
{
    internal static void Validate(CstatiEventWorkflowWave[] waves)
    {
        ValidateOrder(waves);

        ValidateStatuses(waves);

        ValidateGuestsDuplicatesByWaves(waves);

        Array.ForEach(waves, w => CstatiEventWorkflowWaveTicketsValidator.Validate(w.Tickets));

        Array.ForEach(waves, w => CstatiEventWorkflowWaveGuestsValidator.Validate(w.Guests));
    }

    private static void ValidateOrder(CstatiEventWorkflowWave[] waves)
    {
        int[] ordinals = waves.Select(w => w.Ordinal).Order().ToArray();

        for (var i = 0; i < waves.Length - 1; i++)
        {
            if (ordinals[i] != ordinals[i + 1] - 1)
            {
                throw new ApplicationException($"There are incorrect ordinals in waves, found {ordinals[i]} and then {ordinals[i + 1]}");
            }
        }
    }

    private static void ValidateStatuses(CstatiEventWorkflowWave[] waves)
    {
        CstatiEventWorkflowWave[] activeWaves = waves.Where(w => w.IsActive).ToArray();

        if (activeWaves.Length > 1)
        {
            throw new ApplicationException($"There are {activeWaves.Length} active waves, can be no more than 1");
        }
    }

    private static void ValidateGuestsDuplicatesByWaves(CstatiEventWorkflowWave[] waves)
    {
        Dictionary<int, CstatiEventWorkflowGuest[]> waveToGuestsMap = waves.ToDictionary(w => w.Ordinal, w => w.Guests);

        for (var i = 1; i < waves.Length; i++)
        {
            for (int j = i + 1; j < waves.Length + 1; j++)
            {
                CstatiEventWorkflowGuest[] duplicates = waveToGuestsMap[i].Intersect(waveToGuestsMap[j]).ToArray();

                if (duplicates.Length == 0)
                {
                    continue;
                }

                throw new ApplicationException($"Duplicates of guests found in wave {i} and wave {j}");
            }
        }
    }
}
