using Cstati.Accounts.Application.Accounts.Commands.AddAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;
using Cstati.Accounts.Application.Accounts.Commands.Create.Contracts;
using Cstati.Accounts.Application.Accounts.Commands.Delete.Contracts;
using Cstati.Accounts.Application.Accounts.Commands.DeleteAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;
using Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;
using Cstati.Accounts.GenericSubdomain.Tracing;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.AddAccess;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Authorize;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Create;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Delete;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.DeleteAccess;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.Get;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.GetAll;

using Grpc.Core;

using MediatR;

namespace Cstati.Accounts.Presentation.Controllers.Accounts;

internal sealed class CstatiAccountsController : CstatiAccountsService.CstatiAccountsServiceBase
{
    public CstatiAccountsController(IMediator mediator, ILogger<CstatiAccountsController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiAccountsController> Logger { get; }

    public override Task<CreateCstatiAccountsCommandResponse> Create(CreateCstatiAccountsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Create),
            request,
            async () =>
            {
                CreateCstatiAccountsCommandInternal command = CreateCstatiAccountsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new CreateCstatiAccountsCommandResponse();
            });
    }

    public override Task<DeleteCstatiAccountsCommandResponse> Delete(DeleteCstatiAccountsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Delete),
            request,
            async () =>
            {
                DeleteCstatiAccountsCommandInternal command = DeleteCstatiAccountsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteCstatiAccountsCommandResponse();
            });
    }

    public override Task<AddAccessCstatiAccountsCommandResponse> AddAccess(AddAccessCstatiAccountsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(AddAccess),
            request,
            async () =>
            {
                AddAccessCstatiAccountsCommandInternal command = AddAccessCstatiAccountsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new AddAccessCstatiAccountsCommandResponse();
            });
    }

    public override Task<DeleteAccessCstatiAccountsCommandResponse> DeleteAccess(DeleteAccessCstatiAccountsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(DeleteAccess),
            request,
            async () =>
            {
                DeleteAccessCstatiAccountsCommandInternal command = DeleteAccessCstatiAccountsCommandConverter.ToInternal(request);

                await Mediator.Send(command, context.CancellationToken);

                return new DeleteAccessCstatiAccountsCommandResponse();
            });
    }

    public override Task<AuthorizeCstatiAccountsCommandResponse> Authorize(AuthorizeCstatiAccountsCommand request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Authorize),
            request,
            async () =>
            {
                AuthorizeCstatiAccountsCommandInternal command = AuthorizeCstatiAccountsCommandConverter.ToInternal(request);

                AuthorizeCstatiAccountsCommandResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                AuthorizeCstatiAccountsCommandResponse result = AuthorizeCstatiAccountsCommandResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override Task<GetCstatiAccountsQueryResponse> Get(GetCstatiAccountsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(Get),
            request,
            async () =>
            {
                GetCstatiAccountsQueryInternal command = GetCstatiAccountsQueryConverter.ToInternal(request);

                GetCstatiAccountsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetCstatiAccountsQueryResponse result = GetCstatiAccountsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }

    public override Task<GetAllCstatiAccountsQueryResponse> GetAll(GetAllCstatiAccountsQuery request, ServerCallContext context)
    {
        return TracingFacility.TraceGrpc(
            Logger,
            nameof(GetAll),
            request,
            async () =>
            {
                GetAllCstatiAccountsQueryInternal command = GetAllCstatiAccountsQueryConverter.ToInternal(request);

                GetAllCstatiAccountsQueryResponseInternal response = await Mediator.Send(command, context.CancellationToken);

                GetAllCstatiAccountsQueryResponse result = GetAllCstatiAccountsQueryResponseConverter.FromInternal(response);

                return result;
            });
    }
}
