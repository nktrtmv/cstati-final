using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets.Generics;

using Microsoft.Extensions.Logging;

namespace Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources.Generics.SingleKey;

public abstract class SingleKeySourceEnricherGeneric<TClient, TEnricher, TKey, TValue>
    : SourceEnricherGeneric<TClient, TEnricher, TKey, TValue>
    where TEnricher : TargetEnricherGeneric<TKey, TValue>
    where TKey : notnull
{
    protected SingleKeySourceEnricherGeneric(TClient client, ILogger<SourceEnricherGeneric<TClient, TEnricher, TKey, TValue>> logger) : base(client, logger)
    {
    }

    protected abstract Task<Dictionary<TKey, TValue>> GetValues(TKey[] keys, CancellationToken cancellationToken);

    protected override async Task Enrich(TEnricher[] enrichers, CancellationToken cancellationToken)
    {
        TKey[] keys = CollectDistinctKeys(enrichers);

        Dictionary<TKey, TValue> values = await GetValues(keys, cancellationToken);

        TKey[] missingKeys = keys.Except(values.Keys).ToArray();

        if (missingKeys.Any())
        {
            Logger.LogError("ERROR: ⭕️ Failed to get values for (source enricher: {@Enricher}, keys: {@Keys}", GetType().Name, missingKeys);
        }

        EnrichTargetModels(enrichers, values);
    }
}
