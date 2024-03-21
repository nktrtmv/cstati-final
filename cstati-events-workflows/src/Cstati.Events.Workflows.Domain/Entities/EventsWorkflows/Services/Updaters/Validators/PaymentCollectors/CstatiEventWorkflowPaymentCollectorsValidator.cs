using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.Validators.PaymentCollectors;

internal static class CstatiEventWorkflowPaymentCollectorsValidator
{
    internal static void Validate(CstatiEventWorkflowPaymentCollector[] paymentCollectors)
    {
        ValidateDuplicates(paymentCollectors);
    }

    private static void ValidateDuplicates(CstatiEventWorkflowPaymentCollector[] paymentCollectors)
    {
        string[] duplicates = paymentCollectors
            .GroupBy(c => c.PersonLogin)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();

        if (duplicates.Length > 0)
        {
            throw new ApplicationException($"Duplicates of payments collectors are found: {string.Join(", ", duplicates)}");
        }
    }
}
