using Cstati.Events.Domain.Entities.Events.Services.Updaters.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.ApplicationEvents;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.ValueObjects.Events.Updates;

namespace Cstati.Events.Domain.Entities.Events;

public sealed partial class CstatiEvent
{
    public void Update(CstatiEventUpdate update)
    {
        var info = CstatiEventInfo.CreateFrom(Info.Name, update.ExcelSheetLink, update.Date, update.Location, update.ExpectedGuestsCount);

        Info = info;

        CstatiEventStatusUpdater.Update(this, update.Status);
    }

    internal void AddApplicationEvent(ApplicationEvent applicationEvent)
    {
        _applicationEvents.Add(applicationEvent);
    }
}
