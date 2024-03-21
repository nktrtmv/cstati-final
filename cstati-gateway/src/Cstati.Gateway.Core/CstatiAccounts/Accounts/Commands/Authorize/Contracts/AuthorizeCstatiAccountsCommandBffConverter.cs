using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize.Contracts;

internal static class AuthorizeCstatiAccountsCommandBffConverter
{
    internal static AuthorizeCstatiAccountsCommand ToDto(AuthorizeCstatiAccountsCommandBff command)
    {
        var result = new AuthorizeCstatiAccountsCommand
        {
            Login = command.Login,
            Password = command.Password
        };

        return result;
    }
}
