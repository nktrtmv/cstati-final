using Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsWorkflowsTicketsQueryInternalHandler
    : IRequestHandler<GetAllCstatiEventsWorkflowsTicketsQueryInternal, GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsTicketsQueryInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task<GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal> Handle(
        GetAllCstatiEventsWorkflowsTicketsQueryInternal request,
        CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        CstatiEventWorkflowWave wave = workflow.Waves.Single(w => w.Ordinal == request.WaveOrdinal);

        CstatiEventWorkflowTicket[] tickets = wave.Tickets.OrderBy(t => t.Price).ToArray();

        GetAllCstatiEventsWorkflowsTicketsQueryResponseInternal result =
            GetAllCstatiEventsWorkflowsTicketsQueryResponseInternalConverter.FromDomain(tickets, workflow.ConcurrencyToken);

        return result;
    }
}
