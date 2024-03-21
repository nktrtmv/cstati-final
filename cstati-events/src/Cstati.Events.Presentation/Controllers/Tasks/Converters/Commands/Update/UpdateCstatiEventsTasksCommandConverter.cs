using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Update.Contracts;
using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Contracts.Statuses;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Update;

internal static class UpdateCstatiEventsTasksCommandConverter
{
    internal static UpdateCstatiEventsTasksCommandInternal ToInternal(UpdateCstatiEventsTasksCommand command)
    {
        UtcDateTime? deadline = NullableConverter.Convert(command.Deadline, UtcDateTimeConverterFrom.FromTimestamp);

        CstatiEventTaskStatusInternal status = CstatiEventTaskStatusDtoConverter.ToInternal(command.Status);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new UpdateCstatiEventsTasksCommandInternal(
            command.EventId,
            command.TaskId,
            command.Name,
            command.ExecutorLogin,
            command.Description,
            deadline,
            status,
            concurrencyToken);

        return result;
    }
}
