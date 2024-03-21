using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

public sealed class CstatiEventTask
{
    public CstatiEventTask(string id, string name, string executorLogin, string description, UtcDateTime? deadline, CstatiEventTaskStatus status)
    {
        Id = id;
        Name = name;
        ExecutorLogin = executorLogin;
        Description = description;
        Deadline = deadline;
        Status = status;
    }

    public string Id { get; }
    public string Name { get; }
    public string ExecutorLogin { get; }
    public string Description { get; }
    public UtcDateTime? Deadline { get; }
    public CstatiEventTaskStatus Status { get; }
}
