using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails.Contracts;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Queries.GetDetails;

public sealed class GetDetailsCstatiEventsFinancesService : CstatiEventsFinancesServiceClientBase
{
    public GetDetailsCstatiEventsFinancesService(CstatiEventsFinancesService.CstatiEventsFinancesServiceClient finances, IEnumerable<ISourceEnricher> enrichers)
        : base(finances)
    {
        Enrichers = enrichers;
    }

    private IEnumerable<ISourceEnricher> Enrichers { get; }

    public async Task<GetDetailsCstatiEventsFinancesQueryResponseBff> GetDetails(
        GetDetailsCstatiEventsFinancesQueryBff queryBff,
        int expensesLimit,
        CancellationToken cancellationToken)
    {
        GetDetailsCstatiEventsFinancesQuery query = GetDetailsCstatiEventsFinancesQueryBffConverter.ToDto(queryBff, expensesLimit);

        GetDetailsCstatiEventsFinancesQueryResponse response = await Finances.GetDetailsAsync(query, cancellationToken: cancellationToken);

        var enrichers = new EnrichersContext();

        GetDetailsCstatiEventsFinancesQueryResponseBff result = GetDetailsCstatiEventsFinancesQueryResponseBffConverter.FromDto(response, enrichers);

        await enrichers.Enrich(Enrichers, cancellationToken);

        return result;
    }
}
