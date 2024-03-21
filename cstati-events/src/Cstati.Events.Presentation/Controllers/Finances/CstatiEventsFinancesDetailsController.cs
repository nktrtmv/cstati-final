using Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;
using Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense.Contracts;
using Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;
using Cstati.Events.Application.CstatiEvents.Finances.Queries.GetDetails.Contracts;
using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.ActualizeRevenue;
using Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.AddExpense;
using Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.DeleteExpense;
using Cstati.Events.Presentation.Controllers.Finances.Converters.Queries.GetDetails;

using Grpc.Core;

using MediatR;

namespace Cstati.Events.Presentation.Controllers.Finances;

internal sealed class CstatiEventsFinancesDetailsController : CstatiEventsFinancesService.CstatiEventsFinancesServiceBase
{
    public CstatiEventsFinancesDetailsController(IMediator mediator, ILogger<CstatiEventsFinancesDetailsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsFinancesDetailsController> Logger { get; }

    public override Task<AddExpenseCstatiEventsFinancesCommandResponse> AddExpense(AddExpenseCstatiEventsFinancesCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(AddExpense),
            request,
            async () =>
            {
                AddExpenseCstatiEventsFinancesCommandInternal command = AddExpenseCstatiEventsFinancesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new AddExpenseCstatiEventsFinancesCommandResponse();
            });
    }

    public override Task<DeleteExpenseCstatiEventsFinancesCommandResponse> DeleteExpense(DeleteExpenseCstatiEventsFinancesCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(DeleteExpense),
            request,
            async () =>
            {
                DeleteExpenseCstatiEventsFinancesCommandInternal command = DeleteExpenseCstatiEventsFinancesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteExpenseCstatiEventsFinancesCommandResponse();
            });
    }

    public override Task<ActualizeRevenueCstatiEventsFinancesCommandResponse> ActualizeRevenue(
        ActualizeRevenueCstatiEventsFinancesCommand request,
        ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(ActualizeRevenue),
            request,
            async () =>
            {
                ActualizeRevenueCstatiEventsFinancesCommandInternal command = ActualizeRevenueCstatiEventsFinancesCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new ActualizeRevenueCstatiEventsFinancesCommandResponse();
            });
    }

    public override Task<GetDetailsCstatiEventsFinancesQueryResponse> GetDetails(GetDetailsCstatiEventsFinancesQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetDetails),
            request,
            async () =>
            {
                GetDetailsCstatiEventsFinancesQueryInternal command = GetDetailsCstatiEventsFinancesQueryConverter.ToInternal(request);

                GetDetailsCstatiEventsFinancesQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetDetailsCstatiEventsFinancesQueryResponse result = GetDetailsCstatiEventsFinancesQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
