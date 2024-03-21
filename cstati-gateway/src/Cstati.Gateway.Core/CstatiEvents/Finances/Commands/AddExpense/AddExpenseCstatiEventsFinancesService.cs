using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense;

public sealed class AddExpenseCstatiEventsFinancesService : CstatiEventsFinancesServiceClientBase
{
    public AddExpenseCstatiEventsFinancesService(CstatiEventsFinancesService.CstatiEventsFinancesServiceClient finances) : base(finances)
    {
    }

    public async Task<AddExpenseCstatiEventsFinancesCommandResponseBff> AddExpense(
        AddExpenseCstatiEventsFinancesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        AddExpenseCstatiEventsFinancesCommand command = AddExpenseCstatiEventsFinancesCommandBffConverter.ToDto(commandBff);

        await Finances.AddExpenseAsync(command, cancellationToken: cancellationToken);

        return AddExpenseCstatiEventsFinancesCommandResponseBff.Instance;
    }
}
