using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Sources.Generics.SingleKey;
using Cstati.Gateway.GenericSubdomain.Services.Enrichers.Targets.Generics;

using Microsoft.Extensions.Logging;

namespace Cstati.Gateway.Core.Common.Persons.Services.Enrichers.Sources;

internal sealed class PersonsSourceEnricher
    : SingleKeySourceEnricherGeneric<CstatiAccountsService.CstatiAccountsServiceClient, TargetEnricherGeneric<string, CstatiAccountDto>, string, CstatiAccountDto>
{
    public PersonsSourceEnricher(CstatiAccountsService.CstatiAccountsServiceClient client, ILogger<PersonsSourceEnricher> logger) : base(client, logger)
    {
    }

    protected override async Task<Dictionary<string, CstatiAccountDto>> GetValues(string[] keys, CancellationToken cancellationToken)
    {
        var query = new GetCstatiAccountsQuery
        {
            Logins = { keys }
        };

        GetCstatiAccountsQueryResponse response = await Client.GetAsync(query, cancellationToken: cancellationToken);

        Dictionary<string, CstatiAccountDto> result = response.Accounts.ToDictionary(c => c.Login);

        return result;
    }
}
