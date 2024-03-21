using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll.Contracts;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Queries.GetAll;

public sealed class GetAllCstatiEventsTasksService : CstatiEventsTasksServiceClientBase
{
    public GetAllCstatiEventsTasksService(CstatiEventsTasksService.CstatiEventsTasksServiceClient tasks, IEnumerable<ISourceEnricher> enrichers) : base(tasks)
    {
        Enrichers = enrichers;
    }

    private IEnumerable<ISourceEnricher> Enrichers { get; }

    public async Task<GetAllCstatiEventsTasksQueryResponseBff> GetAll(GetAllCstatiEventsTasksQueryBff queryBff, int limit, CancellationToken cancellationToken)
    {
        GetAllCstatiEventsTasksQuery query = GetAllCstatiEventsTasksQueryBffConverter.ToDto(queryBff, limit);

        GetAllCstatiEventsTasksQueryResponse response = await Tasks.GetAllAsync(query, cancellationToken: cancellationToken);

        var enrichers = new EnrichersContext();

        GetAllCstatiEventsTasksQueryResponseBff result = GetAllCstatiEventsTasksQueryResponseBffConverter.FromDto(response, enrichers);

        await enrichers.Enrich(Enrichers, cancellationToken);

        return result;
    }
}
