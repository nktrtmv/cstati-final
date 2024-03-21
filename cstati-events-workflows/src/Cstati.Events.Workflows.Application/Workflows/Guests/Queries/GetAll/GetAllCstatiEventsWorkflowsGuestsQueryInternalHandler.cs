using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll.Contracts.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsWorkflowsGuestsQueryInternalHandler
    : IRequestHandler<GetAllCstatiEventsWorkflowsGuestsQueryInternal, GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsGuestsQueryInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task<GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal> Handle(
        GetAllCstatiEventsWorkflowsGuestsQueryInternal request,
        CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        Dictionary<int, CstatiEventWorkflowGuest[]> guests = workflow.Waves
            .Where(w => request.WaveOrdinal is null || w.Ordinal == request.WaveOrdinal)
            .ToDictionary(w => w.Ordinal, w => w.Guests);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternal[] guestsInternal =
            guests.SelectMany(
                    g => g.Value.Select(
                        guest =>
                            GetAllCstatiEventsWorkflowsGuestsQueryResponseGuestInternalConverter.FromDomain(g.Key, guest)))
                .ToArray();

        var result = new GetAllCstatiEventsWorkflowsGuestsQueryResponseInternal(guestsInternal, workflow.ConcurrencyToken);

        return result;
    }
}
