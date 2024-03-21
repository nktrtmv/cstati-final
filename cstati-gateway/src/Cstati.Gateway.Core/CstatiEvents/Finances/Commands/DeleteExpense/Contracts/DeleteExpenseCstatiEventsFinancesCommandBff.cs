namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;

public sealed class DeleteExpenseCstatiEventsFinancesCommandBff
{
    public required string EventId { get; init; }
    public required string ExpenseId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
