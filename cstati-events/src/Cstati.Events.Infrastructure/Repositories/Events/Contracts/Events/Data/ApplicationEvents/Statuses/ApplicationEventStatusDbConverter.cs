using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Repositories.Contracts;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.ApplicationEvents.Statuses;

internal static class ApplicationEventStatusDbConverter
{
    internal static ApplicationEventStatusDb FromDomain(ApplicationEventStatus status)
    {
        return status switch
        {
            ApplicationEventStatus.InProcess => ApplicationEventStatusDb.InProcess,
            ApplicationEventStatus.Completed => ApplicationEventStatusDb.Completed,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }

    internal static ApplicationEventStatus ToDomain(ApplicationEventStatusDb status)
    {
        return status switch
        {
            ApplicationEventStatusDb.InProcess => ApplicationEventStatus.InProcess,
            ApplicationEventStatusDb.Completed => ApplicationEventStatus.Completed,
            _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
        };
    }
}
