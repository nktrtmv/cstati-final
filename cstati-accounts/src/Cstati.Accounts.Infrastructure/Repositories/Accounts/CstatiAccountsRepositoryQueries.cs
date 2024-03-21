using Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts;

using Dapper;

namespace Cstati.Accounts.Infrastructure.Repositories.Accounts;

internal static class CstatiAccountsRepositoryQueries
{
    internal static CommandDefinition Upsert(CstatiAccountDb account, CancellationToken cancellationToken)
    {
        const string query =
            """
            INSERT INTO accounts
            (
               login,
               password,
               full_name,
               data
            )
            VALUES
            (
               @login,
               @password,
               @full_name,
               @data::jsonb
            )
            ON CONFLICT (login) DO UPDATE
            SET
               password = excluded.password,
               full_name = excluded.full_name,
               data = excluded.data::jsonb,
               concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
            WHERE
               accounts.login = @login AND
               accounts.concurrency_token = @concurrency_token;
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                login = account.Login,
                password = account.Password,
                full_name = account.FullName,
                data = account.Data,
                concurrency_token = DateTime.SpecifyKind(account.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition Delete(string login, DateTime concurrencyToken, CancellationToken cancellationToken)
    {
        const string query =
            """
            UPDATE accounts
            SET
                is_deleted = TRUE
            WHERE
                accounts.login = @login AND
                accounts.concurrency_token = @concurrency_token
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                login,
                concurrency_token = DateTime.SpecifyKind(concurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition Get(string[] logins, CancellationToken cancellationToken)
    {
        const string query =
            """
            SELECT
                a.login,
                a.password,
                a.full_name,
                a.data,
                a.concurrency_token
            FROM accounts a
            WHERE a.login = ANY(@logins)
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                logins
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition GetAll(string? searchQuery, int limit, CancellationToken cancellationToken)
    {
        const string query =
            """
            SELECT
                a.login,
                a.password,
                a.full_name,
                a.data,
                a.concurrency_token
            FROM accounts a
            WHERE
                a.is_deleted = FALSE AND
                (@search_query IS NULL OR a.login ILIKE @search_query OR a.full_name ILIKE @search_query)
            LIMIT @limit
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                search_query = '%' + searchQuery + '%',
                limit
            },
            cancellationToken: cancellationToken);

        return result;
    }
}
