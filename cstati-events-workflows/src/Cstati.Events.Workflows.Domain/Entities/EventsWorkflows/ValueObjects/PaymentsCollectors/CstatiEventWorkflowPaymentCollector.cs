using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;

public sealed class CstatiEventWorkflowPaymentCollector
{
    public CstatiEventWorkflowPaymentCollector(
        string personLogin,
        CstatiEventWorkflowPaymentCollectorBank preferredBank,
        string phoneNumber,
        string cardNumber,
        List<string> guestsIds)
    {
        PersonLogin = personLogin;
        PreferredBank = preferredBank;
        PhoneNumber = phoneNumber;
        CardNumber = cardNumber;
        GuestsIds = guestsIds;
    }

    public string PersonLogin { get; }
    public CstatiEventWorkflowPaymentCollectorBank PreferredBank { get; }
    public string PhoneNumber { get; }
    public string CardNumber { get; }
    public List<string> GuestsIds { get; }
}
