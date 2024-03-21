using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.AddExpense.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails;
using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEvents.Finances;

[Route("events/finances/[Action]")]
[ApiController]
public sealed class CstatiEventsFinancesController : ControllerBase
{
    public CstatiEventsFinancesController(
        AddExpenseCstatiEventsFinancesService addExpenseCstatiEventsFinancesService,
        DeleteExpenseCstatiEventsFinancesService deleteExpenseCstatiEventsFinancesService,
        ActualizeRevenueCstatiEventsFinancesService actualizeRevenueCstatiEventsFinancesService,
        GetDetailsCstatiEventsFinancesService getDetailsCstatiEventsFinancesService)
    {
        AddExpenseCstatiEventsFinancesService = addExpenseCstatiEventsFinancesService;
        DeleteExpenseCstatiEventsFinancesService = deleteExpenseCstatiEventsFinancesService;
        ActualizeRevenueCstatiEventsFinancesService = actualizeRevenueCstatiEventsFinancesService;
        GetDetailsCstatiEventsFinancesService = getDetailsCstatiEventsFinancesService;
    }

    private AddExpenseCstatiEventsFinancesService AddExpenseCstatiEventsFinancesService { get; }
    private DeleteExpenseCstatiEventsFinancesService DeleteExpenseCstatiEventsFinancesService { get; }
    private ActualizeRevenueCstatiEventsFinancesService ActualizeRevenueCstatiEventsFinancesService { get; }
    private GetDetailsCstatiEventsFinancesService GetDetailsCstatiEventsFinancesService { get; }

    [HttpPost]
    public Task<AddExpenseCstatiEventsFinancesCommandResponseBff> AddExpense(
        [FromBody] AddExpenseCstatiEventsFinancesCommandBff command,
        CancellationToken cancellationToken)
    {
        return AddExpenseCstatiEventsFinancesService.AddExpense(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteExpenseCstatiEventsFinancesCommandResponseBff> DeleteExpense(
        [FromBody] DeleteExpenseCstatiEventsFinancesCommandBff command,
        CancellationToken cancellationToken)
    {
        return DeleteExpenseCstatiEventsFinancesService.DeleteExpense(command, cancellationToken);
    }

    [HttpPost]
    public Task<ActualizeRevenueCstatiEventsFinancesCommandResponseBff> ActualizeRevenue(
        [FromBody] ActualizeRevenueCstatiEventsFinancesCommandBff command,
        CancellationToken cancellationToken)
    {
        return ActualizeRevenueCstatiEventsFinancesService.ActualizeRevenue(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetDetailsCstatiEventsFinancesQueryResponseBff> GetDetails(
        [FromBody] GetDetailsCstatiEventsFinancesQueryBff query,
        [FromQuery] int expensesLimit,
        CancellationToken cancellationToken)
    {
        return GetDetailsCstatiEventsFinancesService.GetDetails(query, expensesLimit, cancellationToken);
    }
}
