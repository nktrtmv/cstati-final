using Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Authorize;

internal static class AuthorizeCstatiAccountsCommandResponseConverter
{
    internal static AuthorizeCstatiAccountsCommandResponse FromInternal(AuthorizeCstatiAccountsCommandResponseInternal response)
    {
        var result = new AuthorizeCstatiAccountsCommandResponse
        {
            Succeed = response.Succeed
        };

        return result;
    }
}
