using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.Responsibles;

internal static class CstatiAccountEventResponsibleAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto(CstatiAccountEventResponsibleAccessBff access)
    {
        var result = new CstatiAccountAccessDto
        {
            Event = new CstatiAccountEventAccessDto
            {
                EventId = access.EventId,
                Responsible = new CstatiAccountEventResponsibleAccessDto()
            }
        };

        return result;
    }

    internal static CstatiAccountEventResponsibleAccessBff FromDto(CstatiAccountEventAccessDto access)
    {
        var result = new CstatiAccountEventResponsibleAccessBff
        {
            EventId = access.EventId
        };

        return result;
    }
}
