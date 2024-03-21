using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests.Payments;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests;

internal static class GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternalConverter
{
    internal static GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal FromDomain(int waveOrdinal, CstatiEventWorkflowGuest guest)
    {
        CstatiEventWorkflowGuestGenderInternal gender = CstatiEventWorkflowGuestGenderInternalConverter.FromDomain(guest.Gender);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternal paymentInfo =
            GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestPaymentInfoInternalConverter.FromDomain(guest.PaymentInfo);

        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramInternalConverter.FromDomain(guest.EducationalProgram);

        CstatiEventWorkflowTicketTypeInternal ticketType =
            CstatiEventWorkflowTicketTypeInternalConverter.FromDomain(guest.TicketType);

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal(
            waveOrdinal,
            guest.Id,
            guest.FullName,
            gender,
            guest.TelegramLogin,
            paymentInfo,
            educationalProgram,
            guest.PhoneNumber,
            guest.IsLegalAge,
            ticketType,
            guest.TransferIsRequired);

        return result;
    }
}
