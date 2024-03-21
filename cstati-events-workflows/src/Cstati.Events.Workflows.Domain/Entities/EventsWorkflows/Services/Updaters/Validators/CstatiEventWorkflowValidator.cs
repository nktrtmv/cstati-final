using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.PaymentCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.Waves;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators;

internal static class CstatiEventWorkflowValidator
{
    internal static void Validate(CstatiEventWorkflow workflow)
    {
        CstatiEventWorkflowPaymentCollectorsValidator.Validate(workflow.PaymentCollectors);

        CstatiEventWorkflowWavesValidator.Validate(workflow.Waves);
    }
}
