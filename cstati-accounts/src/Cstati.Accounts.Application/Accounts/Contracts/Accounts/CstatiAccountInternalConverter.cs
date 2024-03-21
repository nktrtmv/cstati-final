using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.Domain.Entities.Accounts;

namespace Cstati.Accounts.Application.Accounts.Contracts.Accounts;

internal static class CstatiAccountInternalConverter
{
    internal static CstatiAccountInternal FromDomain(CstatiAccount account)
    {
        CstatiAccountAccessInternal[] accesses = account.Accesses.Select(CstatiAccountAccessInternalConverter.FromDomain).ToArray();

        var result = new CstatiAccountInternal(account.Login, account.FullName, accesses, account.ConcurrencyToken);

        return result;
    }
}
