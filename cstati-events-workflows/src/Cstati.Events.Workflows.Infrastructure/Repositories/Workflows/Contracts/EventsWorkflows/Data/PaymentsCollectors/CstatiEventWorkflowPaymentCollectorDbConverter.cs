using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors.Banks;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors;

internal static class CstatiEventWorkflowPaymentCollectorDbConverter
{
    internal static CstatiEventWorkflowPaymentCollectorDb FromDomain(CstatiEventWorkflowPaymentCollector paymentCollector)
    {
        CstatiEventWorkflowPaymentCollectorBankDb preferredBank = CstatiEventWorkflowPaymentCollectorBankDbConverter.FromDomain(paymentCollector.PreferredBank);

        var result = new CstatiEventWorkflowPaymentCollectorDb
        {
            PersonLogin = paymentCollector.PersonLogin,
            PreferredBank = preferredBank,
            PhoneNumber = paymentCollector.PhoneNumber,
            CardNumber = paymentCollector.CardNumber,
            GuestsIds = paymentCollector.GuestsIds.ToArray()
        };

        return result;
    }

    internal static CstatiEventWorkflowPaymentCollector ToDomain(CstatiEventWorkflowPaymentCollectorDb paymentCollector)
    {
        CstatiEventWorkflowPaymentCollectorBank preferredBank = CstatiEventWorkflowPaymentCollectorBankDbConverter.ToDomain(paymentCollector.PreferredBank);

        var result = new CstatiEventWorkflowPaymentCollector(
            paymentCollector.PersonLogin,
            preferredBank,
            paymentCollector.PhoneNumber,
            paymentCollector.CardNumber,
            paymentCollector.GuestsIds.ToList());

        return result;
    }
}
