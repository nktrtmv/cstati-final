using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info.AuditRecords;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBffConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBff FromDto(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfo info)
    {
        CstatiEventWorkflowGuestPaymentStatusBff status = CstatiEventWorkflowGuestPaymentStatusBffConverter.FromDto(info.Status);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBff[] auditRecords =
            info.AuditRecords.Select(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBff
        {
            Status = status,
            AuditRecords = auditRecords
        };

        return result;
    }
}
