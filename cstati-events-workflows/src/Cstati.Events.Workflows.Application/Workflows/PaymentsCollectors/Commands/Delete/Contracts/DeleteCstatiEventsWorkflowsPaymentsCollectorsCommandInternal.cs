using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Delete.Contracts;

public sealed class DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal : IRequest
{
    public DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal(string eventId, string personLogin, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        PersonLogin = personLogin;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string PersonLogin { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
