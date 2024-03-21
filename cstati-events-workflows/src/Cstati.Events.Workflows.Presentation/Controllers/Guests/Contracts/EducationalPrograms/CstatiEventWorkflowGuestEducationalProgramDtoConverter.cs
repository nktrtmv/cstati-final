using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.EducationalPrograms;

internal static class CstatiEventWorkflowGuestEducationalProgramDtoConverter
{
    internal static CstatiEventWorkflowGuestEducationalProgramDto FromInternal(CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram)
    {
        CstatiEventWorkflowGuestEducationalProgramDto result = educationalProgram switch
        {
            CstatiEventWorkflowGuestEducationalProgramInternal.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgramDto.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgramInternal.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgramDto.AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgramInternal.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramInternal.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramInternal.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(educationalProgram)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestEducationalProgramInternal ToInternal(CstatiEventWorkflowGuestEducationalProgramDto educationalProgram)
    {
        CstatiEventWorkflowGuestEducationalProgramInternal result = educationalProgram switch
        {
            CstatiEventWorkflowGuestEducationalProgramDto.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgramInternal.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgramDto.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgramInternal.AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgramDto.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramDto.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramDto.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramInternal.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(educationalProgram)
        };

        return result;
    }
}
