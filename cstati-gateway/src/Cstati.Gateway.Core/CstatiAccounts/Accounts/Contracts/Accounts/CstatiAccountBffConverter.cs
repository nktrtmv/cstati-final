using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts;

internal static class CstatiAccountBffConverter
{
    internal static CstatiAccountBff FromDto(CstatiAccountDto account)
    {
        CstatiAccountAccessBff[] accesses = account.Accesses.Select(CstatiAccountAccessBffConverter.FromDto).ToArray();

        var result = new CstatiAccountBff
        {
            Login = account.Login,
            FullName = account.FullName,
            Accesses = accesses,
            ConcurrencyToken = account.ConcurrencyToken
        };

        return result;
    }
}
