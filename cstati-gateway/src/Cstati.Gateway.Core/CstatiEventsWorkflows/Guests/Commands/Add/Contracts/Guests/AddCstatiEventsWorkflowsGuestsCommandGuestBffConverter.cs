using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Contracts.Workflows.Tickets.Types;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.EducationalPrograms;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Contracts.Guests.Genders;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts.Guests;

internal static class AddCstatiEventsWorkflowsGuestsCommandGuestBffConverter
{
    internal static AddCstatiEventsWorkflowsGuestsCommandGuest ToDto(AddCstatiEventsWorkflowsGuestsCommandGuestBff command)
    {
        CstatiEventWorkflowGuestGenderDto gender = CstatiEventWorkflowGuestGenderBffConverter.ToDto(command.Gender);

        CstatiEventWorkflowGuestEducationalProgramDto educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramBffConverter.ToDto(command.EducationalProgram);

        CstatiEventWorkflowTicketTypeDto preferredTicketType = CstatiEventWorkflowTicketTypeBffConverter.ToDto(command.PreferredTicketType);

        var result = new AddCstatiEventsWorkflowsGuestsCommandGuest
        {
            FullName = command.FullName,
            Gender = gender,
            TelegramLogin = command.TelegramLogin,
            EducationalProgram = educationalProgram,
            PhoneNumber = command.PhoneNumber,
            IsLegalAge = command.IsLegalAge,
            PreferredTicketType = preferredTicketType,
            IsTransferRequested = command.IsTransferRequested
        };

        return result;
    }
}
