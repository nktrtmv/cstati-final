using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets;

namespace Cstati.Gateway.GenericSubdomain.Services.Enrichers;

public sealed class EnrichersContext : List<ITargetEnricher>
{
    public async Task Enrich(IEnumerable<ISourceEnricher> sources, CancellationToken cancellationToken)
    {
        ITargetEnricher[] targetsToEnrich = ToArray();

        foreach (ISourceEnricher source in sources)
        {
            ITargetEnricher[] enrichedTargets = await source.Enrich(targetsToEnrich, cancellationToken);

            targetsToEnrich = targetsToEnrich.Except(enrichedTargets).ToArray();
        }

        if (targetsToEnrich.Any())
        {
            string[] remainingTargetsTypes = targetsToEnrich.Select(t => t.GetType().Name).Distinct().ToArray();

            string remainingTargetsTypesString = string.Join(", ", remainingTargetsTypes);

            throw new ApplicationException(
                $"Failed to enrich the following targets enrichers (count: {remainingTargetsTypesString.Length}, types: {remainingTargetsTypesString})");
        }
    }
}
