using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.ApplicationEvents;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.Info;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.State.Statuses;

using Google.Protobuf;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events;

internal static class CstatiEventDbFromDomainConverter
{
    internal static CstatiEventDb FromDomain(CstatiEvent @event)
    {
        var status = CstatiEventStatusDbConverter.ToString(@event.State.Status);

        byte[] data = ToData(@event);

        var concurrencyToken = ConcurrencyTokenConverterTo.ToDateTime(@event.ConcurrencyToken);

        var result = new CstatiEventDb
        {
            Id = @event.Id,
            Name = @event.Info.Name,
            Location = @event.Info.Location,
            Status = status,
            Data = data,
            ConcurrencyToken = concurrencyToken
        };

        return result;
    }

    private static byte[] ToData(CstatiEvent @event)
    {
        CstatiEventInfoDb info = CstatiEventInfoDbConverter.FromDomain(@event.Info);

        CstatiEventStateDb state = CstatiEventStateDbConverter.FromDomain(@event.State);

        ApplicationEventDb[] applicationEvents =
            @event.ApplicationEvents.Select(ApplicationEventDbConverter.FromDomain).ToArray();

        var data = new CstatiEventDataDb
        {
            Info = info,
            State = state,
            ApplicationEvents = { applicationEvents }
        };

        byte[] result = data.ToByteArray();

        return result;
    }
}
