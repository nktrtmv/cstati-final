using Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;
using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Queries.GetAll;

internal static class GetAllCstatiAccountsQueryResponseConverter
{
    internal static GetAllCstatiAccountsQueryResponse FromInternal(GetAllCstatiAccountsQueryResponseInternal response)
    {
        CstatiAccountDto[] accounts = response.Accounts.Select(CstatiAccountDtoConverter.FromInternal).ToArray();

        var result = new GetAllCstatiAccountsQueryResponse
        {
            Accounts = { accounts }
        };

        return result;
    }
}
