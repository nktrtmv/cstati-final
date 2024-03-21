using Cstati.Accounts.Application.Accounts.Commands.AddAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts.Accesses;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.AddAccess;

internal static class AddAccessCstatiAccountsCommandConverter
{
    internal static AddAccessCstatiAccountsCommandInternal ToInternal(AddAccessCstatiAccountsCommand command)
    {
        CstatiAccountAccessInternal access = CstatiAccountAccessDtoConverter.ToInternal(command.Access);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new AddAccessCstatiAccountsCommandInternal(command.Login, access, concurrencyToken);

        return result;
    }
}
