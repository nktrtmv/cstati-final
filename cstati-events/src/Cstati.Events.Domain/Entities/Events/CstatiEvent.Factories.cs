using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Domain.Entities.Events;

public sealed partial class CstatiEvent
{
    private CstatiEvent(string id, CstatiEventInfo info, CstatiEventState state, List<ApplicationEvent> applicationEvents, ConcurrencyToken concurrencyToken)
    {
        Id = id;
        Info = info;
        State = state;
        _applicationEvents = applicationEvents;
        ConcurrencyToken = concurrencyToken;
    }

    public static CstatiEvent CreateNew(string name)
    {
        var id = Guid.NewGuid().ToString();

        var info = CstatiEventInfo.CreateNew(name);

        var state = CstatiEventState.CreateNew();

        List<ApplicationEvent> applicationEvents = [];

        var concurrencyToken = ConcurrencyToken.Empty;

        var result = new CstatiEvent(id, info, state, applicationEvents, concurrencyToken);

        return result;
    }

    public static CstatiEvent CreateFrom(string id, CstatiEventInfo info, CstatiEventState state, ApplicationEvent[] applicationEvents, ConcurrencyToken concurrencyToken)
    {
        var result = new CstatiEvent(id, info, state, applicationEvents.ToList(), concurrencyToken);

        return result;
    }
}
