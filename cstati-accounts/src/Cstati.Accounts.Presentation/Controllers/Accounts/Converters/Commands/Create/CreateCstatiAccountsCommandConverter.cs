using Cstati.Accounts.Application.Accounts.Commands.Create.Contracts;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Create;

internal static class CreateCstatiAccountsCommandConverter
{
    internal static CreateCstatiAccountsCommandInternal ToInternal(CreateCstatiAccountsCommand command)
    {
        var result = new CreateCstatiAccountsCommandInternal(command.Login, command.Password, command.FullName);

        return result;
    }
}
