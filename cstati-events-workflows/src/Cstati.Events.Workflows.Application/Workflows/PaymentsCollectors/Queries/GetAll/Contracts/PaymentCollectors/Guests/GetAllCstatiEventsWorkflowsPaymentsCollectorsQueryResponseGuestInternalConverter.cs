using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors.Guests;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal FromDomain(CstatiEventWorkflowGuest guest)
    {
        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatus =
            CstatiEventWorkflowGuestPaymentStatusInternalConverter.FromDomain(guest.PaymentInfo.Status);

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal(guest.Id, guest.FullName, paymentStatus);

        return result;
    }
}
