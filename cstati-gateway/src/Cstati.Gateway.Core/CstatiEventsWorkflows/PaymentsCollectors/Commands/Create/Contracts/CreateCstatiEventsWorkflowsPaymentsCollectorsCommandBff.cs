using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create.Contracts;

public sealed class CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBff
{
    public required string EventId { get; init; }
    public required string PersonLogin { get; init; }
    public required CstatiEventWorkflowPaymentCollectorBankBff PreferredBank { get; init; }
    public required string PhoneNumber { get; init; }
    public required string CardNumber { get; init; }
    public required string ConcurrencyToken { get; init; }
}
