using Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.AddExpense;

internal static class AddExpenseCstatiEventsFinancesCommandConverter
{
    internal static AddExpenseCstatiEventsFinancesCommandInternal ToInternal(AddExpenseCstatiEventsFinancesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new AddExpenseCstatiEventsFinancesCommandInternal(
            command.EventId,
            command.PersonLogin,
            command.Description,
            command.Amount,
            command.Market,
            concurrencyToken);

        return result;
    }
}
