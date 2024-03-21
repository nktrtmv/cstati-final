using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.Factories;

public static class CstatiEventWorkflowPaymentCollectorFactory
{
    public static CstatiEventWorkflowPaymentCollector CreateFrom(
        string personLogin,
        CstatiEventWorkflowPaymentCollectorBank preferredBank,
        string phoneNumber,
        string cardNumber,
        params string[] guestsIds)
    {
        var result = new CstatiEventWorkflowPaymentCollector(personLogin, preferredBank, phoneNumber, cardNumber, guestsIds.ToList());

        return result;
    }
}
