using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEventsWorkflows.Tickets;

[Route("events/workflows/tickets/[Action]")]
[ApiController]
public sealed class CstatiEventsWorkflowsTicketsController : ControllerBase
{
    public CstatiEventsWorkflowsTicketsController(
        CreateCstatiEventsWorkflowsTicketsService createCstatiEventsWorkflowsTicketsService,
        DeleteCstatiEventsWorkflowsTicketsService deleteCstatiEventsWorkflowsTicketsService,
        GetAllCstatiEventsWorkflowsTicketsService getAllCstatiEventsWorkflowsTicketsService)
    {
        CreateCstatiEventsWorkflowsTicketsService = createCstatiEventsWorkflowsTicketsService;
        DeleteCstatiEventsWorkflowsTicketsService = deleteCstatiEventsWorkflowsTicketsService;
        GetAllCstatiEventsWorkflowsTicketsService = getAllCstatiEventsWorkflowsTicketsService;
    }

    private CreateCstatiEventsWorkflowsTicketsService CreateCstatiEventsWorkflowsTicketsService { get; }
    private DeleteCstatiEventsWorkflowsTicketsService DeleteCstatiEventsWorkflowsTicketsService { get; }
    private GetAllCstatiEventsWorkflowsTicketsService GetAllCstatiEventsWorkflowsTicketsService { get; }

    [HttpPost]
    public Task<CreateCstatiEventsWorkflowsTicketsCommandResponseBff> Create(
        [FromBody] CreateCstatiEventsWorkflowsTicketsCommandBff command,
        CancellationToken cancellationToken)
    {
        return CreateCstatiEventsWorkflowsTicketsService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsWorkflowsTicketsCommandResponseBff> Delete(
        [FromBody] DeleteCstatiEventsWorkflowsTicketsCommandBff command,
        CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsWorkflowsTicketsService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsWorkflowsTicketsQueryResponseBff> GetAll(
        [FromBody] GetAllCstatiEventsWorkflowsTicketsQueryBff query,
        CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsWorkflowsTicketsService.GetAll(query, cancellationToken);
    }
}
