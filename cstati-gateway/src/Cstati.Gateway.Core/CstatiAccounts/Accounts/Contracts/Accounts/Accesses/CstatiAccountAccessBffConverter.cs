using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Admins;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses;

internal static class CstatiAccountAccessBffConverter
{
    internal static CstatiAccountAccessDto ToDto(CstatiAccountAccessBff access)
    {
        CstatiAccountAccessDto result = access switch
        {
            CstatiAccountAdminAccessBff => CstatiAccountAdminAccessBffConverter.ToDto(),
            CstatiAccountEventAccessBff a => CstatiAccountEventAccessBffConverter.ToDto(a),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }

    internal static CstatiAccountAccessBff FromDto(CstatiAccountAccessDto access)
    {
        CstatiAccountAccessBff result = access.AccessCase switch
        {
            CstatiAccountAccessDto.AccessOneofCase.Admin => CstatiAccountAdminAccessBffConverter.FromDto(),
            CstatiAccountAccessDto.AccessOneofCase.Event => CstatiAccountEventAccessBffConverter.FromDto(access.Event),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }
}
