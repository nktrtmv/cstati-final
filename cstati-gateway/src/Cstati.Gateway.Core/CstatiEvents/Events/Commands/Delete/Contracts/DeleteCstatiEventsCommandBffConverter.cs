using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsCommandBffConverter
{
    internal static DeleteCstatiEventsCommand ToDto(DeleteCstatiEventsCommandBff command)
    {
        var result = new DeleteCstatiEventsCommand
        {
            EventId = command.EventId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
