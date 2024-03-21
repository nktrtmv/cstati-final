namespace Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;

public sealed class AuthorizeCstatiAccountsCommandResponseInternal
{
    public AuthorizeCstatiAccountsCommandResponseInternal(bool succeed)
    {
        Succeed = succeed;
    }

    public bool Succeed { get; }
}
