using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;

public sealed class GetDetailsCstatiEventsFinancesQueryInternal : IRequest<GetDetailsCstatiEventsFinancesQueryResponseInternal>
{
    public GetDetailsCstatiEventsFinancesQueryInternal(string eventId, int expensesLimit)
    {
        EventId = eventId;
        ExpensesLimit = expensesLimit;
    }

    internal string EventId { get; }
    internal int ExpensesLimit { get; }
}
