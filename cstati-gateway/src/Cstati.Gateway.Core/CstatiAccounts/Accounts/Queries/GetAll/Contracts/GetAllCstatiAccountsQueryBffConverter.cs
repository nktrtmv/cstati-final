using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll.Contracts;

internal static class GetAllCstatiAccountsQueryBffConverter
{
    internal static GetAllCstatiAccountsQuery ToDto(GetAllCstatiAccountsQueryBff query, int limit)
    {
        var result = new GetAllCstatiAccountsQuery
        {
            Query = query.Query,
            Limit = limit
        };

        return result;
    }
}
