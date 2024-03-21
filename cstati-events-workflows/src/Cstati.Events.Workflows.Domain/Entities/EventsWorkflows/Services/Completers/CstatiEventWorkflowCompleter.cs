using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.Factories;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Completers;

public static class CstatiEventWorkflowCompleter
{
    public static void Complete(CstatiEventWorkflow workflow)
    {
        CstatiEventWorkflowWave[] wavesToComplete =
            workflow.Waves.Where(w => w.IsActive || w.StartedAt is null).ToArray();

        CstatiEventWorkflowWave[] completedWaves =
            wavesToComplete.Select(CstatiEventWorkflowWaveFactory.CreateCompleted).ToArray();

        CstatiEventWorkflowWave[] waves = workflow.Waves
            .Where(
                wave =>
                    !wavesToComplete
                        .Select(w => w.Ordinal)
                        .Contains(wave.Ordinal))
            .Concat(completedWaves)
            .ToArray();

        CstatiEventWorkflowUpdatingContext updatingContext =
            CstatiEventWorkflowUpdatingContextFactory.CreateFrom(waves, workflow.PaymentCollectors);

        CstatiEventWorkflowUpdater.Update(workflow, updatingContext);

        workflow.SetIsCompleted(true);
    }
}
