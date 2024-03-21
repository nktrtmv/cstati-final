using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEventsWorkflows.PaymentsCollectors;

[Route("events/workflows/payments-collectors/[Action]")]
[ApiController]
public sealed class CstatiEventsWorkflowsPaymentsCollectorsController : ControllerBase
{
    public CstatiEventsWorkflowsPaymentsCollectorsController(
        CreateCstatiEventsWorkflowsPaymentsCollectorsService createCstatiEventsWorkflowsPaymentsCollectorsService,
        DeleteCstatiEventsWorkflowsPaymentsCollectorsService deleteCstatiEventsWorkflowsPaymentsCollectorsService,
        UpdateCstatiEventsWorkflowsPaymentsCollectorsService updateCstatiEventsWorkflowsPaymentsCollectorsService,
        GetAllCstatiEventsWorkflowsPaymentsCollectorsService getAllCstatiEventsWorkflowsPaymentsCollectorsService)
    {
        CreateCstatiEventsWorkflowsPaymentsCollectorsService = createCstatiEventsWorkflowsPaymentsCollectorsService;
        DeleteCstatiEventsWorkflowsPaymentsCollectorsService = deleteCstatiEventsWorkflowsPaymentsCollectorsService;
        UpdateCstatiEventsWorkflowsPaymentsCollectorsService = updateCstatiEventsWorkflowsPaymentsCollectorsService;
        GetAllCstatiEventsWorkflowsPaymentsCollectorsService = getAllCstatiEventsWorkflowsPaymentsCollectorsService;
    }

    private CreateCstatiEventsWorkflowsPaymentsCollectorsService CreateCstatiEventsWorkflowsPaymentsCollectorsService { get; }
    private DeleteCstatiEventsWorkflowsPaymentsCollectorsService DeleteCstatiEventsWorkflowsPaymentsCollectorsService { get; }
    private UpdateCstatiEventsWorkflowsPaymentsCollectorsService UpdateCstatiEventsWorkflowsPaymentsCollectorsService { get; }
    private GetAllCstatiEventsWorkflowsPaymentsCollectorsService GetAllCstatiEventsWorkflowsPaymentsCollectorsService { get; }

    [HttpPost]
    public Task<CreateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Create(
        [FromBody] CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBff command,
        CancellationToken cancellationToken)
    {
        return CreateCstatiEventsWorkflowsPaymentsCollectorsService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Delete(
        [FromBody] DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBff command,
        CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsWorkflowsPaymentsCollectorsService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Update(
        [FromBody] UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandBff command,
        CancellationToken cancellationToken)
    {
        return UpdateCstatiEventsWorkflowsPaymentsCollectorsService.Update(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff> GetAll(
        [FromBody] GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryBff query,
        CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsWorkflowsPaymentsCollectorsService.GetAll(query, cancellationToken);
    }
}
