using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts.Queries.GetAll;

namespace Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;

internal static class GetAllCstatiAccountsQueryInternalConverter
{
    internal static GetAllCstatiAccountsQuery TomDomain(GetAllCstatiAccountsQueryInternal query)
    {
        var result = new GetAllCstatiAccountsQuery(query.Query, query.Limit);

        return result;
    }
}
