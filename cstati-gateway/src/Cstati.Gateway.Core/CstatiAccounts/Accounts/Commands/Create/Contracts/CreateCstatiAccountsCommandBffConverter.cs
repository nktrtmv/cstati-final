using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create.Contracts;

internal static class CreateCstatiAccountsCommandBffConverter
{
    internal static CreateCstatiAccountsCommand ToDto(CreateCstatiAccountsCommandBff command)
    {
        var result = new CreateCstatiAccountsCommand
        {
            Login = command.Login,
            Password = command.Password,
            FullName = command.FullName
        };

        return result;
    }
}
