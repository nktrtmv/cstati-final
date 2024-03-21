using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense.Contracts;

public sealed class AddExpenseCstatiEventsFinancesCommandInternal : IRequest
{
    public AddExpenseCstatiEventsFinancesCommandInternal(
        string eventId,
        string personLogin,
        string description,
        double amount,
        string market,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        PersonLogin = personLogin;
        Description = description;
        Amount = amount;
        Market = market;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string PersonLogin { get; }
    internal string Description { get; }
    internal double Amount { get; }
    internal string Market { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
