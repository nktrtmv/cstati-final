using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsTasksCommandBffConverter
{
    internal static DeleteCstatiEventsTasksCommand ToDto(DeleteCstatiEventsTasksCommandBff command)
    {
        var result = new DeleteCstatiEventsTasksCommand
        {
            EventId = command.EventId,
            TaskId = command.TaskId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
