using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.SendTelegramMessages.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update.Contracts;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiEventsWorkflows.Guests;

[Route("events/workflows/guests/[Action]")]
[ApiController]
public sealed class CstatiEventsWorkflowsGuestsController : ControllerBase
{
    public CstatiEventsWorkflowsGuestsController(
        AddCstatiEventsWorkflowsGuestsService addCstatiEventsWorkflowsGuestsService,
        AddBatchCstatiEventsWorkflowsGuestsService addBatchCstatiEventsWorkflowsGuestsService,
        DeleteCstatiEventsWorkflowsGuestsService deleteCstatiEventsWorkflowsGuestsService,
        UpdateCstatiEventsWorkflowsGuestsService updateCstatiEventsWorkflowsGuestsService,
        SendTelegramMessagesCstatiEventsWorkflowsGuestsService sendTelegramMessagesCstatiEventsWorkflowsGuestsService,
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService sendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService,
        GetAllCstatiEventsWorkflowsGuestsService getAllCstatiEventsWorkflowsGuestsService)
    {
        AddCstatiEventsWorkflowsGuestsService = addCstatiEventsWorkflowsGuestsService;
        AddBatchCstatiEventsWorkflowsGuestsService = addBatchCstatiEventsWorkflowsGuestsService;
        DeleteCstatiEventsWorkflowsGuestsService = deleteCstatiEventsWorkflowsGuestsService;
        UpdateCstatiEventsWorkflowsGuestsService = updateCstatiEventsWorkflowsGuestsService;
        SendTelegramMessagesCstatiEventsWorkflowsGuestsService = sendTelegramMessagesCstatiEventsWorkflowsGuestsService;
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService = sendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService;
        GetAllCstatiEventsWorkflowsGuestsService = getAllCstatiEventsWorkflowsGuestsService;
    }

    private AddCstatiEventsWorkflowsGuestsService AddCstatiEventsWorkflowsGuestsService { get; }
    private AddBatchCstatiEventsWorkflowsGuestsService AddBatchCstatiEventsWorkflowsGuestsService { get; }
    private DeleteCstatiEventsWorkflowsGuestsService DeleteCstatiEventsWorkflowsGuestsService { get; }
    private UpdateCstatiEventsWorkflowsGuestsService UpdateCstatiEventsWorkflowsGuestsService { get; }
    private SendTelegramMessagesCstatiEventsWorkflowsGuestsService SendTelegramMessagesCstatiEventsWorkflowsGuestsService { get; }
    private SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService { get; }
    private GetAllCstatiEventsWorkflowsGuestsService GetAllCstatiEventsWorkflowsGuestsService { get; }

    [HttpPost]
    public Task<AddCstatiEventsWorkflowsGuestsCommandResponseBff> Add([FromBody] AddCstatiEventsWorkflowsGuestsCommandBff command, CancellationToken cancellationToken)
    {
        return AddCstatiEventsWorkflowsGuestsService.Add(command, cancellationToken);
    }

    [HttpPost]
    public Task<AddBatchCstatiEventsWorkflowsGuestsCommandResponseBff> AddBatch(
        [FromForm] AddBatchCstatiEventsWorkflowsGuestsCommandBff command,
        CancellationToken cancellationToken)
    {
        return AddBatchCstatiEventsWorkflowsGuestsService.AddBatch(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiEventsWorkflowsGuestsCommandResponseBff> Delete(
        [FromBody] DeleteCstatiEventsWorkflowsGuestsCommandBff command,
        CancellationToken cancellationToken)
    {
        return DeleteCstatiEventsWorkflowsGuestsService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<UpdateCstatiEventsWorkflowsGuestsCommandResponseBff> Update(
        [FromBody] UpdateCstatiEventsWorkflowsGuestsCommandBff command,
        CancellationToken cancellationToken)
    {
        return UpdateCstatiEventsWorkflowsGuestsService.Update(command, cancellationToken);
    }

    [HttpPost]
    public Task<SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff> SendTelegramMessages(
        [FromBody] SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff command,
        CancellationToken cancellationToken)
    {
        return SendTelegramMessagesCstatiEventsWorkflowsGuestsService.SendTelegramMessages(command, cancellationToken);
    }

    [HttpPost]
    public Task<SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponseBff> SendPaymentTelegramMessages(
        [FromBody] SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandBff command,
        CancellationToken cancellationToken)
    {
        return SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsService.SendPaymentTelegramMessages(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiEventsWorkflowsGuestsQueryResponseBff> GetAll([FromBody] GetAllCstatiEventsWorkflowsGuestsQueryBff query, CancellationToken cancellationToken)
    {
        return GetAllCstatiEventsWorkflowsGuestsService.GetAll(query, cancellationToken);
    }
}
