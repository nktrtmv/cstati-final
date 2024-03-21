using Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.DeleteExpense;

internal static class DeleteExpenseCstatiEventsFinancesCommandConverter
{
    internal static DeleteExpenseCstatiEventsFinancesCommandInternal ToInternal(DeleteExpenseCstatiEventsFinancesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteExpenseCstatiEventsFinancesCommandInternal(command.EventId, command.ExpenseId, concurrencyToken);

        return result;
    }
}
