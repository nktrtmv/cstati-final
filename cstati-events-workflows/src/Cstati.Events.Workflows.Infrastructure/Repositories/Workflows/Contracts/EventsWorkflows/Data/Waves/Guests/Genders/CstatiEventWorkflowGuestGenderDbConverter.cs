using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.Genders;

internal static class CstatiEventWorkflowGuestGenderDbConverter
{
    internal static CstatiEventWorkflowGuestGenderDb FromDomain(CstatiEventWorkflowGuestGender gender)
    {
        CstatiEventWorkflowGuestGenderDb result = gender switch
        {
            CstatiEventWorkflowGuestGender.Male => CstatiEventWorkflowGuestGenderDb.Male,
            CstatiEventWorkflowGuestGender.Female => CstatiEventWorkflowGuestGenderDb.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestGender ToDomain(CstatiEventWorkflowGuestGenderDb gender)
    {
        CstatiEventWorkflowGuestGender result = gender switch
        {
            CstatiEventWorkflowGuestGenderDb.Male => CstatiEventWorkflowGuestGender.Male,
            CstatiEventWorkflowGuestGenderDb.Female => CstatiEventWorkflowGuestGender.Female,
            _ => throw new ArgumentTypeOutOfRangeException(gender)
        };

        return result;
    }
}
