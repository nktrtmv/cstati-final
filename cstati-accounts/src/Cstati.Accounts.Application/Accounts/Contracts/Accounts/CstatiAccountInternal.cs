using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Accounts.Application.Accounts.Contracts.Accounts;

public sealed class CstatiAccountInternal
{
    public CstatiAccountInternal(string login, string fullName, CstatiAccountAccessInternal[] accesses, ConcurrencyToken concurrencyToken)
    {
        Login = login;
        FullName = fullName;
        Accesses = accesses;
        ConcurrencyToken = concurrencyToken;
    }

    public string Login { get; }
    public string FullName { get; }
    public CstatiAccountAccessInternal[] Accesses { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
