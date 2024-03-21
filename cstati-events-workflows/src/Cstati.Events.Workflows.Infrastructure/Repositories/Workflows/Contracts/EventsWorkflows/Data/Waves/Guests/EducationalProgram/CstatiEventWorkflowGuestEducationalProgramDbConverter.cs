using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.GenericSubdomain.Exceptions;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.EducationalProgram;

internal static class CstatiEventWorkflowGuestEducationalProgramDbConverter
{
    internal static CstatiEventWorkflowGuestEducationalProgramDb FromDomain(CstatiEventWorkflowGuestEducationalProgram bank)
    {
        CstatiEventWorkflowGuestEducationalProgramDb result = bank switch
        {
            CstatiEventWorkflowGuestEducationalProgram.SoftwareEngineering => CstatiEventWorkflowGuestEducationalProgramDb.SoftwareEngineering,
            CstatiEventWorkflowGuestEducationalProgram.AppliedMathematicsAndInformatics => CstatiEventWorkflowGuestEducationalProgramDb.AppliedMathematicsAndInformatics,
            CstatiEventWorkflowGuestEducationalProgram.AppliedDataAnalysis => CstatiEventWorkflowGuestEducationalProgramDb.AppliedDataAnalysis,
            CstatiEventWorkflowGuestEducationalProgram.ComputerScienceAndDataAnalysis => CstatiEventWorkflowGuestEducationalProgramDb.ComputerScienceAndDataAnalysis,
            CstatiEventWorkflowGuestEducationalProgram.EconomicsAndDataAnalysis => CstatiEventWorkflowGuestEducationalProgramDb.EconomicsAndDataAnalysis,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }

    internal static CstatiEventWorkflowGuestEducationalProgram ToDomain(CstatiEventWorkflowGuestEducationalProgramDb bank)
    {
        CstatiEventWorkflowGuestEducationalProgram result = bank switch
        {
            CstatiEventWorkflowGuestEducationalProgramDb.SoftwareEngineering => CstatiEventWorkflowGuestEducationalProgram.SoftwareEngineering,
            CstatiEventWorkflowGuestEducationalProgramDb.AppliedMathematicsAndInformatics => CstatiEventWorkflowGuestEducationalProgram.AppliedMathematicsAndInformatics,
            CstatiEventWorkflowGuestEducationalProgramDb.AppliedDataAnalysis => CstatiEventWorkflowGuestEducationalProgram.AppliedDataAnalysis,
            CstatiEventWorkflowGuestEducationalProgramDb.ComputerScienceAndDataAnalysis => CstatiEventWorkflowGuestEducationalProgram.ComputerScienceAndDataAnalysis,
            CstatiEventWorkflowGuestEducationalProgramDb.EconomicsAndDataAnalysis => CstatiEventWorkflowGuestEducationalProgram.EconomicsAndDataAnalysis,
            _ => throw new ArgumentTypeOutOfRangeException(bank)
        };

        return result;
    }
}
