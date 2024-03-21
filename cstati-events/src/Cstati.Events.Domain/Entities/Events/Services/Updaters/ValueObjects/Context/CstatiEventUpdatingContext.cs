using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;

namespace Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;

public sealed class CstatiEventUpdatingContext
{
    internal CstatiEventUpdatingContext(CstatiEventInfo info, CstatiEventState state)
    {
        Info = info;
        State = state;
    }

    internal CstatiEventInfo Info { get; }
    internal CstatiEventState State { get; }
}
