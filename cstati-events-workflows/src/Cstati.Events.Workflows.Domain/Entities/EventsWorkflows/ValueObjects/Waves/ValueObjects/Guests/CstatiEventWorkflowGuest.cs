using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

public sealed class CstatiEventWorkflowGuest
{
    public CstatiEventWorkflowGuest(
        string id,
        string fullName,
        CstatiEventWorkflowGuestGender gender,
        string telegramLogin,
        CstatiEventWorkflowGuestPaymentInfo paymentInfo,
        CstatiEventWorkflowGuestEducationalProgram educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketType ticketType,
        bool? transferIsRequired)
    {
        Id = id;
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

    public string Id { get; }
    public string FullName { get; }
    public CstatiEventWorkflowGuestGender Gender { get; }
    public string TelegramLogin { get; }
    public CstatiEventWorkflowGuestPaymentInfo PaymentInfo { get; }
    public CstatiEventWorkflowGuestEducationalProgram EducationalProgram { get; }
    public string PhoneNumber { get; }
    public bool IsLegalAge { get; }
    public CstatiEventWorkflowTicketType TicketType { get; }
    public bool? TransferIsRequired { get; }
}
