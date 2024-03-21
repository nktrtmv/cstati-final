using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.Genders;

internal static class CstatiEventWorkflowGuestGenderDtoConverter
{
    internal static CstatiEventWorkflowGuestGenderDto FromInternal(CstatiEventWorkflowGuestGenderInternal gender)
    {
        CstatiEventWorkflowGuestGenderDto result = gender switch
        {
            CstatiEventWorkflowGuestGenderInternal.Male => CstatiEventWorkflowGuestGenderDto.Male,
            CstatiEventWorkflowGuestGenderInternal.Female => CstatiEventWorkflowGuestGenderDto.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestGenderInternal ToInternal(CstatiEventWorkflowGuestGenderDto gender)
    {
        CstatiEventWorkflowGuestGenderInternal result = gender switch
        {
            CstatiEventWorkflowGuestGenderDto.Male => CstatiEventWorkflowGuestGenderInternal.Male,
            CstatiEventWorkflowGuestGenderDto.Female => CstatiEventWorkflowGuestGenderInternal.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }
}
