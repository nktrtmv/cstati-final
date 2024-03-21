using Cstati.Events.Application.CstatiEvents.Tasks.Contracts.Tasks.Statuses;
using Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks.ValueObjects.Statuses;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Tasks.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsTasksQueryInternalHandler : IRequestHandler<GetAllCstatiEventsTasksQueryInternal, GetAllCstatiEventsTasksQueryResponseInternal>
{
    public GetAllCstatiEventsTasksQueryInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task<GetAllCstatiEventsTasksQueryResponseInternal> Handle(GetAllCstatiEventsTasksQueryInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = await Events.GetRequired(request.EventId, cancellationToken);

        CstatiEventTaskStatus[] statusesFilter =
            request.StatusesFilter.Select(CstatiEventTaskStatusInternalConverter.ToDomain).ToArray();

        CstatiEventTask[] tasks =
            (statusesFilter.Any()
                ? @event.State.Tasks.Where(t => statusesFilter.Contains(t.Status))
                : @event.State.Tasks)
            .Take(request.Limit)
            .ToArray();

        GetAllCstatiEventsTasksQueryResponseInternal result =
            GetAllCstatiEventsTasksQueryResponseInternalConverter.FromDomain(tasks, @event.ConcurrencyToken);

        return result;
    }
}
