using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.ValueObjects.ApplicationEvents.CompleteWorkflow;
using Cstati.Events.Domain.ValueObjects.ApplicationEvents.StartWorkflow;

namespace Cstati.Events.Domain.Entities.Events.Services.Updaters;

public static class CstatiEventUpdater
{
    private static readonly (CstatiEventStatus, CstatiEventStatus)[] ValidStatusesTransitions =
    {
        (CstatiEventStatus.NotStarted, CstatiEventStatus.NotStarted),
        (CstatiEventStatus.NotStarted, CstatiEventStatus.InProgress),
        (CstatiEventStatus.InProgress, CstatiEventStatus.InProgress),
        (CstatiEventStatus.InProgress, CstatiEventStatus.Finished)
    };

    public static CstatiEventApplicationEvent[] Update(CstatiEvent @event, CstatiEventUpdatingContext context)
    {
        Validate(@event, context);

        CstatiEventApplicationEvent[] applicationEvents = GetApplicationEvents(@event, context);

        @event.SetInfo(context.Info);

        @event.SetState(context.State);

        return applicationEvents;
    }

    private static void Validate(CstatiEvent @event, CstatiEventUpdatingContext context)
    {
        if (!ValidStatusesTransitions.Contains((@event.Status, context.State.Status)))
        {
            throw new ApplicationException("Invalid status transition");
        }

        if (context.State.Status is CstatiEventStatus.InProgress && (context.Info.ExpectedGuestsCount is null || context.Info.ExpectedGuestsCount == 0))
        {
            throw new ApplicationException("Before starting event u should set guests count");
        }
    }

    private static CstatiEventApplicationEvent[] GetApplicationEvents(CstatiEvent @event, CstatiEventUpdatingContext context)
    {
        var applicationEvents = new List<CstatiEventApplicationEvent>();

        if (@event.Status == CstatiEventStatus.NotStarted && context.State.Status == CstatiEventStatus.InProgress)
        {
            var startWorkflow = new StartWorkflowCstatiEventApplicationEvent(@event.Id, context.Info.Name);

            applicationEvents.Add(startWorkflow);
        }

        if (@event.Status == CstatiEventStatus.InProgress && context.State.Status == CstatiEventStatus.Finished)
        {
            var completeWorkflow = new CompleteWorkflowCstatiEventApplicationEvent(@event.Id);

            applicationEvents.Add(completeWorkflow);
        }

        CstatiEventApplicationEvent[] result = applicationEvents.ToArray();

        return result;
    }
}
