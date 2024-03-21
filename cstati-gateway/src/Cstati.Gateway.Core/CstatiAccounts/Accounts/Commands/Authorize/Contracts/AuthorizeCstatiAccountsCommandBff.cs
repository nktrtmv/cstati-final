namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Authorize.Contracts;

public sealed class AuthorizeCstatiAccountsCommandBff
{
    public required string Login { get; init; }
    public required string Password { get; init; }
}
