using Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Create.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Delete.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Tickets.Commands.Create;
using Cstati.Events.Workflows.Presentation.Controllers.Tickets.Commands.Delete;
using Cstati.Events.Workflows.Presentation.Controllers.Tickets.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Controllers.Tickets;

internal sealed class CstatiEventsWorkflowsTicketsController : CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceBase
{
    public CstatiEventsWorkflowsTicketsController(IMediator mediator, ILogger<CstatiEventsWorkflowsTicketsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsWorkflowsTicketsController> Logger { get; }

    public override Task<CreateCstatiEventsWorkflowsTicketsCommandResponse> Create(CreateCstatiEventsWorkflowsTicketsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiEventsWorkflowsTicketsCommandInternal command = CreateCstatiEventsWorkflowsTicketsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CreateCstatiEventsWorkflowsTicketsCommandResponse();
            });
    }

    public override Task<DeleteCstatiEventsWorkflowsTicketsCommandResponse> Delete(DeleteCstatiEventsWorkflowsTicketsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiEventsWorkflowsTicketsCommandInternal command = DeleteCstatiEventsWorkflowsTicketsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiEventsWorkflowsTicketsCommandResponse();
            });
    }

    public override Task<GetAllCstatiEventsWorkflowsTicketsQueryResponse> GetAll(GetAllCstatiEventsWorkflowsTicketsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiEventsWorkflowsTicketsQueryInternal command = GetAllCstatiEventsWorkflowsTicketsQueryConverter.ToInternal(request);

                GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiEventsWorkflowsTicketsQueryResponse result = GetAllCstatiEventsWorkflowsTicketsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
