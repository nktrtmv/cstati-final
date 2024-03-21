using Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense.Contracts;
using Cstati.Events.Application.Services;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Domain.Entities.Events.Services.Updaters.ValueObjects.Context.Factories;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Finances.Commands.DeleteExpense;

[UsedImplicitly]
internal sealed class DeleteExpenseCstatiEventsFinancesCommandInternalHandler : IRequestHandler<DeleteExpenseCstatiEventsFinancesCommandInternal>
{
    public DeleteExpenseCstatiEventsFinancesCommandInternalHandler(CstatiEventsFacade events)
    {
        Events = events;
    }

    private CstatiEventsFacade Events { get; }

    public async Task Handle(DeleteExpenseCstatiEventsFinancesCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        @event.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventUpdatingContext updatingContext = CstatiEventUpdatingContextFactory.CreateWithoutExpense(@event, request.ExpenseId);

        await Events.Update(@event, updatingContext, cancellationToken);
    }
}
