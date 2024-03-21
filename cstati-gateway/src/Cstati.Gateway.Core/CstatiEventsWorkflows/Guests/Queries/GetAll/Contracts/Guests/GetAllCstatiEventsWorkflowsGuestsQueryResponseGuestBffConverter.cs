using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests.Payments.Info;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts.Guests;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBffConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBff FromDto(GetAllCstatiEventsWorkflowsGuestsQueryResponseGuest guest)
    {
        CstatiEventWorkflowGuestGenderBff gender = CstatiEventWorkflowGuestGenderBffConverter.FromDto(guest.Gender);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBff paymentInfo =
            GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoBffConverter.FromDto(guest.PaymentInfo);

        CstatiEventWorkflowGuestEducationalProgramBff educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramBffConverter.FromDto(guest.EducationalProgram);

        CstatiEventWorkflowTicketTypeBff ticketType = CstatiEventWorkflowTicketTypeBffConverter.FromDto(guest.TicketType);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestBff
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
