using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Admins;

internal static class CstatiAccountAdminAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto()
    {
        var result = new CstatiAccountAccessDto
        {
            Admin = new CstatiAccountAdminAccessDto()
        };

        return result;
    }

    internal static CstatiAccountAdminAccessBff FromDto()
    {
        var result = new CstatiAccountAdminAccessBff();

        return result;
    }
}
