using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Accounts.Domain.Entities.Accounts.Factories;

public static class CstatiAccountFactory
{
    public static CstatiAccount CreateNew(string login, string password, string fullName)
    {
        CstatiAccountAccess[] accesses = Array.Empty<CstatiAccountAccess>();

        var concurrencyToken = ConcurrencyToken.Empty;

        var result = new CstatiAccount(login, password, fullName, accesses, concurrencyToken);

        return result;
    }
}
