using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain;
using Cstati.Events.GenericSubdomain.Dates;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Tasks.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Tasks;

internal static class CstatiEventTaskDbConverter
{
    internal static CstatiEventTaskDb FromDomain(CstatiEventTask task)
    {
        Timestamp? deadline = NullableConverter.Convert(task.Deadline, UtcDateTimeConverterTo.ToTimestamp);

        CstatiEventTaskStatusDb status = CstatiEventTaskStatusDbConverter.FromDomain(task.Status);

        var result = new CstatiEventTaskDb
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

    internal static CstatiEventTask ToDomain(CstatiEventTaskDb task)
    {
        UtcDateTime? deadline = NullableConverter.Convert(task.Deadline, UtcDateTimeConverterFrom.FromTimestamp);

        CstatiEventTaskStatus status = CstatiEventTaskStatusDbConverter.ToDomain(task.Status);

        var result = CstatiEventTask.CreateFrom(task.Id, task.Name, task.ExecutorLogin, task.Description, deadline, status);

        return result;
    }
}
