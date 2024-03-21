using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;

internal static class GetAllCstatiEventsTasksQueryResponseTaskInternalConverter
{
    internal static GetAllCstatiEventsTasksQueryResponseTaskInternal FromDomain(CstatiEventTask task)
    {
        CstatiEventTaskStatusInternal status = CstatiEventTaskStatusInternalConverter.FromDomain(task.Status);

        var result = new GetAllCstatiEventsTasksQueryResponseTaskInternal(task.Id, task.Name, task.ExecutorLogin, task.Description, task.Deadline, status);

        return result;
    }
}
