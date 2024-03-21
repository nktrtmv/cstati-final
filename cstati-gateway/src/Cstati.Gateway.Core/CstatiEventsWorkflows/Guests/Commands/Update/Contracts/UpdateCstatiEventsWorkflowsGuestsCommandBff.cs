using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsWorkflowsGuestsCommandBff
{
    public required string EventId { get; init; }
    public required string GuestId { get; init; }
    public required string FullName { get; init; }
    public required CstatiEventWorkflowGuestGenderBff Gender { get; init; }
    public required string TelegramLogin { get; init; }
    public required CstatiEventWorkflowGuestPaymentStatusBff PaymentStatusChangeTo { get; init; }
    public required CstatiEventWorkflowGuestEducationalProgramBff EducationalProgram { get; init; }
    public required string PhoneNumber { get; init; }
    public required bool IsLegalAge { get; init; }
    public required CstatiEventWorkflowTicketTypeBff TicketType { get; init; }
    public bool? TransferIsRequired { get; init; }
    public required string ConcurrencyToken { get; init; }
}
