using Cstati.Gateway.Core.Common.Persons;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Contracts.PaymentsCollectors.Banks;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors.Guests;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponsePaymentCollectorBff
{
    public required PersonBff Person { get; init; }
    public required CstatiEventWorkflowPaymentCollectorBankBff PreferredBank { get; init; }
    public required string PhoneNumber { get; init; }
    public required string CardNumber { get; init; }
    public required GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBff[] Guests { get; init; }
}
