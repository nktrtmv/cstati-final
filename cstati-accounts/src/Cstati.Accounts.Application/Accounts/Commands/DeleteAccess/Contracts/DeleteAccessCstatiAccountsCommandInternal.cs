using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.DeleteAccess.Contracts;

public sealed class DeleteAccessCstatiAccountsCommandInternal : IRequest
{
    public DeleteAccessCstatiAccountsCommandInternal(string login, CstatiAccountAccessInternal access, ConcurrencyToken concurrencyToken)
    {
        Login = login;
        Access = access;
        ConcurrencyToken = concurrencyToken;
    }

    internal string Login { get; }
    internal CstatiAccountAccessInternal Access { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
