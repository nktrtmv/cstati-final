using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize.Contracts;

internal static class AuthorizeCstatiAccountsCommandResponseBffConverter
{
    internal static AuthorizeCstatiAccountsCommandResponseBff FromDto(AuthorizeCstatiAccountsCommandResponse response)
    {
        var result = new AuthorizeCstatiAccountsCommandResponseBff
        {
            Succeed = response.Succeed
        };

        return result;
    }
}
