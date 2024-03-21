using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.Statuses;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo.AuditRecords;

public sealed class CstatiEventWorkflowGuestPaymentAuditRecordDb
{
    public required UtcDateTime Date { get; init; }
    public required CstatiEventWorkflowGuestPaymentStatusDb StatusChangedTo { get; init; }
}
