using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets;

namespace Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources;

public interface ISourceEnricher
{
    Task<ITargetEnricher[]> Enrich(ITargetEnricher[] targets, CancellationToken cancellationToken);
}
