using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info.AuditRecords;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBff
{
    public required CstatiEventWorkflowGuestPaymentStatusBff Status { get; init; }
    public required GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBff[] AuditRecords { get; init; }
}
