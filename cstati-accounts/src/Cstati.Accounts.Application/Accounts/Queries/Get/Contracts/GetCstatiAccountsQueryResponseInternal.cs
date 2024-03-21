using Cstati.Accounts.Application.Accounts.Contracts.Accounts;

namespace Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;

public sealed class GetCstatiAccountsQueryResponseInternal
{
    public GetCstatiAccountsQueryResponseInternal(CstatiAccountInternal[] accounts)
    {
        Accounts = accounts;
    }

    public CstatiAccountInternal[] Accounts { get; }
}
