using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.Factories;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Domain.Entities.Events.Factories;

public static class CstatiEventFactory
{
    public static CstatiEvent CreateNew(string name)
    {
        var id = Guid.NewGuid().ToString();

        CstatiEventInfo info = CstatiEventInfoFactory.CreateNew(name);

        CstatiEventState state = CstatiEventStateFactory.CreateNew();

        var concurrencyToken = ConcurrencyToken.Empty;

        var result = new CstatiEvent(id, info, state, concurrencyToken);

        return result;
    }
}
