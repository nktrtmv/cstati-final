using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize;

public sealed class AuthorizeCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public AuthorizeCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<AuthorizeCstatiAccountsCommandResponseBff> Authorize(AuthorizeCstatiAccountsCommandBff commandBff, CancellationToken cancellationToken)
    {
        AuthorizeCstatiAccountsCommand command = AuthorizeCstatiAccountsCommandBffConverter.ToDto(commandBff);

        AuthorizeCstatiAccountsCommandResponse response = await Accounts.AuthorizeAsync(command, cancellationToken: cancellationToken);

        AuthorizeCstatiAccountsCommandResponseBff result = AuthorizeCstatiAccountsCommandResponseBffConverter.FromDto(response);

        return result;
    }
}
