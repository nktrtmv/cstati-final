using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Complete.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Create.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Start.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Complete;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Create;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Delete;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Start;
using Cstati.Events.Workflows.Presentation.Controllers.Waves.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves;

internal sealed class CstatiEventsWorkflowsWavesController : CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceBase
{
    public CstatiEventsWorkflowsWavesController(IMediator mediator, ILogger<CstatiEventsWorkflowsWavesController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsWorkflowsWavesController> Logger { get; }

    public override Task<CreateCstatiEventsWorkflowsWavesCommandResponse> Create(CreateCstatiEventsWorkflowsWavesCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiEventsWorkflowsWavesCommandInternal command = CreateCstatiEventsWorkflowsWavesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CreateCstatiEventsWorkflowsWavesCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsWorkflowsWavesCommandResponse> Delete(DeleteCstatiEventsWorkflowsWavesCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsWorkflowsWavesCommandInternal command = DeleteCstatiEventsWorkflowsWavesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsWorkflowsWavesCommandResponse();
            });
    }

    public override Task<StartCstatiEventsWorkflowsWavesCommandResponse> Start(
        StartCstatiEventsWorkflowsWavesCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Start),
            request,
            async () =>
            {
                StartCstatiEventsWorkflowsWavesCommandInternal command =
                    StartCstatiEventsWorkflowsWavesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new StartCstatiEventsWorkflowsWavesCommandResponse();
            });
    }

    public override Task<CompleteCstatiEventsWorkflowsWavesCommandResponse> Complete(
        CompleteCstatiEventsWorkflowsWavesCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Complete),
            request,
            async () =>
            {
                CompleteCstatiEventsWorkflowsWavesCommandInternal command =
                    CompleteCstatiEventsWorkflowsWavesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CompleteCstatiEventsWorkflowsWavesCommandResponse();
            });
    }

    public override Task<GetAllCstatiEventsWorkflowsWavesQueryResponse> GetAll(GetAllCstatiEventsWorkflowsWavesQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsWorkflowsWavesQueryInternal command = GetAllCstatiEventsWorkflowsWavesQueryConverter.ToInternal(request);

                GetAllCstatiEventsWorkflowsWavesQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsWorkflowsWavesQueryResponse result = GetAllCstatiEventsWorkflowsWavesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
