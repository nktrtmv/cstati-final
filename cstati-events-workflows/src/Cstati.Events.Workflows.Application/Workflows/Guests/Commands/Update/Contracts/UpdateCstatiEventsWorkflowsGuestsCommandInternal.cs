using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update.Contracts;

public sealed class UpdateCstatiEventsWorkflowsGuestsCommandInternal : IRequest
{
    public UpdateCstatiEventsWorkflowsGuestsCommandInternal(
        string eventId,
        string guestId,
        string fullName,
        CstatiEventWorkflowGuestGenderInternal gender,
        string telegramLogin,
        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatusChangeTo,
        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram,
        string phoneNumber,
        bool isLegalAge,
        CstatiEventWorkflowTicketTypeInternal ticketType,
        bool? transferIsRequired,
        ConcurrencyToken concurrencyToken)
    {
        EventId = eventId;
        GuestId = guestId;
        FullName = fullName;
        Gender = gender;
        TelegramLogin = telegramLogin;
        PaymentStatusChangeTo = paymentStatusChangeTo;
        EducationalProgram = educationalProgram;
        PhoneNumber = phoneNumber;
        IsLegalAge = isLegalAge;
        TicketType = ticketType;
        TransferIsRequired = transferIsRequired;
        ConcurrencyToken = concurrencyToken;
    }

    internal string EventId { get; }
    internal string GuestId { get; }
    internal string FullName { get; }
    internal CstatiEventWorkflowGuestGenderInternal Gender { get; }
    internal string TelegramLogin { get; }
    internal CstatiEventWorkflowGuestPaymentStatusInternal PaymentStatusChangeTo { get; }
    internal CstatiEventWorkflowGuestEducationalProgramInternal EducationalProgram { get; }
    internal string PhoneNumber { get; }
    internal bool IsLegalAge { get; }
    internal CstatiEventWorkflowTicketTypeInternal TicketType { get; }
    internal bool? TransferIsRequired { get; }
    internal ConcurrencyToken ConcurrencyToken { get; }
}
