using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess.Contracts;

public sealed class DeleteAccessCstatiAccountsCommandBff
{
    public required string Login { get; init; }
    public required CstatiAccountAccessBff Access { get; init; }
    public required string ConcurrencyToken { get; init; }
}
