using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll.Contracts;

internal static class GetAllCstatiAccountsQueryResponseBffConverter
{
    internal static GetAllCstatiAccountsQueryResponseBff FromDto(GetAllCstatiAccountsQueryResponse response)
    {
        CstatiAccountBff[] accounts = response.Accounts.Select(CstatiAccountBffConverter.FromDto).ToArray();

        var result = new GetAllCstatiAccountsQueryResponseBff
        {
            Accounts = accounts
        };

        return result;
    }
}
