using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete.Contracts;

internal static class DeleteCstatiAccountsCommandBffConverter
{
    internal static DeleteCstatiAccountsCommand ToDto(DeleteCstatiAccountsCommandBff command)
    {
        var result = new DeleteCstatiAccountsCommand
        {
            Login = command.Login,
            Password = command.Password,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
