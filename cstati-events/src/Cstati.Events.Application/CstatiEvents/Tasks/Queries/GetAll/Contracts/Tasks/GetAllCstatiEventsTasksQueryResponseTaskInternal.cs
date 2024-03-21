using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;

public sealed class GetAllCstatiEventsTasksQueryResponseTaskInternal
{
    public GetAllCstatiEventsTasksQueryResponseTaskInternal(
        string id,
        string name,
        string executorLogin,
        string description,
        UtcDateTime? deadline,
        CstatiEventTaskStatusInternal status)
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
    public CstatiEventTaskStatusInternal Status { get; }
}
