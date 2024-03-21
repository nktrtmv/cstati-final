namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create.Contracts;

public sealed class CreateCstatiAccountsCommandBff
{
    public required string Login { get; init; }
    public required string Password { get; init; }
    public required string FullName { get; init; }
}
