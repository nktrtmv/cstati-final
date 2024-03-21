using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets.Generics;

using Microsoft.Extensions.Logging;

namespace Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources.Generics;

public abstract class SourceEnricherGeneric<TClient, TEnricher, TKey, TValue> : ISourceEnricher
    where TEnricher : TargetEnricherGeneric<TKey, TValue>
    where TKey : notnull
{
    protected SourceEnricherGeneric(TClient client, ILogger<SourceEnricherGeneric<TClient, TEnricher, TKey, TValue>> logger)
    {
        Client = client;
        Logger = logger;
    }

    protected TClient Client { get; }
    protected ILogger<SourceEnricherGeneric<TClient, TEnricher, TKey, TValue>> Logger { get; }

    async Task<ITargetEnricher[]> ISourceEnricher.Enrich(ITargetEnricher[] targets, CancellationToken cancellationToken)
    {
        TEnricher[] enriched = targets.OfType<TEnricher>().ToArray();

        await Enrich(enriched, cancellationToken);

        ITargetEnricher[] result = enriched.Cast<ITargetEnricher>().ToArray();

        return result;
    }

    protected abstract Task Enrich(TEnricher[] enrichers, CancellationToken cancellationToken);

    protected static TKey[] CollectDistinctKeys(TEnricher[] enrichers)
    {
        var keys = new List<TKey>();

        foreach (TEnricher enricher in enrichers)
        {
            enricher.CollectKeys(keys);
        }

        TKey[] result = keys.Distinct().ToArray();

        return result;
    }

    protected void EnrichTargetModels(TEnricher[] enrichers, Dictionary<TKey, TValue> values)
    {
        foreach (TEnricher enricher in enrichers)
        {
            try
            {
                enricher.EnrichTargets(values);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "ERROR: ⭕️ Failed to enrich {@enricher} ({enricher:l}). Keys {@keys}", enricher.GetType(), enricher.ToString(), values.Keys);
            }
        }
    }
}
