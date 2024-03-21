using Cstati.Accounts.Application.Accounts.Contracts.Accounts;

namespace Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;

public sealed class GetAllCstatiAccountsQueryResponseInternal
{
    public GetAllCstatiAccountsQueryResponseInternal(CstatiAccountInternal[] accounts)
    {
        Accounts = accounts;
    }

    public CstatiAccountInternal[] Accounts { get; }
}
