using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts;

public abstract class CstatiAccountsServiceClientBase
{
    protected CstatiAccountsServiceClientBase(CstatiAccountsService.CstatiAccountsServiceClient accounts)
    {
        Accounts = accounts;
    }

    protected CstatiAccountsService.CstatiAccountsServiceClient Accounts { get; }
}
