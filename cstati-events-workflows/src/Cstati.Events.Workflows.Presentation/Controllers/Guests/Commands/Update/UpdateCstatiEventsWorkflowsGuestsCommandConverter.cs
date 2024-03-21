using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Update.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.GuestsPaymentStatuses;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.Genders;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Update;

internal static class UpdateCstatiEventsWorkflowsGuestsCommandConverter
{
    internal static UpdateCstatiEventsWorkflowsGuestsCommandInternal ToInternal(UpdateCstatiEventsWorkflowsGuestsCommand command)
    {
        CstatiEventWorkflowGuestGenderInternal gender = CstatiEventWorkflowGuestGenderDtoConverter.ToInternal(command.Gender);

        CstatiEventWorkflowGuestPaymentStatusInternal paymentStatusChangeTo =
            CstatiEventWorkflowGuestPaymentStatusDtoConverter.ToInternal(command.PaymentStatusChangeTo);

        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramDtoConverter.ToInternal(command.EducationalProgram);

        CstatiEventWorkflowTicketTypeInternal ticketType = CstatiEventWorkflowTicketTypeDtoConverter.ToInternal(command.TicketType);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new UpdateCstatiEventsWorkflowsGuestsCommandInternal(
            command.EventId,
            command.GuestId,
            command.FullName,
            gender,
            command.TelegramLogin,
            paymentStatusChangeTo,
            educationalProgram,
            command.PhoneNumber,
            command.IsLegalAge,
            ticketType,
            command.TransferIsRequired,
            concurrencyToken);

        return result;
    }
}
