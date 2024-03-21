using Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Authorize;

internal static class AuthorizeCstatiAccountsCommandConverter
{
    internal static AuthorizeCstatiAccountsCommandInternal ToInternal(AuthorizeCstatiAccountsCommand command)
    {
        var result = new AuthorizeCstatiAccountsCommandInternal(command.Login, command.Password);

        return result;
    }
}
