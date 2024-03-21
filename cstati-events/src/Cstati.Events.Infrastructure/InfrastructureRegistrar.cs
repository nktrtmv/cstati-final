using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;
using Cstati.Events.Infrastructure.Repositories.Events;

using Dapper;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ICstatiEventsRepository, CstatiEventsRepository>();

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
}
