using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;

internal static class CstatiEventWorkflowGuestGenderBffConverter
{
    internal static CstatiEventWorkflowGuestGenderBff FromDto(CstatiEventWorkflowGuestGenderDto gender)
    {
        CstatiEventWorkflowGuestGenderBff result = gender switch
        {
            CstatiEventWorkflowGuestGenderDto.Male => CstatiEventWorkflowGuestGenderBff.Male,
            CstatiEventWorkflowGuestGenderDto.Female => CstatiEventWorkflowGuestGenderBff.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestGenderDto ToDto(CstatiEventWorkflowGuestGenderBff gender)
    {
        CstatiEventWorkflowGuestGenderDto result = gender switch
        {
            CstatiEventWorkflowGuestGenderBff.Male => CstatiEventWorkflowGuestGenderDto.Male,
            CstatiEventWorkflowGuestGenderBff.Female => CstatiEventWorkflowGuestGenderDto.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }
}
