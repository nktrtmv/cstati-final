using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Guests.Payments.Status;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update.Contracts;

internal static class UpdateCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static UpdateCstatiEventsWorkflowsGuestsCommand ToDto(UpdateCstatiEventsWorkflowsGuestsCommandBff command)
    {
        CstatiEventWorkflowGuestGenderDto gender =
            CstatiEventWorkflowGuestGenderBffConverter.ToDto(command.Gender);

        CstatiEventWorkflowGuestPaymentStatusDto paymentStatusChangeTo =
            CstatiEventWorkflowGuestPaymentStatusBffConverter.ToDto(command.PaymentStatusChangeTo);

        CstatiEventWorkflowGuestEducationalProgramDto educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramBffConverter.ToDto(command.EducationalProgram);

        CstatiEventWorkflowTicketTypeDto ticketType =
            CstatiEventWorkflowTicketTypeBffConverter.ToDto(command.TicketType);

        var result = new UpdateCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            GuestId = command.GuestId,
            FullName = command.FullName,
            Gender = gender,
            TelegramLogin = command.TelegramLogin,
            PaymentStatusChangeTo = paymentStatusChangeTo,
            EducationalProgram = educationalProgram,
            PhoneNumber = command.PhoneNumber,
            IsLegalAge = command.IsLegalAge,
            TicketType = ticketType,
            TransferIsRequired = command.TransferIsRequired,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
