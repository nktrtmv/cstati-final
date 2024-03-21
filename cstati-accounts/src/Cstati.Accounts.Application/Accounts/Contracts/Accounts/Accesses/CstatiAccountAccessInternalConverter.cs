using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Admins;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.Admins;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.PaymentsResponsibles;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.Responsibles;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Admins;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.Admins;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.PaymentsResponsibles;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.Responsibles;
using Cstati.Accounts.GenericSubdomain.Exceptions;

namespace Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;

internal static class CstatiAccountAccessInternalConverter
{
    internal static CstatiAccountAccessInternal FromDomain(CstatiAccountAccess access)
    {
        CstatiAccountAccessInternal result = access switch
        {
            CstatiAccountAdminAccess => new CstatiAccountAdminAccessInternal(),
            CstatiAccountEventPaymentsResponsibleAccess a => new CstatiAccountEventPaymentsResponsibleAccessInternal(a.EventId),
            CstatiAccountEventResponsibleAccess a => new CstatiAccountEventResponsibleAccessInternal(a.EventId),
            CstatiAccountEventAdminAccess a => new CstatiAccountEventAdminAccessInternal(a.EventId),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }

    internal static CstatiAccountAccess ToDomain(CstatiAccountAccessInternal access)
    {
        CstatiAccountAccess result = access switch
        {
            CstatiAccountAdminAccessInternal => new CstatiAccountAdminAccess(),
            CstatiAccountEventPaymentsResponsibleAccessInternal a => new CstatiAccountEventPaymentsResponsibleAccess(a.EventId),
            CstatiAccountEventResponsibleAccessInternal a => new CstatiAccountEventResponsibleAccess(a.EventId),
            CstatiAccountEventAdminAccessInternal a => new CstatiAccountEventAdminAccess(a.EventId),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }
}
