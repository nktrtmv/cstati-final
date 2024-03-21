using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.Admins;

internal static class CstatiAccountEventAdminAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto(CstatiAccountEventAdminAccessBff access)
    {
        var result = new CstatiAccountAccessDto
        {
            Event = new CstatiAccountEventAccessDto
            {
                EventId = access.EventId,
                Admin = new CstatiAccountEventAdminAccessDto()
            }
        };

        return result;
    }

    internal static CstatiAccountEventAdminAccessBff FromDto(CstatiAccountEventAccessDto access)
    {
        var result = new CstatiAccountEventAdminAccessBff
        {
            EventId = access.EventId
        };

        return result;
    }
}
