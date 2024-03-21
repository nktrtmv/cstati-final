using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEvents.Tasks;

[Route("events/tasks/[Action]")]
[ApiController]
public sealed class CstatiEventsTasksController : ControllerBase
{
    public CstatiEventsTasksController(
        CreateCstatiEventsTasksService createCstatiEventsTasksService,
        DeleteCstatiEventsTasksService deleteCstatiEventsTasksService,
        UpdateCstatiEventsTasksService updateCstatiEventsTasksService,
        GetAllCstatiEventsTasksService getAllCstatiEventsTasksService)
    {
        CreateCstatiEventsTasksService = createCstatiEventsTasksService;
        DeleteCstatiEventsTasksService = deleteCstatiEventsTasksService;
        UpdateCstatiEventsTasksService = updateCstatiEventsTasksService;
        GetAllCstatiEventsTasksService = getAllCstatiEventsTasksService;
    }

    private CreateCstatiEventsTasksService CreateCstatiEventsTasksService { get; }
    private DeleteCstatiEventsTasksService DeleteCstatiEventsTasksService { get; }
    private UpdateCstatiEventsTasksService UpdateCstatiEventsTasksService { get; }
    private GetAllCstatiEventsTasksService GetAllCstatiEventsTasksService { get; }

    [HttpPost]
    public Task<CreateCstatiEventsTasksCommandResponseBff> Create([FromBody] CreateCstatiEventsTasksCommandBff command, CancellationToken cancellationToken)
    {
        return CreateCstatiEventsTasksService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsTasksCommandResponseBff> Delete([FromBody] DeleteCstatiEventsTasksCommandBff command, CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsTasksService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<UpdateCstatiEventsTasksCommandResponseBff> Update([FromBody] UpdateCstatiEventsTasksCommandBff command, CancellationToken cancellationToken)
    {
        return UpdateCstatiEventsTasksService.Update(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsTasksQueryResponseBff> GetAll(
        [FromBody] GetAllCstatiEventsTasksQueryBff query,
        [FromQuery] int limit,
        CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsTasksService.GetAll(query, limit, cancellationToken);
    }
}
