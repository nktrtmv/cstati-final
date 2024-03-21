namespace Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets.Generics;

public abstract class TargetEnricherGeneric<TKey, TValue> : ITargetEnricher where TKey : notnull
{
    public abstract void CollectKeys(List<TKey> keys);
    public abstract void EnrichTargets(Dictionary<TKey, TValue> values);
}
