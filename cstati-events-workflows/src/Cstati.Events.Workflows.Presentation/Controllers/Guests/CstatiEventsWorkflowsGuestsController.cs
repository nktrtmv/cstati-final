using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendTelegramMessages.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Add;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Delete;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.SendPaymentTelegramMessages;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.SendTelegramMessages;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Update;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests;

internal sealed class CstatiEventsWorkflowsGuestsController : CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceBase
{
    public CstatiEventsWorkflowsGuestsController(IMediator mediator, ILogger<CstatiEventsWorkflowsGuestsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsWorkflowsGuestsController> Logger { get; }

    public override Task<AddCstatiEventsWorkflowsGuestsCommandResponse> Add(AddCstatiEventsWorkflowsGuestsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Add),
            request,
            async () =>
            {
                AddCstatiEventsWorkflowsGuestsCommandInternal command = AddCstatiEventsWorkflowsGuestsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new AddCstatiEventsWorkflowsGuestsCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsWorkflowsGuestsCommandResponse> Delete(DeleteCstatiEventsWorkflowsGuestsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsWorkflowsGuestsCommandInternal command = DeleteCstatiEventsWorkflowsGuestsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsWorkflowsGuestsCommandResponse();
            });
    }

    public override Task<UpdateCstatiEventsWorkflowsGuestsCommandResponse> Update(UpdateCstatiEventsWorkflowsGuestsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateCstatiEventsWorkflowsGuestsCommandInternal command = UpdateCstatiEventsWorkflowsGuestsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new UpdateCstatiEventsWorkflowsGuestsCommandResponse();
            });
    }

    public override Task<SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponse> SendTelegramMessages(
        SendTelegramMessagesCstatiEventsWorkflowsGuestsCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(SendTelegramMessages),
            request,
            async () =>
            {
                SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal command =
                    SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponse();
            });
    }

    public override Task<SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponse> SendPaymentTelegramMessages(
        SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(SendPaymentTelegramMessages),
            request,
            async () =>
            {
                SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal command =
                    SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandResponse();
            });
    }

    public override Task<GetAllCstatiEventsWorkflowsGuestsQueryResponse> GetAll(GetAllCstatiEventsWorkflowsGuestsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsWorkflowsGuestsQueryInternal command = GetAllCstatiEventsWorkflowsGuestsQueryConverter.ToInternal(request);

                GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsWorkflowsGuestsQueryResponse result = GetAllCstatiEventsWorkflowsGuestsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
