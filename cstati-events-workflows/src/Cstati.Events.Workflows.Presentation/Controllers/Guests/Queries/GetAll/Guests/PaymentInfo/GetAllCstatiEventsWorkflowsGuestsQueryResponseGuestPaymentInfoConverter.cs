using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests.PaymentInfo.AuditRecords;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests.PaymentInfo;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfo FromInternal(
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal paymentInfo)
    {
        CstatiEventWorkflowGuestPaymentStatusDto status = CstatiEventWorkflowGuestPaymentStatusDtoConverter.FromInternal(paymentInfo.Status);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecord[] auditRecords =
            paymentInfo.AuditRecords.Select(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordConverter.FromInternal).ToArray();

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfo
        {
            Status = status,
            AuditRecords = { auditRecords }
        };

        return result;
    }
}
