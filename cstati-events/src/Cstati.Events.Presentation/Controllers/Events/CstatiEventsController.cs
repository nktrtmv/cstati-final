using Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Commands.Delete.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;
using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;
using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Create;
using Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Delete;
using Cstati.Events.Presentation.Controllers.Events.Converters.Commands.Update;
using Cstati.Events.Presentation.Controllers.Events.Converters.Queries.Get;
using Cstati.Events.Presentation.Controllers.Events.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Presentation.Controllers.Events;

internal sealed class CstatiEventsController : CstatiEventsService.CstatiEventsServiceBase
{
    public CstatiEventsController(IMediator mediator, ILogger<CstatiEventsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsController> Logger { get; }

    public override Task<CreateCstatiEventsCommandResponse> Create(CreateCstatiEventsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiEventsCommandInternal command = CreateCstatiEventsCommandConverter.ToInternal(request);

                CreateCstatiEventsCommandResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                CreateCstatiEventsCommandResponse result = CreateCstatiEventsCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override Task<UpdateCstatiEventsCommandResponse> Update(UpdateCstatiEventsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Update),
            request,
            async () =>
            {
                UpdateCstatiEventsCommandInternal command = UpdateCstatiEventsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new UpdateCstatiEventsCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsCommandResponse> Delete(DeleteCstatiEventsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsCommandInternal command = DeleteCstatiEventsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsCommandResponse();
            });
    }

    public override Task<GetCstatiEventsQueryResponse> Get(GetCstatiEventsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Get),
            request,
            async () =>
            {
                GetCstatiEventsQueryInternal command = GetCstatiEventsQueryConverter.ToInternal(request);

                GetCstatiEventsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetCstatiEventsQueryResponse result = GetCstatiEventsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override Task<GetAllCstatiEventsQueryResponse> GetAll(GetAllCstatiEventsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsQueryInternal command = GetAllCstatiEventsQueryConverter.ToInternal(request);

                GetAllCstatiEventsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsQueryResponse result = GetAllCstatiEventsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
