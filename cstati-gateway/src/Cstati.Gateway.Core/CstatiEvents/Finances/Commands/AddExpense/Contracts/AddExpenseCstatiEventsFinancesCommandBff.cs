namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense.Contracts;

public sealed class AddExpenseCstatiEventsFinancesCommandBff
{
    public required string EventId { get; init; }
    public required string PersonLogin { get; init; }
    public required string Description { get; init; }
    public required double Amount { get; init; }
    public required string Market { get; init; }
    public required string ConcurrencyToken { get; init; }
}
