using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories.ValueObjects.Context;

public sealed class CstatiEventWorkflowGuestCreationContext
{
    public CstatiEventWorkflowGuestCreationContext(
        string fullName,
        CstatiEventWorkflowGuestGender gender,
        string telegramLogin,
        CstatiEventWorkflowGuestEducationalProgram educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketType preferredTicketType,
        bool? transferIsRequested)
    {
        FullName = fullName;
        Gender = gender;
        TelegramLogin = telegramLogin;
        EducationalProgram = educationalProgram;
        PhoneNumber = phoneNumber;
        IsLegalAge = isLegalAge;
        PreferredTicketType = preferredTicketType;
        TransferIsRequested = transferIsRequested;
    }

    public string FullName { get; }
    public CstatiEventWorkflowGuestGender Gender { get; }
    public string TelegramLogin { get; }
    public CstatiEventWorkflowGuestEducationalProgram EducationalProgram { get; }
    public string PhoneNumber { get; }
    public bool IsLegalAge { get; }
    public CstatiEventWorkflowTicketType PreferredTicketType { get; }
    public bool? TransferIsRequested { get; }
}
