using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentCollectors.Guests;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll.PaymentsCollectors.Guests;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuest FromInternal(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestInternal guest)
    {
        CstatiEventWorkflowGuestPaymentStatusDto paymentStatus =
            CstatiEventWorkflowGuestPaymentStatusDtoConverter.FromInternal(guest.PaymentStatus);

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuest
        {
            Id = guest.Id,
            FullName = guest.FullName,
            PaymentStatus = paymentStatus
        };

        return result;
    }
}
