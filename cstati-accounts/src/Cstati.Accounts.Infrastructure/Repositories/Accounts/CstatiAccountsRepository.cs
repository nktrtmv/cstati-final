using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.GenericSubdomain.Configuration;
using Cstati.Accounts.GenericSubdomain.Tokens.Concurrency;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts.Queries.GetAll;
using Cstati.Accounts.Infrastructure.Options;
using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts;

using Dapper;

using Microsoft.Extensions.Configuration;

using Npgsql;

namespace Cstati.Accounts.Infrastructure.Repositories.Accounts;

internal sealed class CstatiAccountsRepository : ICstatiAccountsRepository
{
    public CstatiAccountsRepository(IConfiguration configuration)
    {
        Options = ConfigurationValueFetcher.GetRequired<CstatiAccountsDbOptions>(configuration);
    }

    private CstatiAccountsDbOptions Options { get; }

    async Task ICstatiAccountsRepository.Upsert(CstatiAccount account, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CstatiAccountDb accountDb = CstatiAccountDbConverter.FromDomain(account);

        CommandDefinition query = CstatiAccountsRepositoryQueries.Upsert(accountDb, cancellationToken);

        await connection.ExecuteAsync(query);
    }

    async Task<CstatiAccount> ICstatiAccountsRepository.GetRequired(string login, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiAccountsRepositoryQueries.Get(new[] { login }, cancellationToken);

        var accountDb = await connection.QuerySingleAsync<CstatiAccountDb>(query);

        CstatiAccount result = CstatiAccountDbConverter.ToDomain(accountDb);

        return result;
    }

    async Task<CstatiAccount[]> ICstatiAccountsRepository.Get(string[] logins, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition query = CstatiAccountsRepositoryQueries.Get(logins, cancellationToken);

        IEnumerable<CstatiAccountDb>? accountsDb = await connection.QueryAsync<CstatiAccountDb>(query);

        CstatiAccount[] result = accountsDb.Select(CstatiAccountDbConverter.ToDomain).ToArray();

        return result;
    }

    async Task<CstatiAccount[]> ICstatiAccountsRepository.GetAll(GetAllCstatiAccountsQuery query, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        CommandDefinition queryDb = CstatiAccountsRepositoryQueries.GetAll(query.Query, query.Limit, cancellationToken);

        IEnumerable<CstatiAccountDb> events = await connection.QueryAsync<CstatiAccountDb>(queryDb);

        CstatiAccount[] result = events.Select(CstatiAccountDbConverter.ToDomain).ToArray();

        return result;
    }

    async Task ICstatiAccountsRepository.Delete(string eventId, ConcurrencyToken concurrencyToken, CancellationToken cancellationToken)
    {
        await using NpgsqlConnection connection = await GetAndOpenConnection();

        var concurrencyTokenDb = ConcurrencyTokenConverterTo.ToDateTime(concurrencyToken);

        CommandDefinition query = CstatiAccountsRepositoryQueries.Delete(eventId, concurrencyTokenDb, cancellationToken);

        await connection.QueryAsync(query);
    }

    private async Task<NpgsqlConnection> GetAndOpenConnection()
    {
        var connection = new NpgsqlConnection(Options.ConnectionString);

        await connection.OpenAsync();

        await connection.ReloadTypesAsync();

        return connection;
    }
}
