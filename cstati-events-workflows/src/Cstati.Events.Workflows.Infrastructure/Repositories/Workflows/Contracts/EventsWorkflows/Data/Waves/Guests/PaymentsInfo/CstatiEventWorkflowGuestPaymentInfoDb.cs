using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.AuditRecords;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo;

public sealed class CstatiEventWorkflowGuestPaymentInfoDb
{
    public required CstatiEventWorkflowGuestPaymentStatusDb Status { get; init; }
    public required CstatiEventWorkflowGuestPaymentAuditRecordDb[] AuditRecords { get; init; }
}
