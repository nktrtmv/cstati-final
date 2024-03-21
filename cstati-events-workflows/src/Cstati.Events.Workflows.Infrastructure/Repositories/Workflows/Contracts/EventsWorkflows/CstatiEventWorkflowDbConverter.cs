using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows;

internal static class CstatiEventWorkflowDbConverter
{
    internal static CstatiEventWorkflowDb FromDomain(CstatiEventWorkflow workflow)
    {
        var data = new CstatiEventWorkflowData(workflow.Waves, workflow.PaymentCollectors, workflow.IsCompleted);

        string dataDb = CstatiEventWorkflowDataDbConverter.FromDomain(data);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(workflow.ConcurrencyToken);

        var result = new CstatiEventWorkflowDb
        {
            EventId = workflow.EventId,
            Data = dataDb,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    internal static CstatiEventWorkflow ToDomain(CstatiEventWorkflowDb workflow)
    {
        CstatiEventWorkflowData data = CstatiEventWorkflowDataDbConverter.ToDomain(workflow.Data);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromUnspecifiedUtcDateTime(workflow.ConcurrencyToken);

        var result = new CstatiEventWorkflow(workflow.EventId, data.Waves, data.PaymentCollectors, data.IsCompleted, concurrencyToken);

        return result;
    }
}
