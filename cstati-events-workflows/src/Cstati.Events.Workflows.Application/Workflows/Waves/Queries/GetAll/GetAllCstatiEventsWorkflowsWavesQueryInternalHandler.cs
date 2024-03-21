using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsWorkflowsWavesQueryInternalHandler
    : IRequestHandler<GetAllCstatiEventsWorkflowsWavesQueryInternal, GetAllCstatiEventsWorkflowsWavesQueryResponseInternal>
{
    public GetAllCstatiEventsWorkflowsWavesQueryInternalHandler(ICstatiEventsWorkflowsRepository workflows)
    {
        Workflows = workflows;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }

    public async Task<GetAllCstatiEventsWorkflowsWavesQueryResponseInternal> Handle(
        GetAllCstatiEventsWorkflowsWavesQueryInternal request,
        CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        GetAllCstatiEventsWorkflowsWavesQueryResponseInternal result =
            GetAllCstatiEventsWorkflowsWavesQueryResponseInternalConverter.FromDomain(workflow.Waves, workflow.ConcurrencyToken);

        return result;
    }
}
