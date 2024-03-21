using Cstati.Accounts.Application.Accounts.Commands.Delete.Contracts;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Commands.Delete;

internal static class DeleteCstatiAccountsCommandConverter
{
    internal static DeleteCstatiAccountsCommandInternal ToInternal(DeleteCstatiAccountsCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiAccountsCommandInternal(command.Login, command.Password, concurrencyToken);

        return result;
    }
}
