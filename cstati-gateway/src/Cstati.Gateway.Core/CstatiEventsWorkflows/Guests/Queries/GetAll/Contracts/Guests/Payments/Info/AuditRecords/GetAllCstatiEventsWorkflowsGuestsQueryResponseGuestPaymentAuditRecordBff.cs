using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info.AuditRecords;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentAuditRecordBff
{
    public required DateTime Date { get; init; }
    public required CstatiEventWorkflowGuestPaymentStatusBff StatusChangedTo { get; init; }
}
