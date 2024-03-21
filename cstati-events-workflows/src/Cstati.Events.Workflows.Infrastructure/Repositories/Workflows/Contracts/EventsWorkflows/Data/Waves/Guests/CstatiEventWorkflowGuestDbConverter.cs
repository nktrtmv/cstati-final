using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.EducationalProgram;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.Genders;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests.PaymentsInfo;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Tickets.Types;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows.Data.Waves.Guests;

internal static class CstatiEventWorkflowGuestDbConverter
{
    internal static CstatiEventWorkflowGuestDb FromDomain(CstatiEventWorkflowGuest guest)
    {
        CstatiEventWorkflowGuestGenderDb gender = CstatiEventWorkflowGuestGenderDbConverter.FromDomain(guest.Gender);

        CstatiEventWorkflowGuestPaymentInfoDb paymentInfo = CstatiEventWorkflowGuestPaymentInfoDbConverter.FromDomain(guest.PaymentInfo);

        CstatiEventWorkflowGuestEducationalProgramDb educationalProgram = CstatiEventWorkflowGuestEducationalProgramDbConverter.FromDomain(guest.EducationalProgram);

        CstatiEventWorkflowTicketTypeDb ticketType = CstatiEventWorkflowTicketTypeDbConverter.FromDomain(guest.TicketType);

        var result = new CstatiEventWorkflowGuestDb
        {
            Id = guest.Id,
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

    internal static CstatiEventWorkflowGuest ToDomain(CstatiEventWorkflowGuestDb guest)
    {
        CstatiEventWorkflowGuestGender gender = CstatiEventWorkflowGuestGenderDbConverter.ToDomain(guest.Gender);

        CstatiEventWorkflowGuestPaymentInfo paymentInfo = CstatiEventWorkflowGuestPaymentInfoDbConverter.ToDomain(guest.PaymentInfo);

        CstatiEventWorkflowGuestEducationalProgram educationalProgram = CstatiEventWorkflowGuestEducationalProgramDbConverter.ToDomain(guest.EducationalProgram);

        CstatiEventWorkflowTicketType ticketType = CstatiEventWorkflowTicketTypeDbConverter.ToDomain(guest.TicketType);

        var result = new CstatiEventWorkflowGuest(
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
