using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense;

public sealed class DeleteExpenseCstatiEventsFinancesService : CstatiEventsFinancesServiceClientBase
{
    public DeleteExpenseCstatiEventsFinancesService(CstatiEventsFinancesService.CstatiEventsFinancesServiceClient finances) : base(finances)
    {
    }

    public async Task<DeleteExpenseCstatiEventsFinancesCommandResponseBff> DeleteExpense(
        DeleteExpenseCstatiEventsFinancesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        DeleteExpenseCstatiEventsFinancesCommand command = DeleteExpenseCstatiEventsFinancesCommandBffConverter.ToDto(commandBff);

        await Finances.DeleteExpenseAsync(command, cancellationToken: cancellationToken);

        return DeleteExpenseCstatiEventsFinancesCommandResponseBff.Instance;
    }
}
