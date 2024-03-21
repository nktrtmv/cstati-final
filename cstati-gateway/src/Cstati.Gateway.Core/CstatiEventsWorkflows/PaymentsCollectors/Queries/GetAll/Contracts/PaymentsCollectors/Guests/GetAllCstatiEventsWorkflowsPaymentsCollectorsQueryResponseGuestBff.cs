using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts.PaymentsCollectors.Guests;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseGuestBff
{
    public required string Id { get; init; }
    public required string FullName { get; init; }
    public required CstatiEventWorkflowGuestPaymentStatusBff PaymentStatus { get; init; }
}
