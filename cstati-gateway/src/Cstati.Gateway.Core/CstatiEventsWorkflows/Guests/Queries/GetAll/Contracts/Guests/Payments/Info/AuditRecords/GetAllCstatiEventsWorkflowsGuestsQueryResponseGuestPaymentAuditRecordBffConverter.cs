using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info.AuditRecords;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBffConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBff FromDto(
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecord record)
    {
        var dateTime = record.Date.ToDateTime();

        CstatiEventWorkflowGuestPaymentStatusBff statusChangeTo =
            CstatiEventWorkflowGuestPaymentStatusBffConverter.FromDto(record.StatusChangedTo);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBff
        {
            Date = dateTime,
            StatusChangedTo = statusChangeTo
        };

        return result;
    }
}
