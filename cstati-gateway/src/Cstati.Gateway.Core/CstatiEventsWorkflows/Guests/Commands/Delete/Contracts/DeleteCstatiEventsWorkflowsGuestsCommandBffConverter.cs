using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsWorkflowsGuestsCommandBffConverter
{
    internal static DeleteCstatiEventsWorkflowsGuestsCommand ToDto(DeleteCstatiEventsWorkflowsGuestsCommandBff command)
    {
        var result = new DeleteCstatiEventsWorkflowsGuestsCommand
        {
            EventId = command.EventId,
            GuestId = command.GuestId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
