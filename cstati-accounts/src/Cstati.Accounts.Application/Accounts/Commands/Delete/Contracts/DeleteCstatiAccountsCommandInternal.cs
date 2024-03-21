using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Delete.Contracts;

public sealed class DeleteCstatiAccountsCommandInternal : IRequest
{
    public DeleteCstatiAccountsCommandInternal(string login, string password, ConcurrencyToken concurrencyToken)
    {
        Login = login;
        Password = password;
        ConcurrencyToken = concurrencyToken;
    }

    internal string Login { get; }
    internal string Password { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
