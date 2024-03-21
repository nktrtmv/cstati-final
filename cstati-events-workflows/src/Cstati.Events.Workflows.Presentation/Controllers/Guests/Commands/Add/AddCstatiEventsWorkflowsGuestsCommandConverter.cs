using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Add.Contracts.Guests;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Add.Guests;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Add;

internal static class AddCstatiEventsWorkflowsGuestsCommandConverter
{
    internal static AddCstatiEventsWorkflowsGuestsCommandInternal ToInternal(AddCstatiEventsWorkflowsGuestsCommand command)
    {
        AddCstatiEventsWorkflowsGuestsCommandGuestInternal[] guests =
            command.Guests.Select(AddCstatiEventsWorkflowsGuestsCommandGuestConverter.ToInternal).ToArray();

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new AddCstatiEventsWorkflowsGuestsCommandInternal(command.EventId, guests, concurrencyToken);

        return result;
    }
}
