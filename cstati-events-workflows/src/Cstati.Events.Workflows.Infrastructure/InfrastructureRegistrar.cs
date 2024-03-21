using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows;

using Dapper;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Workflows.Infrastructure;

public static class InfrastructureRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<ICstatiEventsWorkflowsRepository, CstatiEventsWorkflowsRepository>();

        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }
}
