using Cstati.Accounts.Application.Accounts.Contracts.Accounts;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts.Accesses;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts;

internal static class CstatiAccountDtoConverter
{
    internal static CstatiAccountDto FromInternal(CstatiAccountInternal account)
    {
        CstatiAccountAccessDto[] accesses = account.Accesses.Select(CstatiAccountAccessDtoConverter.FromInternal).ToArray();

        var concurrencyToken = ConcurrencyTokenConverterTo.ToString(account.ConcurrencyToken);

        var result = new CstatiAccountDto
        {
            Login = account.Login,
            FullName = account.FullName,
            Accesses = { accesses },
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }
}
