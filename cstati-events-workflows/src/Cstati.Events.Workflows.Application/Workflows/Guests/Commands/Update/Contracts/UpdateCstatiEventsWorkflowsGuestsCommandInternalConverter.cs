using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update.Contracts;

internal static class UpdateCstatiEventsWorkflowsGuestsCommandInternalConverter
{
    internal static CstatiEventWorkflowGuest ToDomain(UpdateCstatiEventsWorkflowsGuestsCommandInternal command, CstatiEventWorkflowGuest obsoleteGuest)
    {
        CstatiEventWorkflowGuestGender gender = CstatiEventWorkflowGuestGenderInternalConverter.ToDomain(command.Gender);

        CstatiEventWorkflowGuestEducationalProgram educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramInternalConverter.ToDomain(command.EducationalProgram);

        CstatiEventWorkflowGuestPaymentStatus paymentStatusChangeTo =
            CstatiEventWorkflowGuestPaymentStatusInternalConverter.ToDomain(command.PaymentStatusChangeTo);

        CstatiEventWorkflowTicketType ticketType =
            CstatiEventWorkflowTicketTypeInternalConverter.ToDomain(command.TicketType);

        CstatiEventWorkflowGuest result = CstatiEventWorkflowGuestFactory.CreateFrom(
            obsoleteGuest,
            command.GuestId,
            command.FullName,
            gender,
            command.TelegramLogin,
            paymentStatusChangeTo,
            educationalProgram,
            command.PhoneNumber,
            command.IsLegalAge,
            ticketType,
            command.TransferIsRequired);

        return result;
    }
}
