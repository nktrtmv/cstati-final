using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.Info;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events;

internal static class CstatiEventDbToDomainConverter
{
    internal static CstatiEvent ToDomain(CstatiEventDb @event)
    {
        CstatiEventDataDb data = CstatiEventDataDb.Parser.ParseFrom(@event.Data);

        CstatiEventInfo info = CstatiEventInfoDbConverter.ToDomain(data.Info);

        CstatiEventState state = CstatiEventStateDbConverter.ToDomain(data.State);

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromUnspecifiedUtcDateTime(@event.ConcurrencyToken);

        var result = new CstatiEvent(@event.Id, info, state, concurrencyToken);

        return result;
    }
}
