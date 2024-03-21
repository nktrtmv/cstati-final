using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;

public sealed class CstatiEventWorkflow
{
    public CstatiEventWorkflow(
        string eventId,
        CstatiEventWorkflowWave[] waves,
        CstatiEventWorkflowPaymentCollector[] paymentCollectors,
        bool isCompleted,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        Waves = waves;
        PaymentCollectors = paymentCollectors;
        IsCompleted = isCompleted;
        ConcurrencyToken = concurrencyToken;
    }

    public string EventId { get; }
    public CstatiEventWorkflowWave[] Waves { get; private set; }
    public CstatiEventWorkflowPaymentCollector[] PaymentCollectors { get; private set; }
    public bool IsCompleted { get; private set; }
    public ConcurrencyToken ConcurrencyToken { get; }

    internal void SetWaves(CstatiEventWorkflowWave[] waves)
    {
        Waves = waves;
    }

    internal void SetPaymentCollectors(CstatiEventWorkflowPaymentCollector[] paymentCollectors)
    {
        PaymentCollectors = paymentCollectors;
    }

    internal void SetIsCompleted(bool isCompleted)
    {
        IsCompleted = isCompleted;
    }
}
