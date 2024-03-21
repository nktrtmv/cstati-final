using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess.Contracts;

internal static class DeleteAccessCstatiAccountsCommandBffConverter
{
    internal static DeleteAccessCstatiAccountsCommand ToDto(DeleteAccessCstatiAccountsCommandBff command)
    {
        CstatiAccountAccessDto access = CstatiAccountAccessBffConverter.ToDto(command.Access);

        var result = new DeleteAccessCstatiAccountsCommand
        {
            Login = command.Login,
            Access = access,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
