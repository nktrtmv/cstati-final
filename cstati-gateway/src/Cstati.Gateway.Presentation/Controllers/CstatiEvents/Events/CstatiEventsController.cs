using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEvents.Events;

[Route("events/[Action]")]
[ApiController]
public sealed class CstatiEventsController : ControllerBase
{
    public CstatiEventsController(
        CreateCstatiEventsService createCstatiEventsService,
        UpdateCstatiEventsService updateCstatiEventsService,
        DeleteCstatiEventsService deleteCstatiEventsService,
        GetCstatiEventsService getCstatiEventsService,
        GetAllCstatiEventsService getAllCstatiEventsService)
    {
        CreateCstatiEventsService = createCstatiEventsService;
        UpdateCstatiEventsService = updateCstatiEventsService;
        DeleteCstatiEventsService = deleteCstatiEventsService;
        GetCstatiEventsService = getCstatiEventsService;
        GetAllCstatiEventsService = getAllCstatiEventsService;
    }

    private CreateCstatiEventsService CreateCstatiEventsService { get; }
    private UpdateCstatiEventsService UpdateCstatiEventsService { get; }
    private DeleteCstatiEventsService DeleteCstatiEventsService { get; }
    private GetCstatiEventsService GetCstatiEventsService { get; }
    private GetAllCstatiEventsService GetAllCstatiEventsService { get; }

    [HttpPost]
    public Task<CreateCstatiEventsCommandResponseBff> Create([FromBody] CreateCstatiEventsCommandBff command, CancellationToken cancellationToken)
    {
        return CreateCstatiEventsService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<UpdateCstatiEventsCommandResponseBff> Update([FromBody] UpdateCstatiEventsCommandBff command, CancellationToken cancellationToken)
    {
        return UpdateCstatiEventsService.Update(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsCommandResponseBff> Delete([FromBody] DeleteCstatiEventsCommandBff command, CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetCstatiEventsQueryResponseBff> Get([FromBody] GetCstatiEventsQueryBff query, CancellationToken cancellationToken)
    {
        return GetCstatiEventsService.Get(query, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsQueryResponseBff> GetAll([FromBody] GetAllCstatiEventsQueryBff query, [FromQuery] int limit, CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsService.GetAll(query, limit, cancellationToken);
    }
}
