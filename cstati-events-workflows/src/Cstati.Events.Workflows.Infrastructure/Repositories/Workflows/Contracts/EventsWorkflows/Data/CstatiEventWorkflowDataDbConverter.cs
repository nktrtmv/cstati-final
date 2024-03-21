using System.Text.Json;

using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data;

internal static class CstatiEventWorkflowDataDbConverter
{
    internal static string FromDomain(CstatiEventWorkflowData data)
    {
        CstatiEventWorkflowWaveDb[] waves = data.Waves.Select(CstatiEventWorkflowWaveDbConverter.FromDomain).ToArray();

        CstatiEventWorkflowPaymentCollectorDb[] paymentCollectors =
            data.PaymentCollectors.Select(CstatiEventWorkflowPaymentCollectorDbConverter.FromDomain).ToArray();

        var dataDb = new CstatiEventWorkflowDataDb
        {
            Waves = waves,
            PaymentCollectors = paymentCollectors,
            IsCompleted = data.IsCompleted
        };

        string result = JsonSerializer.Serialize(dataDb);

        return result;
    }

    internal static CstatiEventWorkflowData ToDomain(string json)
    {
        var data = JsonSerializer.Deserialize<CstatiEventWorkflowDataDb>(json)!;

        CstatiEventWorkflowWave[] waves = data.Waves.Select(CstatiEventWorkflowWaveDbConverter.ToDomain).ToArray();

        CstatiEventWorkflowPaymentCollector[] paymentCollectors = data.PaymentCollectors.Select(CstatiEventWorkflowPaymentCollectorDbConverter.ToDomain).ToArray();

        var result = new CstatiEventWorkflowData(waves, paymentCollectors, data.IsCompleted);

        return result;
    }
}
