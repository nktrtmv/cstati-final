using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.Factories;

public static class CstatiEventTaskFactory
{
    public static CstatiEventTask CreateNew(string name, string executorLogin, string description, UtcDateTime? deadline)
    {
        var id = Guid.NewGuid().ToString();

        const CstatiEventTaskStatus status = CstatiEventTaskStatus.NotStarted;

        var result = new CstatiEventTask(id, name, executorLogin, description, deadline, status);

        return result;
    }

    public static CstatiEventTask CreateFrom(string id, string name, string executorLogin, string description, UtcDateTime? deadline, CstatiEventTaskStatus status)
    {
        var result = new CstatiEventTask(id, name, executorLogin, description, deadline, status);

        return result;
    }
}
