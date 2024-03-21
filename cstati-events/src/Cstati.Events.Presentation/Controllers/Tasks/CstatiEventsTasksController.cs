using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;
using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Create;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Delete;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Update;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Presentation.Controllers.Tasks;

internal sealed class CstatiEventsTasksController : CstatiEventsTasksService.CstatiEventsTasksServiceBase
{
    public CstatiEventsTasksController(IMediator mediator, ILogger<CstatiEventsTasksController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsTasksController> Logger { get; }

    public override Task<CreateCstatiEventsTasksCommandResponse> Create(CreateCstatiEventsTasksCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiEventsTasksCommandInternal command = CreateCstatiEventsTasksCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CreateCstatiEventsTasksCommandResponse();
            });
    }

    public override Task<UpdateCstatiEventsTasksCommandResponse> Update(UpdateCstatiEventsTasksCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateCstatiEventsTasksCommandInternal command = UpdateCstatiEventsTasksCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new UpdateCstatiEventsTasksCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsTasksCommandResponse> Delete(DeleteCstatiEventsTasksCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsTasksCommandInternal command = DeleteCstatiEventsTasksCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsTasksCommandResponse();
            });
    }

    public override Task<GetAllCstatiEventsTasksQueryResponse> GetAll(GetAllCstatiEventsTasksQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsTasksQueryInternal command = GetAllCstatiEventsTasksQueryConverter.ToInternal(request);

                GetAllCstatiEventsTasksQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsTasksQueryResponse result = GetAllCstatiEventsTasksQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
