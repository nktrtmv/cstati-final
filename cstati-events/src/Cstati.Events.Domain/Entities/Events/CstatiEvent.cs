using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Domain.Entities.Events;

public class CstatiEvent
{
    public CstatiEvent(string id, CstatiEventInfo info, CstatiEventState state, ConcurrencyToken concurrencyToken)
    {
        Id = id;
        Info = info;
        State = state;
        ConcurrencyToken = concurrencyToken;
    }

    public string Id { get; }
    public CstatiEventInfo Info { get; private set; }
    public CstatiEventState State { get; private set; }
    public ConcurrencyToken ConcurrencyToken { get; }

    public CstatiEventStatus Status => State.Status;

    internal void SetInfo(CstatiEventInfo info)
    {
        Info = info;
    }

    internal void SetState(CstatiEventState state)
    {
        State = state;
    }
}
