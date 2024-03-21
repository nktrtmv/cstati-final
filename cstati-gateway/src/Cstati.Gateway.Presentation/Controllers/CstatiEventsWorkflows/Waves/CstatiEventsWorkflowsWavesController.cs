using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEventsWorkflows.Waves;

[Route("events/workflows/waves/[Action]")]
[ApiController]
public sealed class CstatiEventsWorkflowsWavesController : ControllerBase
{
    public CstatiEventsWorkflowsWavesController(
        CreateCstatiEventsWorkflowsWavesService createCstatiEventsWorkflowsWavesService,
        DeleteCstatiEventsWorkflowsWavesService deleteCstatiEventsWorkflowsWavesService,
        CompleteCstatiEventsWorkflowsWavesService finishCstatiEventsWorkflowsWavesService,
        StartCstatiEventsWorkflowsWavesService startCstatiEventsWorkflowsWavesService,
        GetAllCstatiEventsWorkflowsWavesService getAllCstatiEventsWorkflowsWavesService)
    {
        CreateCstatiEventsWorkflowsWavesService = createCstatiEventsWorkflowsWavesService;
        DeleteCstatiEventsWorkflowsWavesService = deleteCstatiEventsWorkflowsWavesService;
        CompleteCstatiEventsWorkflowsWavesService = finishCstatiEventsWorkflowsWavesService;
        StartCstatiEventsWorkflowsWavesService = startCstatiEventsWorkflowsWavesService;
        GetAllCstatiEventsWorkflowsWavesService = getAllCstatiEventsWorkflowsWavesService;
    }

    private CreateCstatiEventsWorkflowsWavesService CreateCstatiEventsWorkflowsWavesService { get; }
    private DeleteCstatiEventsWorkflowsWavesService DeleteCstatiEventsWorkflowsWavesService { get; }
    private CompleteCstatiEventsWorkflowsWavesService CompleteCstatiEventsWorkflowsWavesService { get; }
    private StartCstatiEventsWorkflowsWavesService StartCstatiEventsWorkflowsWavesService { get; }
    private GetAllCstatiEventsWorkflowsWavesService GetAllCstatiEventsWorkflowsWavesService { get; }

    [HttpPost]
    public Task<CreateCstatiEventsWorkflowsWavesCommandResponseBff> Create(
        [FromBody] CreateCstatiEventsWorkflowsWavesCommandBff command,
        CancellationToken cancellationToken)
    {
        return CreateCstatiEventsWorkflowsWavesService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsWorkflowsWavesCommandResponseBff> Delete(
        [FromBody] DeleteCstatiEventsWorkflowsWavesCommandBff command,
        CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsWorkflowsWavesService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<StartCstatiEventsWorkflowsWavesCommandResponseBff> Start(
        [FromBody] StartCstatiEventsWorkflowsWavesCommandBff command,
        CancellationToken cancellationToken)
    {
        return StartCstatiEventsWorkflowsWavesService.Start(command, cancellationToken);
    }

    [HttpPost]
    public Task<CompleteCstatiEventsWorkflowsWavesCommandResponseBff> Complete(
        [FromBody] CompleteCstatiEventsWorkflowsWavesCommandBff command,
        CancellationToken cancellationToken)
    {
        return CompleteCstatiEventsWorkflowsWavesService.Complete(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsWorkflowsWavesQueryResponseBff> GetAll([FromBody] GetAllCstatiEventsWorkflowsWavesQueryBff query, CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsWorkflowsWavesService.GetAll(query, cancellationToken);
    }
}
