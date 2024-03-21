using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.ValueObjects.ApplicationEvents;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;

public sealed class CstatiEventWorkflowUpdatingContext
{
    internal CstatiEventWorkflowUpdatingContext(
        CstatiEventWorkflowWave[] waves,
        CstatiEventWorkflowPaymentCollector[] paymentCollectors,
        CstatiEventWorkflowApplicationEvent[] applicationEvents)
    {
        Waves = waves;
        PaymentCollectors = paymentCollectors;
        ApplicationEvents = applicationEvents;
    }

    internal CstatiEventWorkflowWave[] Waves { get; }
    internal CstatiEventWorkflowPaymentCollector[] PaymentCollectors { get; }
    public CstatiEventWorkflowApplicationEvent[] ApplicationEvents { get; }
}
