using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.GenericSubdomain.Configuration;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;
using Cstati.Events.Infrastructure.Options;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Queries;

using Dapper;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Cstati.Events.Infrastructure.Repositories.Events;

internal sealed class CstatiEventsRepository : ICstatiEventsRepository
{
    public CstatiEventsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<CstatiEventsDbOptions>(configuration);
    }

    private CstatiEventsDbOptions Options { get; }

    async Task ICstatiEventsRepository.Upsert(CstatiEvent @event, CancellationToken cancellationToken)
    {
        CstatiEventDb eventDb = CstatiEventDbFromDomainConverter.FromDomain(@event);

        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiEventsRepositoryQueries.Upsert(eventDb, cancellationToken);

        await connection.QueryAsync(query);
    }

    async Task ICstatiEventsRepository.Delete(string eventId, ConcurrencyToken concurrencyToken, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var concurrencyTokenDb = ConcurrencyTokenConverterTo.ToDateTime(concurrencyToken);

        CommandDefinition query = CstatiEventsRepositoryQueries.Delete(eventId, concurrencyTokenDb, cancellationToken);

        await connection.QueryAsync(query);
    }

    async Task<CstatiEvent> ICstatiEventsRepository.GetRequired(string eventId, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiEventsRepositoryQueries.Get(eventId, cancellationToken);

        var eventDb = await connection.QuerySingleAsync<CstatiEventDb>(query);

        CstatiEvent result = CstatiEventDbToDomainConverter.ToDomain(eventDb);

        return result;
    }

    async Task<CstatiEvent[]> ICstatiEventsRepository.GetAll(GetAllCstatiEventsQuery searchQuery, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        GetAllCstatiEventsQueryDb searchQueryDb = GetAllCstatiEventsQueryDbConverter.FromDomain(searchQuery);

        CommandDefinition query = CstatiEventsRepositoryQueries.GetAll(searchQueryDb, cancellationToken);

        IEnumerable<CstatiEventDb> events = await connection.QueryAsync<CstatiEventDb>(query);

        CstatiEvent[] result = events.Select(CstatiEventDbToDomainConverter.ToDomain).ToArray();

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
