using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;

internal static class DeleteExpenseCstatiEventsFinancesCommandBffConverter
{
    internal static DeleteExpenseCstatiEventsFinancesCommand ToDto(DeleteExpenseCstatiEventsFinancesCommandBff command)
    {
        var result = new DeleteExpenseCstatiEventsFinancesCommand
        {
            EventId = command.EventId,
            ExpenseId = command.ExpenseId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
