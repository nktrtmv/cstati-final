using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Create.Contracts;

public sealed class CreateCstatiAccountsCommandInternal : IRequest
{
    public CreateCstatiAccountsCommandInternal(string login, string password, string fullName)
    {
        Login = login;
        Password = password;
        FullName = fullName;
    }

    internal string Login { get; }
    internal string Password { get; }
    internal string FullName { get; }
}
