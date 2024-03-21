using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;

internal static class CstatiEventWorkflowGuestGenderInternalConverter
{
    internal static CstatiEventWorkflowGuestGenderInternal FromDomain(CstatiEventWorkflowGuestGender gender)
    {
        CstatiEventWorkflowGuestGenderInternal result = gender switch
        {
            CstatiEventWorkflowGuestGender.Male => CstatiEventWorkflowGuestGenderInternal.Male,
            CstatiEventWorkflowGuestGender.Female => CstatiEventWorkflowGuestGenderInternal.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestGender ToDomain(CstatiEventWorkflowGuestGenderInternal gender)
    {
        CstatiEventWorkflowGuestGender result = gender switch
        {
            CstatiEventWorkflowGuestGenderInternal.Male => CstatiEventWorkflowGuestGender.Male,
            CstatiEventWorkflowGuestGenderInternal.Female => CstatiEventWorkflowGuestGender.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }
}
