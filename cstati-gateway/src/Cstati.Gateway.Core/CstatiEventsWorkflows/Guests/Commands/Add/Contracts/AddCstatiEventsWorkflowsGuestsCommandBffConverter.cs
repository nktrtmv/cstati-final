using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts.Guests;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts;

internal static class AddCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static AddCstatiEventsWorkflowsGuestsCommand ToDto(AddCstatiEventsWorkflowsGuestsCommandBff command)
    {
        AddCstatiEventsWorkflowsGuestsCommandGuest guest = AddCstatiEventsWorkflowsGuestsCommandGuestBffConverter.ToDto(command.Guest);

        var result = new AddCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            Guests = { guest },
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
