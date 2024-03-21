using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;
using Cstati.Accounts.Infrastructure.Repositories.Accounts;

using Dapper;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Accounts.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ICstatiAccountsRepository, CstatiAccountsRepository>();

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
}
