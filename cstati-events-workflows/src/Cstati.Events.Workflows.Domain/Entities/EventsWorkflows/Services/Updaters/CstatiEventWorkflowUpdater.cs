using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters;

public static class CstatiEventWorkflowUpdater
{
    public static void Update(CstatiEventWorkflow workflow, CstatiEventWorkflowUpdatingContext context)
    {
        if (workflow.IsCompleted)
        {
            throw new ApplicationException("Cannot update completed workflow");
        }

        CstatiEventWorkflowWave[] waves = context.Waves.OrderBy(w => w.Ordinal).ToArray();

        workflow.SetWaves(waves);

        workflow.SetPaymentCollectors(context.PaymentCollectors);

        CstatiEventWorkflowValidator.Validate(workflow);
    }
}
