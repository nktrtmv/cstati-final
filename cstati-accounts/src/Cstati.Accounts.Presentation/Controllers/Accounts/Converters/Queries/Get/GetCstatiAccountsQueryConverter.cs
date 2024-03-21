using Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.Get;

internal static class GetCstatiAccountsQueryConverter
{
    internal static GetCstatiAccountsQueryInternal ToInternal(GetCstatiAccountsQuery query)
    {
        var result = new GetCstatiAccountsQueryInternal(query.Logins.ToArray());

        return result;
    }
}
