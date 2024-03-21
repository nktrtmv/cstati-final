using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;

internal static class CstatiEventWorkflowGuestEducationalProgramBffConverter
{
    internal static CstatiEventWorkflowGuestEducationalProgramDto ToDto(CstatiEventWorkflowGuestEducationalProgramBff program)
    {
        CstatiEventWorkflowGuestEducationalProgramDto result = program switch
        {
            CstatiEventWorkflowGuestEducationalProgramBff.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgramDto.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgramBff.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgramDto.AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgramBff.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramBff.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramBff.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramDto.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(program)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestEducationalProgramBff FromDto(CstatiEventWorkflowGuestEducationalProgramDto program)
    {
        CstatiEventWorkflowGuestEducationalProgramBff result = program switch
        {
            CstatiEventWorkflowGuestEducationalProgramDto.SoftwareEngineering =>
                CstatiEventWorkflowGuestEducationalProgramBff.SoftwareEngineering,

            CstatiEventWorkflowGuestEducationalProgramDto.AppliedMathematicsAndInformatics =>
                CstatiEventWorkflowGuestEducationalProgramBff
                    .AppliedMathematicsAndInformatics,

            CstatiEventWorkflowGuestEducationalProgramDto.AppliedDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramBff.AppliedDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramDto.ComputerScienceAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramBff.ComputerScienceAndDataAnalysis,

            CstatiEventWorkflowGuestEducationalProgramDto.EconomicsAndDataAnalysis =>
                CstatiEventWorkflowGuestEducationalProgramBff.EconomicsAndDataAnalysis,

            _ => throw new ArgumentTypeOutOfRangeException(program)
        };

        return result;
    }
}
