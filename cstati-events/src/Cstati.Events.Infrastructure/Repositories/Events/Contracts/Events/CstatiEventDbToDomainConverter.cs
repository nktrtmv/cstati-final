using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.ApplicationEvents;
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

        ApplicationEvent[] applicationEvents = data.ApplicationEvents.Select(ApplicationEventDbConverter.ToDomain).ToArray();

        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromUnspecifiedUtcDateTime(@event.ConcurrencyToken);

        var result = CstatiEvent.CreateFrom(@event.Id, info, state, applicationEvents, concurrencyToken);

        return result;
    }
}
