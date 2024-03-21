using Cstati.Events.Domain.Entities.Events.ValueObjects.Info;
using Cstati.Events.Domain.Entities.Events.ValueObjects.Info.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.GenericSubdomain.Dates;

namespace Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;

public static class CstatiEventUpdatingContextFactory
{
    public static CstatiEventUpdatingContext CreateWithUpdatedInfo(
        CstatiEvent @event,
        string? excelSheetLink,
        UtcDateTime? date,
        string? location,
        int? expectedGuestsCount,
        CstatiEventStatus status)
    {
        CstatiEventInfo info = CstatiEventInfoFactory.CreateFrom(@event.Info.Name, excelSheetLink, date, location, expectedGuestsCount);

        CstatiEventState state = CstatiEventStateFactory.CreateFrom(status, @event.State.Tasks, @event.State.FinancesDetails);

        var result = new CstatiEventUpdatingContext(info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithNewStatus(CstatiEvent @event, CstatiEventStatus status)
    {
        CstatiEventState state = CstatiEventStateFactory.CreateFrom(status, @event.State.Tasks, @event.State.FinancesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithUpdatedCollected(CstatiEvent @event, double collected)
    {
        CstatiEventFinancesDetails financesDetails = CstatiEventFinancesDetailsFactory.CreateWithUpdatedCollected(@event.State.FinancesDetails, collected);

        CstatiEventState state = CstatiEventStateFactory.CreateFrom(@event.State.Status, @event.State.Tasks, financesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithActualizedRevenue(CstatiEvent @event)
    {
        CstatiEventFinancesDetails financesDetails = CstatiEventFinancesDetailsFactory.CreateWithActualizedRevenue(@event.State.FinancesDetails);

        CstatiEventState state = CstatiEventStateFactory.CreateFrom(@event.State.Status, @event.State.Tasks, financesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithNewTask(CstatiEvent @event, CstatiEventTask task)
    {
        CstatiEventTask[] tasks = @event.State.Tasks.Append(task).ToArray();

        var state = new CstatiEventState(@event.Status, tasks, @event.State.FinancesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithoutTask(CstatiEvent @event, string taskId)
    {
        CstatiEventTask[] tasks = @event.State.Tasks.Where(t => t.Id != taskId).ToArray();

        var state = new CstatiEventState(@event.Status, tasks, @event.State.FinancesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithUpdatedTask(CstatiEvent @event, CstatiEventTask task)
    {
        CstatiEventTask[] tasks = @event.State.Tasks.Where(t => t.Id != task.Id).Append(task).ToArray();

        var state = new CstatiEventState(@event.Status, tasks, @event.State.FinancesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithNewExpense(CstatiEvent @event, CstatiEventExpense expense)
    {
        CstatiEventFinancesDetails financesDetails =
            CstatiEventFinancesDetailsFactory.CreateWithNewExpense(@event.State.FinancesDetails, expense);

        var state = new CstatiEventState(@event.Status, @event.State.Tasks, financesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }

    public static CstatiEventUpdatingContext CreateWithoutExpense(CstatiEvent @event, string expenseId)
    {
        CstatiEventFinancesDetails financesDetails =
            CstatiEventFinancesDetailsFactory.CreateWithoutExpense(@event.State.FinancesDetails, expenseId);

        var state = new CstatiEventState(@event.Status, @event.State.Tasks, financesDetails);

        var result = new CstatiEventUpdatingContext(@event.Info, state);

        return result;
    }
}
