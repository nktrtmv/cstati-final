using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;

public sealed class GetAllCstatiEventsTasksQueryResponseInternal
{
    internal GetAllCstatiEventsTasksQueryResponseInternal(GetAllCstatiEventsTasksQueryResponseTaskInternal[] tasks, ConcurrencyToken concurrencyToken)
    {
        Tasks = tasks;
        ConcurrencyToken = concurrencyToken;
    }

    public GetAllCstatiEventsTasksQueryResponseTaskInternal[] Tasks { get; }
    public ConcurrencyToken ConcurrencyToken { get; }
}
