using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.CompleteWorkflow;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.StartWorkflow;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Repositories.Contracts;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.ApplicationEvents.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events.Data.ApplicationEvents;

internal static class ApplicationEventDbConverter
{
    internal static ApplicationEventDb FromDomain(ApplicationEvent applicationEvent)
    {
        var id = applicationEvent.Id.ToString();

        ApplicationEventStatusDb status = ApplicationEventStatusDbConverter.FromDomain(applicationEvent.Status);

        var createdAt = applicationEvent.CreatedAt.ToTimestamp();

        var updatedAt = applicationEvent.UpdatedAt.ToTimestamp();

        return applicationEvent switch
        {
            CompleteWorkflowApplicationEvent => new ApplicationEventDb
            {
                Id = id,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
                CompleteWorkflow = new CompleteWorkflowApplicationEventDb()
            },

            StartWorkflowApplicationEvent => new ApplicationEventDb
            {
                Id = id,
                Status = status,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
                StartWorkflow = new StartWorkflowApplicationEventDb()
            },

            _ => throw new ArgumentOutOfRangeException(nameof(applicationEvent))
        };
    }

    internal static ApplicationEvent ToDomain(ApplicationEventDb applicationEvent)
    {
        Guid id = Guid.Parse(applicationEvent.Id);

        ApplicationEventStatus status = ApplicationEventStatusDbConverter.ToDomain(applicationEvent.Status);

        var createdAt = applicationEvent.CreatedAt.ToDateTime();

        var updatedAt = applicationEvent.UpdatedAt.ToDateTime();

        return applicationEvent.EventCase switch
        {
            ApplicationEventDb.EventOneofCase.StartWorkflow =>
                StartWorkflowApplicationEvent.CreateFrom(id, status, createdAt, updatedAt),

            ApplicationEventDb.EventOneofCase.CompleteWorkflow =>
                CompleteWorkflowApplicationEvent.CreateFrom(id, status, createdAt, updatedAt),

            _ => throw new ArgumentOutOfRangeException(nameof(applicationEvent.EventCase), applicationEvent.EventCase, null)
        };
    }
}
