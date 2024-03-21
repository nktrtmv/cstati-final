using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors.Banks;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.PaymentsCollectors;

public sealed class CstatiEventWorkflowPaymentCollectorDb
{
    public required string PersonLogin { get; init; }
    public required CstatiEventWorkflowPaymentCollectorBankDb PreferredBank { get; init; }
    public required string PhoneNumber { get; init; }
    public required string CardNumber { get; init; }
    public required string[] GuestsIds { get; init; }
}
