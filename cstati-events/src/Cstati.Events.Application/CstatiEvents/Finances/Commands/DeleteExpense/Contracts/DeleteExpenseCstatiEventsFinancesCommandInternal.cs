using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;

public sealed class DeleteExpenseCstatiEventsFinancesCommandInternal : IRequest
{
    public DeleteExpenseCstatiEventsFinancesCommandInternal(string eventId, string expenseId, ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        ExpenseId = expenseId;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string ExpenseId { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
