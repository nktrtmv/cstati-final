namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete.Contracts;

public sealed class DeleteCstatiAccountsCommandBff
{
    public required string Login { get; init; }
    public required string Password { get; init; }
    public required string ConcurrencyToken { get; init; }
}
