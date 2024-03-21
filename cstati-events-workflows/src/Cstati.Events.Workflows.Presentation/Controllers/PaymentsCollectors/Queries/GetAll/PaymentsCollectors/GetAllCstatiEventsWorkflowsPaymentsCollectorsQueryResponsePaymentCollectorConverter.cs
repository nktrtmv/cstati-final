using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll.PaymentsCollectors.Guests;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll.PaymentsCollectors;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollector FromInternal(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal paymentCollector)
    {
        CstatiEventWorkflowPaymentCollectorBankDto preferredBank =
            CstatiEventWorkflowPaymentCollectorBankDtoConverter.FromInternal(paymentCollector.PreferredBank);

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuest[] guests =
            paymentCollector.Guests.Select(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestConverter.FromInternal).ToArray();

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollector
        {
            PersonLogin = paymentCollector.PersonLogin,
            PreferredBank = preferredBank,
            PhoneNumber = paymentCollector.PhoneNumber,
            CardNumber = paymentCollector.CardNumber,
            Guests = { guests }
        };

        return result;
    }
}
