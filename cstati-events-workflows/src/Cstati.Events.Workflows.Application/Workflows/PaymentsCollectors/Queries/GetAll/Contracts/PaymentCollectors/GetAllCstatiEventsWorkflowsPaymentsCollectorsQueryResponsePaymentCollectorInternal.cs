using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors.Guests;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal
{
    internal GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal(
        string personLogin,
        CstatiEventWorkflowPaymentCollectorBankInternal preferredBank,
        string phoneNumber,
        string cardNumber,
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal[] guests)
    {
        PersonLogin = personLogin;
        PreferredBank = preferredBank;
        PhoneNumber = phoneNumber;
        CardNumber = cardNumber;
        Guests = guests;
    }

    public string PersonLogin { get; }
    public CstatiEventWorkflowPaymentCollectorBankInternal PreferredBank { get; }
    public string PhoneNumber { get; }
    public string CardNumber { get; }
    public GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal[] Guests { get; }
}
