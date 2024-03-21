using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.Delete.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Guests.Commands.Delete;

internal static class DeleteCstatiEventsWorkflowsGuestsCommandConverter
{
    internal static DeleteCstatiEventsWorkflowsGuestsCommandInternal ToInternal(DeleteCstatiEventsWorkflowsGuestsCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsWorkflowsGuestsCommandInternal(command.EventId, command.GuestId, concurrencyToken);

        return result;
    }
}
