using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.AddAccess.Contracts;

public sealed class AddAccessCstatiAccountsCommandInternal : IRequest
{
    public AddAccessCstatiAccountsCommandInternal(string login, CstatiAccountAccessInternal access, ConcurrencyToken concurrencyToken)
    {
        Login = login;
        Access = access;
        ConcurrencyToken = concurrencyToken;
    }

    internal string Login { get; }
    internal CstatiAccountAccessInternal Access { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
