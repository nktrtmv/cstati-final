using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.CommonContractsConverters.TicketsTypes;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Contracts.Genders;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Add.Guests;

internal static class AddCstatiEventsWorkflowsGuestsCommandGuestConverter
{
    internal static AddCstatiEventsWorkflowsGuestsCommandGuestInternal ToInternal(AddCstatiEventsWorkflowsGuestsCommandGuest guest)
    {
        CstatiEventWorkflowGuestGenderInternal gender = CstatiEventWorkflowGuestGenderDtoConverter.ToInternal(guest.Gender);

        CstatiEventWorkflowGuestEducationalProgramInternal educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramDtoConverter.ToInternal(guest.EducationalProgram);

        CstatiEventWorkflowTicketTypeInternal preferredTicketType = CstatiEventWorkflowTicketTypeDtoConverter.ToInternal(guest.PreferredTicketType);

        var result = new AddCstatiEventsWorkflowsGuestsCommandGuestInternal(
            guest.FullName,
            gender,
            guest.TelegramLogin,
            educationalProgram,
            guest.PhoneNumber,
            guest.IsLegalAge,
            preferredTicketType,
            guest.IsTransferRequested);

        return result;
    }
}
