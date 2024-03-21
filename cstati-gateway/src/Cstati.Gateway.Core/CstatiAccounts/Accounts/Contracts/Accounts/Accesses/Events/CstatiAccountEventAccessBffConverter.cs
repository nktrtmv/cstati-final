using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.Admins;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.PaymentsResponsibles;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events.Responsibles;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events;

internal static class CstatiAccountEventAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto(CstatiAccountEventAccessBff access)
    {
        CstatiAccountAccessDto result = access switch
        {
            CstatiAccountEventAdminAccessBff a => CstatiAccountEventAdminAccessBffConverter.ToDto(a),
            CstatiAccountEventPaymentsResponsibleAccessBff a => CstatiAccountEventPaymentsResponsibleAccessBffConverter.ToDto(a),
            CstatiAccountEventResponsibleAccessBff a => CstatiAccountEventResponsibleAccessBffConverter.ToDto(a),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }

    internal static CstatiAccountEventAccessBff FromDto(CstatiAccountEventAccessDto access)
    {
        CstatiAccountEventAccessBff result = access.AccessCase switch
        {
            CstatiAccountEventAccessDto.AccessOneofCase.Admin => CstatiAccountEventAdminAccessBffConverter.FromDto(access),
            CstatiAccountEventAccessDto.AccessOneofCase.PaymentsResponsible => CstatiAccountEventPaymentsResponsibleAccessBffConverter.FromDto(access),
            CstatiAccountEventAccessDto.AccessOneofCase.Responsible => CstatiAccountEventResponsibleAccessBffConverter.FromDto(access),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }
}
