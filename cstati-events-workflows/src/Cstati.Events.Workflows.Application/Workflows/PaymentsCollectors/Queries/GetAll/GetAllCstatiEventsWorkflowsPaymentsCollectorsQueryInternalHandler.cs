using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternalHandler
    : IRequestHandler<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal, GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal> Handle(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryInternal request,
        CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        Dictionary<string, CstatiEventWorkflowGuest> guests = workflow.Waves.SelectMany(w => w.Guests).ToDictionary(g => g.Id);

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternal result =
            GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseInternalConverter.FromDomain(workflow.PaymentCollectors, guests, workflow.ConcurrencyToken);

        return result;
    }
}
