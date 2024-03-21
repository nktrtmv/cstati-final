using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts;

public sealed class GetDetailsCstatiEventsFinancesQueryResponseBff
{
    public required double Collected { get; init; }
    public required double CurrentBalance { get; init; }
    public required GetDetailsCstatiEventsFinancesQueryResponseExpenseBff[] Expenses { get; init; }
    public required double? Revenue { get; init; }
    public required string ConcurrencyToken { get; init; }
}
