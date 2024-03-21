using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess.Contracts;

public sealed class AddAccessCstatiAccountsCommandBff
{
    public required string Login { get; init; }
    public required CstatiAccountAccessBff Access { get; init; }
    public required string ConcurrencyToken { get; init; }
}
