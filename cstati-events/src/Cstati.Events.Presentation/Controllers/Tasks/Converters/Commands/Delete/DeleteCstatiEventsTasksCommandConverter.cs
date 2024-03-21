using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Delete.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Delete;

internal static class DeleteCstatiEventsTasksCommandConverter
{
    internal static DeleteCstatiEventsTasksCommandInternal ToInternal(DeleteCstatiEventsTasksCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsTasksCommandInternal(command.EventId, command.TaskId, concurrencyToken);

        return result;
    }
}
