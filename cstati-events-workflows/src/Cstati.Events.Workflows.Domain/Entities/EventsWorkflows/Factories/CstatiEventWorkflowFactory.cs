using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Factories;

public static class CstatiEventWorkflowFactory
{
    public static CstatiEventWorkflow CreateNew(string eventId)
    {
        CstatiEventWorkflowWave[] waves = Array.Empty<CstatiEventWorkflowWave>();

        CstatiEventWorkflowPaymentCollector[] paymentCollectors = Array.Empty<CstatiEventWorkflowPaymentCollector>();

        const bool isCompleted = false;

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromUtcDateTime(DateTime.UtcNow);

        var result = new CstatiEventWorkflow(eventId, waves, paymentCollectors, isCompleted, concurrencyToken);

        return result;
    }
}
