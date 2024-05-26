using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents.Inheritors.StartWorkflow;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;

namespace Cstati.Events.Domain.Entities.Events.Services.Updaters.Statuses;

internal static class CstatiEventStatusUpdater
{
    private static readonly (CstatiEventStatus, CstatiEventStatus)[] ValidTransitions =
    [
        (CstatiEventStatus.NotStarted, CstatiEventStatus.NotStarted),
        (CstatiEventStatus.NotStarted, CstatiEventStatus.InProgress),
        (CstatiEventStatus.InProgress, CstatiEventStatus.InProgress),
        (CstatiEventStatus.InProgress, CstatiEventStatus.Finished)
    ];

    public static void Update(CstatiEvent @event, CstatiEventStatus status)
    {
        if (!ValidTransitions.Contains((@event.State.Status, status)))
        {
            throw new ApplicationException("Invalid status transition");
        }

        if (@event.State.Status == CstatiEventStatus.NotStarted && status == CstatiEventStatus.InProgress)
        {
            var applicationEvent = StartWorkflowApplicationEvent.CreateNew();

            @event.AddApplicationEvent(applicationEvent);
        }

        if (@event.State.Status == CstatiEventStatus.InProgress && status == CstatiEventStatus.Finished)
        {
            var applicationEvent = StartWorkflowApplicationEvent.CreateNew();

            @event.AddApplicationEvent(applicationEvent);
        }

        @event.State.UpdateStatus(status);
    }
}
