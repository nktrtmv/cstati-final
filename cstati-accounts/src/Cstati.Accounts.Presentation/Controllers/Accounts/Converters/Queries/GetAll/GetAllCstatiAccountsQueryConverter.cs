using Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.GetAll;

internal static class GetAllCstatiAccountsQueryConverter
{
    internal static GetAllCstatiAccountsQueryInternal ToInternal(GetAllCstatiAccountsQuery query)
    {
        var result = new GetAllCstatiAccountsQueryInternal(query.Query, query.Limit);

        return result;
    }
}
