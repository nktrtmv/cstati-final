using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.EducationalPrograms;
using Cstati.Events.Workflows.Application.Workflows.Guests.Contracts.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.Factories.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.EducationalProgram;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.Genders;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;

internal static class AddCstatiEventsWorkflowsGuestsCommandGuestInternalConverter
{
    internal static CstatiEventWorkflowGuestCreationContext ToDomain(AddCstatiEventsWorkflowsGuestsCommandGuestInternal guest)
    {
        CstatiEventWorkflowGuestGender gender = CstatiEventWorkflowGuestGenderInternalConverter.ToDomain(guest.Gender);

        CstatiEventWorkflowGuestEducationalProgram educationalProgram =
            CstatiEventWorkflowGuestEducationalProgramInternalConverter.ToDomain(guest.EducationalProgram);

        CstatiEventWorkflowTicketType preferredTicketType =
            CstatiEventWorkflowTicketTypeInternalConverter.ToDomain(guest.PreferredTicketType);

        var result = new CstatiEventWorkflowGuestCreationContext(
            guest.FullName,
            gender,
            guest.TelegramLogin,
            educationalProgram,
            guest.PhoneNumber,
            guest.IsLegalAge,
            preferredTicketType,
            guest.TransferIsRequested);

        return result;
    }
}
