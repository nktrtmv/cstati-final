using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests.PaymentInfo;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Queries.GetAll.Guests;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuest FromInternal(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal guest)
    {
        CstatiEventWorkflowGuestGenderDto gender = CstatiEventWorkflowGuestGenderDtoConverter.FromInternal(guest.Gender);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfo paymentInfo =
            GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoConverter.FromInternal(guest.PaymentInfo);

        CstatiEventWorkflowGuestEducationalProgramDto educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramDtoConverter.FromInternal(guest.EducationalProgram);

        CstatiEventWorkflowTicketTypeDto ticketType = CstatiEventWorkflowTicketTypeDtoConverter.FromInternal(guest.TicketType);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuest
        {
            WaveOrdinal = guest.WaveOrdinal,
            GuestId = guest.GuestId,
            FullName = guest.FullName,
            Gender = gender,
            TelegramLogin = guest.TelegramLogin,
            PaymentInfo = paymentInfo,
            EducationalProgram = educationalProgram,
            PhoneNumber = guest.PhoneNumber,
            IsLegalAge = guest.IsLegalAge,
            TicketType = ticketType,
            TransferIsRequired = guest.TransferIsRequired
        };

        return result;
    }
}
