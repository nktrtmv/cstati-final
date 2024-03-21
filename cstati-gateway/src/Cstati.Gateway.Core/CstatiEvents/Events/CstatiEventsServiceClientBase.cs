using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Events;

public abstract class CstatiEventsServiceClientBase
{
    protected CstatiEventsServiceClientBase(CstatiEventsService.CstatiEventsServiceClient events)
    {
        Events = events;
    }

    protected CstatiEventsService.CstatiEventsServiceClient Events { get; }
}
