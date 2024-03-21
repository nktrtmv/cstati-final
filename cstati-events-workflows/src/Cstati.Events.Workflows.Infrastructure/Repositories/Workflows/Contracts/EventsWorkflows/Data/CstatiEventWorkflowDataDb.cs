using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data;

public sealed class CstatiEventWorkflowDataDb
{
    public required CstatiEventWorkflowWaveDb[] Waves { get; init; }
    public required CstatiEventWorkflowPaymentCollectorDb[] PaymentCollectors { get; init; }
    public required bool IsCompleted { get; init; }
}

internal sealed record CstatiEventWorkflowData(CstatiEventWorkflowWave[] Waves, CstatiEventWorkflowPaymentCollector[] PaymentCollectors, bool IsCompleted);
