using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;

public sealed class AuthorizeCstatiAccountsCommandInternal : IRequest<AuthorizeCstatiAccountsCommandResponseInternal>
{
    public AuthorizeCstatiAccountsCommandInternal(string login, string password)
    {
        Login = login;
        Password = password;
    }

    internal string Login { get; }
    internal string Password { get; }
}
