using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.GenericSubdomain.Configuration;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;
using Cstati.Events.Workflows.Infrastructure.Options;
using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows;

using Dapper;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows;

internal sealed class CstatiEventsWorkflowsRepository : ICstatiEventsWorkflowsRepository
{
    public CstatiEventsWorkflowsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<CstatiEventsWorkflowsDbOptions>(configuration);
    }

    private CstatiEventsWorkflowsDbOptions Options { get; }

    async Task ICstatiEventsWorkflowsRepository.Upsert(CstatiEventWorkflow workflow, CancellationToken cancellationToken)
    {
        CstatiEventWorkflowDb workflowDb = CstatiEventWorkflowDbConverter.FromDomain(workflow);

        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiEventsWorkflowsRepositoryQueries.Upsert(workflowDb, cancellationToken);

        await connection.QueryAsync(query);
    }

    async Task<CstatiEventWorkflow> ICstatiEventsWorkflowsRepository.GetRequired(string eventId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiEventsWorkflowsRepositoryQueries.Get(eventId, cancellationToken);

        var eventDb = await connection.QuerySingleAsync<CstatiEventWorkflowDb>(query);

        CstatiEventWorkflow result = CstatiEventWorkflowDbConverter.ToDomain(eventDb);

        return result;
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
