using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Gateway.GenericSubdomain.Services.Converters;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update.Contracts;

internal static class UpdateCstatiEventsTasksCommandBffConverter
{
    internal static UpdateCstatiEventsTasksCommand ToDto(UpdateCstatiEventsTasksCommandBff command)
    {
        Timestamp? deadline = NullableConverter.Convert(command.Deadline, Timestamp.FromDateTime);

        CstatiEventTaskStatusDto status = CstatiEventTaskStatusBffConverter.ToDto(command.Status);

        var result = new UpdateCstatiEventsTasksCommand
        {
            EventId = command.EventId,
            TaskId = command.TaskId,
            Name = command.Name,
            ExecutorLogin = command.ExecutorLogin,
            Description = command.Description,
            Deadline = deadline,
            Status = status,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
