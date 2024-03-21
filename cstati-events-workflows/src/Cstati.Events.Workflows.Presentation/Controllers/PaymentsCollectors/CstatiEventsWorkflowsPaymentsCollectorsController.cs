using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Create.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Update.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Create;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Delete;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Commands.Update;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors;

internal sealed class CstatiEventsWorkflowsPaymentsCollectorsController
    : CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceBase
{
    public CstatiEventsWorkflowsPaymentsCollectorsController(IMediator mediator, ILogger<CstatiEventsWorkflowsPaymentsCollectorsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsWorkflowsPaymentsCollectorsController> Logger { get; }

    public override Task<CreateCstatiEventsWorkflowsPaymentsCollectorsCommandResponse> Create(
        CreateCstatiEventsWorkflowsPaymentsCollectorsCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal command = CreateCstatiEventsWorkflowsPaymentsCollectorsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CreateCstatiEventsWorkflowsPaymentsCollectorsCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandResponse> Delete(
        DeleteCstatiEventsWorkflowsPaymentsCollectorsCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandInternal command = DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandResponse();
            });
    }

    public override Task<UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandResponse> Update(
        UpdateCstatiEventsWorkflowsPaymentsCollectorsCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal command = UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandResponse();
            });
    }

    public override Task<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse> GetAll(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQuery request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal command = GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryConverter.ToInternal(request);

                GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse result =
                    GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
