using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;

namespace Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

public interface ICstatiEventsRepository
{
    Task Upsert(CstatiEvent @event, CancellationToken cancellationToken);
    Task Delete(string eventId, ConcurrencyToken concurrencyToken, CancellationToken cancellationToken);
    Task<CstatiEvent> GetRequired(string eventId, CancellationToken cancellationToken);
    Task<CstatiEvent[]> GetAll(GetAllCstatiEventsQuery query, CancellationToken cancellationToken);
}
