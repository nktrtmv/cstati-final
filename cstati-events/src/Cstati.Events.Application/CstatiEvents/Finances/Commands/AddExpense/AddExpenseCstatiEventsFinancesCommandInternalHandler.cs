using Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense.Contracts;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails.ValueObjects.Expenses.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.AddExpense;

[UsedImplicitly]
internal sealed class AddExpenseCstatiEventsFinancesCommandInternalHandler : IRequestHandler<AddExpenseCstatiEventsFinancesCommandInternal>
{
    public AddExpenseCstatiEventsFinancesCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(AddExpenseCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventExpense expense = CstatiEventExpenseFactory.CreateNew(request.PersonLogin, request.Description, request.Amount, request.Market);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithNewExpense(@event, expense);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
