using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts.Guests;

public sealed class AddBatchCstatiEventsWorkflowsGuestsCommandGuestBff
{
    public required string FullName { get; init; }
    public required CstatiEventWorkflowGuestGenderBff Gender { get; init; }
    public required string TelegramLogin { get; init; }
    public required CstatiEventWorkflowGuestEducationalProgramBff EducationalProgram { get; init; }
    public required string PhoneNumber { get; init; }
    public required bool IsLegalAge { get; init; }
    public required CstatiEventWorkflowTicketTypeBff PreferredTicketType { get; init; }
    public bool? TransferIsRequested { get; init; }
}
