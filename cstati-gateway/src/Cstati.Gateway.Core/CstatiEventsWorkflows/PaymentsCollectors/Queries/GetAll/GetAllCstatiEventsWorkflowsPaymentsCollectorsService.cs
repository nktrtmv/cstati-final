using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll.Contracts;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Queries.GetAll;

public sealed class GetAllCstatiEventsWorkflowsPaymentsCollectorsService : CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase
{
    public GetAllCstatiEventsWorkflowsPaymentsCollectorsService(
        CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient guests,
        IEnumerable<ISourceEnricher> enrichers) : base(guests)
    {
        Enrichers = enrichers;
    }

    private IEnumerable<ISourceEnricher> Enrichers { get; }

    public async Task<GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff> GetAll(
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        GetAllCstatiEventsWorkflowsPaymentsCollectorsQuery query = GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryBffConverter.ToDto(queryBff);

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponse response = await PaymentsCollectors.GetAllAsync(query, cancellationToken: cancellationToken);

        var enrichers = new EnrichersContext();

        GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBff result =
            GetAllCstatiEventsWorkflowsPaymentsCollectorsQueryResponseBffConverter.FromDto(response, enrichers);

        await enrichers.Enrich(Enrichers, cancellationToken);

        return result;
    }
}
