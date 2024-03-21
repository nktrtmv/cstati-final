using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Admins;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.Admins;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.PaymentsResponsibles;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events.Responsibles;
using Cstati.Accounts.GenericSubdomain.Exceptions;
using Cstati.Accounts.Presentation.Abstractions;

namespace Cstati.Accounts.Presentation.Controllers.Accounts.Converters.Contracts.Accounts.Accesses;

internal static class CstatiAccountAccessDtoConverter
{
    internal static CstatiAccountAccessDto FromInternal(CstatiAccountAccessInternal access)
    {
        CstatiAccountAccessDto result = access switch
        {
            CstatiAccountAdminAccessInternal => new CstatiAccountAccessDto
            {
                Admin = new CstatiAccountAdminAccessDto()
            },

            CstatiAccountEventPaymentsResponsibleAccessInternal a => new CstatiAccountAccessDto
            {
                Event = new CstatiAccountEventAccessDto
                {
                    EventId = a.EventId,
                    PaymentsResponsible = new CstatiAccountEventPaymentsResponsibleAccessDto()
                }
            },

            CstatiAccountEventResponsibleAccessInternal a => new CstatiAccountAccessDto
            {
                Event = new CstatiAccountEventAccessDto
                {
                    EventId = a.EventId,
                    Responsible = new CstatiAccountEventResponsibleAccessDto()
                }
            },

            CstatiAccountEventAdminAccessInternal a => new CstatiAccountAccessDto
            {
                Event = new CstatiAccountEventAccessDto
                {
                    EventId = a.EventId,
                    Admin = new CstatiAccountEventAdminAccessDto()
                }
            },

            _ => throw new ArgumentTypeOutOfRangeException(access)
        };

        return result;
    }

    internal static CstatiAccountAccessInternal ToInternal(CstatiAccountAccessDto access)
    {
        CstatiAccountAccessInternal result = access.AccessCase switch
        {
            CstatiAccountAccessDto.AccessOneofCase.Admin => new CstatiAccountAdminAccessInternal(),

            CstatiAccountAccessDto.AccessOneofCase.Event => access.Event.AccessCase switch
            {
                CstatiAccountEventAccessDto.AccessOneofCase.Admin => new CstatiAccountEventAdminAccessInternal(access.Event.EventId),
                CstatiAccountEventAccessDto.AccessOneofCase.PaymentsResponsible => new CstatiAccountEventPaymentsResponsibleAccessInternal(access.Event.EventId),
                CstatiAccountEventAccessDto.AccessOneofCase.Responsible => new CstatiAccountEventResponsibleAccessInternal(access.Event.EventId),
                _ => throw new ArgumentTypeOutOfRangeException(access.Event.AccessCase)
            },

            _ => throw new ArgumentTypeOutOfRangeException(access.AccessCase)
        };

        return result;
    }
}
