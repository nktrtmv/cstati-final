using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess.Contracts;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize.Contracts;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create.Contracts;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete.Contracts;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess.Contracts;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll.Contracts;

using Microsoft.AspNetCore.Mvc;

namespace Cstati.Gateway.Presentation.Controllers.CstatiAccounts.Accounts;

[Route("accounts/[Action]")]
[ApiController]
public sealed class CstatiAccountsController : ControllerBase
{
    public CstatiAccountsController(
        AddAccessCstatiAccountsService addAccessCstatiAccountsService,
        AuthorizeCstatiAccountsService authorizeCstatiAccountsService,
        CreateCstatiAccountsService createCstatiAccountsService,
        DeleteCstatiAccountsService deleteCstatiAccountsService,
        DeleteAccessCstatiAccountsService deleteAccessCstatiAccountsService,
        GetAllCstatiAccountsService getAllCstatiAccountsService)
    {
        AddAccessCstatiAccountsService = addAccessCstatiAccountsService;
        AuthorizeCstatiAccountsService = authorizeCstatiAccountsService;
        CreateCstatiAccountsService = createCstatiAccountsService;
        DeleteCstatiAccountsService = deleteCstatiAccountsService;
        DeleteAccessCstatiAccountsService = deleteAccessCstatiAccountsService;
        GetAllCstatiAccountsService = getAllCstatiAccountsService;
    }

    private AuthorizeCstatiAccountsService AuthorizeCstatiAccountsService { get; }
    private CreateCstatiAccountsService CreateCstatiAccountsService { get; }
    private DeleteCstatiAccountsService DeleteCstatiAccountsService { get; }
    private AddAccessCstatiAccountsService AddAccessCstatiAccountsService { get; }
    private DeleteAccessCstatiAccountsService DeleteAccessCstatiAccountsService { get; }
    private GetAllCstatiAccountsService GetAllCstatiAccountsService { get; }

    [HttpPost]
    public Task<AuthorizeCstatiAccountsCommandResponseBff> Authorize([FromBody] AuthorizeCstatiAccountsCommandBff command, CancellationToken cancellationToken)
    {
        return AuthorizeCstatiAccountsService.Authorize(command, cancellationToken);
    }

    [HttpPost]
    public Task<CreateCstatiAccountsCommandResponseBff> Create([FromBody] CreateCstatiAccountsCommandBff command, CancellationToken cancellationToken)
    {
        return CreateCstatiAccountsService.Create(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteCstatiAccountsCommandResponseBff> Delete([FromBody] DeleteCstatiAccountsCommandBff command, CancellationToken cancellationToken)
    {
        return DeleteCstatiAccountsService.Delete(command, cancellationToken);
    }

    [HttpPost]
    public Task<AddAccessCstatiAccountsCommandResponseBff> AddAccess([FromBody] AddAccessCstatiAccountsCommandBff command, CancellationToken cancellationToken)
    {
        return AddAccessCstatiAccountsService.AddAccess(command, cancellationToken);
    }

    [HttpPost]
    public Task<DeleteAccessCstatiAccountsCommandResponseBff> DeleteAccess([FromBody] DeleteAccessCstatiAccountsCommandBff command, CancellationToken cancellationToken)
    {
        return DeleteAccessCstatiAccountsService.DeleteAccess(command, cancellationToken);
    }

    [HttpPost]
    public Task<GetAllCstatiAccountsQueryResponseBff> GetAll([FromBody] GetAllCstatiAccountsQueryBff query, [FromQuery] int limit, CancellationToken cancellationToken)
    {
        return GetAllCstatiAccountsService.GetAll(query, limit, cancellationToken);
    }
}
