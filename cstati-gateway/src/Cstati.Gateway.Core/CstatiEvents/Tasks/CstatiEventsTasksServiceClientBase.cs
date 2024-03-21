using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks;

public abstract class CstatiEventsTasksServiceClientBase
{
    protected CstatiEventsTasksServiceClientBase(CstatiEventsTasksService.CstatiEventsTasksServiceClient tasks)
    {
        Tasks = tasks;
    }

    protected CstatiEventsTasksService.CstatiEventsTasksServiceClient Tasks { get; }
}
