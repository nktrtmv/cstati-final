using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Accounts.Domain.Entities.Accounts;

public sealed class CstatiAccount
{
    public CstatiAccount(string login, string password, string fullName, CstatiAccountAccess[] accesses, ConcurrencyToken concurrencyToken)
    {
        Login = login;
        Password = password;
        FullName = fullName;
        Accesses = accesses;
        ConcurrencyToken = concurrencyToken;
    }

    public string Login { get; }
    public string Password { get; }
    public string FullName { get; }
    public CstatiAccountAccess[] Accesses { get; private set; }
    public ConcurrencyToken ConcurrencyToken { get; }

    internal void SetAccesses(CstatiAccountAccess[] accesses)
    {
        Accesses = accesses;
    }
}
