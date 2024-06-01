using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States;

public sealed partial class CstatiEventState
{
    internal void UpdateStatus(CstatiEventStatus status)
    {
        Status = status;
    }

    public void AddTask(string name, string executorLogin, string description, UtcDateTime? deadline)
    {
        var task = CstatiEventTask.CreateNew(name, executorLogin, description, deadline);

        Tasks = Tasks.Append(task).ToArray();
    }

    public void UpdateTask(string id, string name, string executorLogin, string description, UtcDateTime? deadline, CstatiEventTaskStatus status)
    {
        var task = CstatiEventTask.CreateFrom(id, name, executorLogin, description, deadline, status);

        Tasks = Tasks.Where(t => t.Id != id).Append(task).ToArray();
    }

    public void DeleteTask(string id)
    {
        Tasks = Tasks.Where(t => t.Id != id).ToArray();
    }
}
