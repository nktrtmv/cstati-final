using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests;

public sealed class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal
{
    internal GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal(
        int waveOrdinal,
        string guestId,
        string fullName,
        CstatiEventWorkflowGuestGenderInternal gender,
        string telegramLogin,
        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal paymentInfo,
        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketTypeInternal ticketType,
        bool? transferIsRequired)
    {
        WaveOrdinal = waveOrdinal;
        GuestId = guestId;
        FullName = fullName;
        Gender = gender;
        TelegramLogin = telegramLogin;
        PaymentInfo = paymentInfo;
        EducationalProgram = educationalProgram;
        PhoneNumber = phoneNumber;
        IsLegalAge = isLegalAge;
        TicketType = ticketType;
        TransferIsRequired = transferIsRequired;
    }

    public int WaveOrdinal { get; }
    public string GuestId { get; }
    public string FullName { get; }
    public CstatiEventWorkflowGuestGenderInternal Gender { get; }
    public string TelegramLogin { get; }
    public GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal PaymentInfo { get; }
    public CstatiEventWorkflowGuestEducationalProgramInternal EducationalProgram { get; }
    public string PhoneNumber { get; }
    public bool IsLegalAge { get; }
    public CstatiEventWorkflowTicketTypeInternal TicketType { get; }
    public bool? TransferIsRequired { get; }
}
