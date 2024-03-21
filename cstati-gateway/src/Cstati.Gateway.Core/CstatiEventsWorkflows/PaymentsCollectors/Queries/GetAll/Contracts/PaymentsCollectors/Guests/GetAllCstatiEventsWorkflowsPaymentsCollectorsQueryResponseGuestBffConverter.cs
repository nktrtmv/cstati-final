using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors.Guests;

internal static class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBffConverter
{
    internal static GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBff FromDto(GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuest guest)
    {
        CstatiEventWorkflowGuestPaymentStatusBff paymentStatus = CstatiEventWorkflowGuestPaymentStatusBffConverter.FromDto(guest.PaymentStatus);

        var result = new GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBff
        {
            Id = guest.Id,
            FullName = guest.FullName,
            PaymentStatus = paymentStatus
        };

        return result;
    }
}
