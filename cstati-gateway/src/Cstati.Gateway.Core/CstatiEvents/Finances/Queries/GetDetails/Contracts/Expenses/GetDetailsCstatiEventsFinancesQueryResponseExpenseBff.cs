using Cstati.Gateway.Core.Common.Persons;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts.Expenses;

public sealed class GetDetailsCstatiEventsFinancesQueryResponseExpenseBff
{
    public required string Id { get; init; }
    public required PersonBff Person { get; init; }
    public required string Description { get; init; }
    public required double Amount { get; init; }
    public required string Market { get; init; }
}
