using Cstati.Events.Application.CstatiEvents.Tasks.Commands.Create.Contracts;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Commands.Create;

internal static class CreateCstatiEventsTasksCommandConverter
{
    internal static CreateCstatiEventsTasksCommandInternal ToInternal(CreateCstatiEventsTasksCommand command)
    {
        UtcDateTime? deadline = NullableConverter.Convert(command.Deadline, UtcDateTimeConverterFrom.FromTimestamp);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new CreateCstatiEventsTasksCommandInternal(command.EventId, command.Name, command.ExecutorLogin, command.Description, deadline, concurrencyToken);

        return result;
    }
}
