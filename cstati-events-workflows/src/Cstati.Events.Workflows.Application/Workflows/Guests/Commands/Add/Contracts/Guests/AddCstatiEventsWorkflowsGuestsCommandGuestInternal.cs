using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;

public sealed class AddCstatiEventsWorkflowsGuestsCommandGuestInternal
{
    public AddCstatiEventsWorkflowsGuestsCommandGuestInternal(
        string fullName,
        CstatiEventWorkflowGuestGenderInternal gender,
        string telegramLogin,
        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketTypeInternal preferredTicketType,
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

    internal string FullName { get; }
    internal CstatiEventWorkflowGuestGenderInternal Gender { get; }
    internal string TelegramLogin { get; }
    internal CstatiEventWorkflowGuestEducationalProgramInternal EducationalProgram { get; }
    internal string PhoneNumber { get; }
    internal bool IsLegalAge { get; }
    internal CstatiEventWorkflowTicketTypeInternal PreferredTicketType { get; }
    internal bool? TransferIsRequested { get; }
}
