using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;

public sealed class GetDetailsCstatiEventsFinancesQueryResponseInternal
{
    public GetDetailsCstatiEventsFinancesQueryResponseInternal(
        double collected,
        double currentBalance,
        GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal[] expenses,
        double? revenue,
        ConcurrencyToken concurrencyToken)
    {
        Collected = collected;
        CurrentBalance = currentBalance;
        Expenses = expenses;
        Revenue = revenue;
        ConcurrencyToken = concurrencyToken;
    }

    public double Collected { get; }
    public double CurrentBalance { get; }
    public GetDetailsCstatiEventsFinancesQueryResponseExpenseInternal[] Expenses { get; }
    public double? Revenue { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
