using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll;

public sealed class GetAllCstatiEventsWorkflowsWavesService : CstatiEventsWorkflowsWavesServiceClientBase
{
    public GetAllCstatiEventsWorkflowsWavesService(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves) : base(waves)
    {
    }

    public async Task<GetAllCstatiEventsWorkflowsWavesQueryResponseBff> GetAll(
        GetAllCstatiEventsWorkflowsWavesQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        GetAllCstatiEventsWorkflowsWavesQuery query = GetAllCstatiEventsWorkflowsWavesQueryBffConverter.ToDto(queryBff);

        GetAllCstatiEventsWorkflowsWavesQueryResponse? response = await Waves.GetAllAsync(query, cancellationToken: cancellationToken);

        GetAllCstatiEventsWorkflowsWavesQueryResponseBff result = GetAllCstatiEventsWorkflowsWavesQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
