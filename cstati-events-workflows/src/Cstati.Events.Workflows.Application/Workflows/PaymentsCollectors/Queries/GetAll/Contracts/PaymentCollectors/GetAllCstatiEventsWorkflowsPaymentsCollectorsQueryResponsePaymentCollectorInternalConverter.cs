using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal FromDomain(
        CstatiEventWorkflowPaymentCollector paymentCollector,
        IReadOnlyDictionary<string, CstatiEventWorkflowGuest> guests)
    {
        CstatiEventWorkflowPaymentCollectorBankInternal preferredBank =
            CstatiEventWorkflowPaymentsCollectorBankInternalConverter.FromDomain(paymentCollector.PreferredBank);

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal[] guestsInternal = paymentCollector.GuestsIds
            .Select(id => guests[id])
            .Select(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternalConverter.FromDomain)
            .ToArray();

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorInternal(
            paymentCollector.PersonLogin,
            preferredBank,
            paymentCollector.PhoneNumber,
            paymentCollector.CardNumber,
            guestsInternal);

        return result;
    }
}
