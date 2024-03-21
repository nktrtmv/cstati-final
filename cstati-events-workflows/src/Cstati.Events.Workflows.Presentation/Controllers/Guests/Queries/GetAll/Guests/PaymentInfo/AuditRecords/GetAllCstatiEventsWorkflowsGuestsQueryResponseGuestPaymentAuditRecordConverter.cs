using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments.AuditRecords;
using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests.PaymentInfo.AuditRecords;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecord FromInternal(
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordInternal auditRecord)
    {
        Timestamp date = UtcDateTimeConverterTo.ToTimeStamp(auditRecord.Date);

        CstatiEventWorkflowGuestPaymentStatusDto statusChangeTo =
            CstatiEventWorkflowGuestPaymentStatusDtoConverter.FromInternal(auditRecord.StatusChangedTo);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecord
        {
            Date = date,
            StatusChangedTo = statusChangeTo
        };

        return result;
    }
}
