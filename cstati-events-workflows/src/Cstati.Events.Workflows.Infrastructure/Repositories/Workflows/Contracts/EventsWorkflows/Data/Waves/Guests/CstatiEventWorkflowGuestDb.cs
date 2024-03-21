using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.EducationalProgram;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.Genders;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets.Types;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests;

public sealed class CstatiEventWorkflowGuestDb
{
    public required string Id { get; init; }
    public required string FullName { get; init; }
    public required CstatiEventWorkflowGuestGenderDb Gender { get; init; }
    public required string TelegramLogin { get; init; }
    public required CstatiEventWorkflowGuestPaymentInfoDb PaymentInfo { get; init; }
    public required CstatiEventWorkflowGuestEducationalProgramDb EducationalProgram { get; init; }
    public required string PhoneNumber { get; init; }
    public required bool IsLegalAge { get; init; }
    public required CstatiEventWorkflowTicketTypeDb TicketType { get; init; }
    public required bool? TransferIsRequired { get; init; }
}
