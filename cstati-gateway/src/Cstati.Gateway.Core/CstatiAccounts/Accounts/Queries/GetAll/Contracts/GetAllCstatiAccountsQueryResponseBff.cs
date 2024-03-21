using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll.Contracts;

public sealed class GetAllCstatiAccountsQueryResponseBff
{
    public required CstatiAccountBff[] Accounts { get; init; }
}
