using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;

internal static class CstatiEventWorkflowGuestEducationalProgramInternalConverter
{
    internal static CstatiEventWorkflowGuestEducationalProgramInternal FromDomain(CstatiEventWorkflowGuestEducationalProgram educationalProgram)
    {
        CstatiEventWorkflowGuestEducationalProgramInternal result = educationalProgram switch
        {
            CstatiEventWorkflowGuestEducationalProgram.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgramInternal.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgram.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgramInternal.AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgram.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgram.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgram.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(educationalProgram)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestEducationalProgram ToDomain(CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram)
    {
        CstatiEventWorkflowGuestEducationalProgram result = educationalProgram switch
        {
            CstatiEventWorkflowGuestEducationalProgramInternal.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgram.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgramInternal.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgram.AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgramInternal.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgram.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramInternal.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgram.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramInternal.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgram.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(educationalProgram)
        };

        return result;
    }
}
