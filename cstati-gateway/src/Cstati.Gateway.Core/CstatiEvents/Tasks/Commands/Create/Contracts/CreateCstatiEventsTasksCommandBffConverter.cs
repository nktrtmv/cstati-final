using Cstati.Events.Presentation.Abstractions;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create.Contracts;

internal static class CreateCstatiEventsTasksCommandBffConverter
{
    internal static CreateCstatiEventsTasksCommand ToDto(CreateCstatiEventsTasksCommandBff command)
    {
        Timestamp deadline = Timestamp.FromDateTime(command.Deadline);

        var result = new CreateCstatiEventsTasksCommand
        {
            EventId = command.EventId,
            Name = command.Name,
            ExecutorLogin = command.ExecutorLogin,
            Description = command.Description,
            Deadline = deadline,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
