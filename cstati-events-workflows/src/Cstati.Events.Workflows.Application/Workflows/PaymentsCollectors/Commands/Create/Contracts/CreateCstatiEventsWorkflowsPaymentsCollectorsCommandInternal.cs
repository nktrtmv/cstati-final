using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Create.Contracts;

public sealed class CreateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal : IRequest
{
    public CreateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal(
        string eventId,
        string personLogin,
        CstatiEventWorkflowPaymentCollectorBankInternal preferredBank,
        string phoneNumber,
        string cardNumber,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        PersonLogin = personLogin;
        PreferredBank = preferredBank;
        PhoneNumber = phoneNumber;
        CardNumber = cardNumber;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string PersonLogin { get; }
    internal CstatiEventWorkflowPaymentCollectorBankInternal PreferredBank { get; }
    internal string PhoneNumber { get; }
    internal string CardNumber { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
