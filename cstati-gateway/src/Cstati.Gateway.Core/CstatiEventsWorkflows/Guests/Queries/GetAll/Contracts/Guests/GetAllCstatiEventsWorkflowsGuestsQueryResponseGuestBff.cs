using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBff
{
    public required int WaveOrdinal { get; init; }
    public required string GuestId { get; init; }
    public required string FullName { get; init; }
    public required CstatiEventWorkflowGuestGenderBff Gender { get; init; }
    public required string TelegramLogin { get; init; }
    public required GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBff PaymentInfo { get; init; }
    public required CstatiEventWorkflowGuestEducationalProgramBff EducationalProgram { get; init; }
    public required string PhoneNumber { get; init; }
    public required bool IsLegalAge { get; init; }
    public required CstatiEventWorkflowTicketTypeBff TicketType { get; init; }
    public bool? TransferIsRequired { get; init; }
}
