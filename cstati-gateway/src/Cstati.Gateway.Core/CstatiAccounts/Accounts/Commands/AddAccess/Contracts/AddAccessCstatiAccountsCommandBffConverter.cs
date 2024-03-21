using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess.Contracts;

internal static class AddAccessCstatiAccountsCommandBffConverter
{
    internal static AddAccessCstatiAccountsCommand ToDto(AddAccessCstatiAccountsCommandBff command)
    {
        CstatiAccountAccessDto access = CstatiAccountAccessBffConverter.ToDto(command.Access);

        var result = new AddAccessCstatiAccountsCommand
        {
            Login = command.Login,
            Access = access,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
