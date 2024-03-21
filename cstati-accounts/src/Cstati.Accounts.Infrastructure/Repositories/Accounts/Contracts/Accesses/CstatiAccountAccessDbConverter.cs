using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Admins;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.Admins;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.PaymentsResponsibles;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events.Responsibles;
using Cstati.Accounts.GenericSubdomain.Exceptions;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses.Admins;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses.Events.Admins;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses.Events.PaymentsResponsibles;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses.Events.Responsibles;

namespace Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses;

internal static class CstatiAccountAccessDbConverter
{
    internal static CstatiAccountAccessDb FromDomain(CstatiAccountAccess access)
    {
        CstatiAccountAccessDb result = access switch
        {
            CstatiAccountAdminAccess => new CstatiAccountAdminAccessDb(),
            CstatiAccountEventPaymentsResponsibleAccess a => new CstatiAccountEventPaymentsResponsibleAccessDb { EventId = a.EventId },
            CstatiAccountEventResponsibleAccess a => new CstatiAccountEventResponsibleAccessDb { EventId = a.EventId },
            CstatiAccountEventAdminAccess a => new CstatiAccountEventAdminAccessDb { EventId = a.EventId },
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }

    internal static CstatiAccountAccess ToDomain(CstatiAccountAccessDb access)
    {
        CstatiAccountAccess result = access switch
        {
            CstatiAccountAdminAccessDb => new CstatiAccountAdminAccess(),
            CstatiAccountEventPaymentsResponsibleAccessDb a => new CstatiAccountEventPaymentsResponsibleAccess(a.EventId),
            CstatiAccountEventResponsibleAccessDb a => new CstatiAccountEventResponsibleAccess(a.EventId),
            CstatiAccountEventAdminAccessDb a => new CstatiAccountEventAdminAccess(a.EventId),
            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }
}
