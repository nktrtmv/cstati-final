using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.Common.Persons.Factories;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets.Generics.SingleValue;

namespace Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Targets;

public sealed class PersonsTargetEnricher : SingleValueTargetEnricherGeneric<string, CstatiAccountDto>
{
    private PersonsTargetEnricher(PersonBff target)
    {
        Target = target;
    }

    private PersonBff Target { get; }

    protected override string GetKey()
    {
        return Target.Login;
    }

    protected override void EnrichTarget(CstatiAccountDto value)
    {
        Target.FullName = value.FullName;
    }

    public static PersonBff Add(EnrichersContext enrichers, string login)
    {
        PersonBff result = PersonBffFactory.CreateNotEnriched(login);

        var enricher = new PersonsTargetEnricher(result);

        enrichers.Add(enricher);

        return result;
    }
}
