using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense.Contracts;

internal static class AddExpenseCstatiEventsFinancesCommandBffConverter
{
    internal static AddExpenseCstatiEventsFinancesCommand ToDto(AddExpenseCstatiEventsFinancesCommandBff command)
    {
        var result = new AddExpenseCstatiEventsFinancesCommand
        {
            EventId = command.EventId,
            PersonLogin = command.PersonLogin,
            Description = command.Description,
            Amount = command.Amount,
            Market = command.Market,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
