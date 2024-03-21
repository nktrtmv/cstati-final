using Cstati.Accounts.Application.Accounts.Commands.DeleteAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts.Accesses;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.DeleteAccess;

internal static class DeleteAccessCstatiAccountsCommandConverter
{
    internal static DeleteAccessCstatiAccountsCommandInternal ToInternal(DeleteAccessCstatiAccountsCommand command)
    {
        CstatiAccountAccessInternal access = CstatiAccountAccessDtoConverter.ToInternal(command.Access);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteAccessCstatiAccountsCommandInternal(command.Login, access, concurrencyToken);

        return result;
    }
}
