using Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.Get;

internal static class GetCstatiAccountsQueryResponseConverter
{
    internal static GetCstatiAccountsQueryResponse FromInternal(GetCstatiAccountsQueryResponseInternal response)
    {
        CstatiAccountDto[] accounts = response.Accounts.Select(CstatiAccountDtoConverter.FromInternal).ToArray();

        var result = new GetCstatiAccountsQueryResponse
        {
            Accounts = { accounts }
        };

        return result;
    }
}
