using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsTasksQueryResponseInternalConverter
{
    internal static GetAllCstatiEventsTasksQueryResponseInternal FromDomain(CstatiEventTask[] tasks, ConcurrencyToken concurrencyToken)
    {
        GetAllCstatiEventsTasksQueryResponseTaskInternal[] tasksInternal =
            tasks.Select(GetAllCstatiEventsTasksQueryResponseTaskInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiEventsTasksQueryResponseInternal(tasksInternal, concurrencyToken);

        return result;
    }
}
