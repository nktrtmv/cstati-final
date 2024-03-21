using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.PaymentsResponsibles;

internal static class CstatiAccountEventPaymentsResponsibleAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto(CstatiAccountEventPaymentsResponsibleAccessBff access)
    {
        var result = new CstatiAccountAccessDto
        {
            Event = new CstatiAccountEventAccessDto
            {
                EventId = access.EventId,
                PaymentsResponsible = new CstatiAccountEventPaymentsResponsibleAccessDto()
            }
        };

        return result;
    }

    internal static CstatiAccountEventPaymentsResponsibleAccessBff FromDto(CstatiAccountEventAccessDto access)
    {
        var result = new CstatiAccountEventPaymentsResponsibleAccessBff
        {
            EventId = access.EventId
        };

        return result;
    }
}
