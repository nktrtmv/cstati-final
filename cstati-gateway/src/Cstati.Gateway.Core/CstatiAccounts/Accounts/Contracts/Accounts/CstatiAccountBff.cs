using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts;

public sealed class CstatiAccountBff
{
    public required string Login { get; init; }
    public required string FullName { get; set; }
    public required CstatiAccountAccessBff[] Accesses { get; set; }
    public string ConcurrencyToken { get; init; } = string.Empty;
}
