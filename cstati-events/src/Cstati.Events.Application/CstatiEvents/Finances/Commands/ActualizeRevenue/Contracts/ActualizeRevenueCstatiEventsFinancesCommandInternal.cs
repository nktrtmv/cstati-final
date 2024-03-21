using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;

public sealed class ActualizeRevenueCstatiEventsFinancesCommandInternal : IRequest
{
    public ActualizeRevenueCstatiEventsFinancesCommandInternal(string eventId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
