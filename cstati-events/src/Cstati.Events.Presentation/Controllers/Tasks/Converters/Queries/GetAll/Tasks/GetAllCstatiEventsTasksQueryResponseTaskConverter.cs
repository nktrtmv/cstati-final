using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Controllers.Tasks.Converters.Contracts.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Presentation.Controllers.Tasks.Converters.Queries.GetAll.Tasks;

internal static class GetAllCstatiEventsTasksQueryResponseTaskConverter
{
    internal static GetAllCstatiEventsTasksQueryResponseTask FromInternal(GetAllCstatiEventsTasksQueryResponseTaskInternal task)
    {
        Timestamp? deadline = NullableConverter.Convert(task.Deadline, UtcDateTimeConverterTo.ToTimestamp);

        CstatiEventTaskStatusDto status = CstatiEventTaskStatusDtoConverter.FromInternal(task.Status);

        var result = new GetAllCstatiEventsTasksQueryResponseTask
        {
            Id = task.Id,
            Name = task.Name,
            ExecutorLogin = task.ExecutorLogin,
            Description = task.Description,
            Deadline = deadline,
            Status = status
        };

        return result;
    }
}
