using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events;
using Cstati.Events.Infrastructure.Repositories.Events.Contracts.Queries;

using Dapper;

namespace Cstati.Events.Infrastructure.Repositories.Events;

internal static class CstatiEventsRepositoryQueries
{
    internal static CommandDefinition Upsert(CstatiEventDb eventDb, CancellationToken cancellationToken)
    {
        const string query =
            """
            INSERT INTO events
            (
               id,
               name,
               location,
               status,
               data
            )
            VALUES
            (
               @id,
               @name,
               @location,
               @status,
               @data
            )
            ON CONFLICT (id) DO UPDATE
            SET
               name = excluded.name,
               location = excluded.location,
               status = excluded.status,
               data = excluded.data,
               concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
            WHERE
               events.id = @id AND
               events.concurrency_token = @concurrency_token;
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                id = eventDb.Id,
                name = eventDb.Name,
                location = eventDb.Location,
                status = eventDb.Status,
                data = eventDb.Data,
                concurrency_token = DateTime.SpecifyKind(eventDb.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition Delete(string eventId, DateTime concurrencyToken, CancellationToken cancellationToken)
    {
        const string query =
            """
            UPDATE events
            SET
                is_deleted = TRUE
            WHERE
                events.id = @id AND
                events.concurrency_token = @concurrency_token
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                id = eventId,
                concurrency_token = DateTime.SpecifyKind(concurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition Get(string eventId, CancellationToken cancellationToken)
    {
        const string query =
            """
            SELECT
                e.id,
                e.name,
                e.location,
                e.status,
                e.data,
                e.concurrency_token
            FROM events e
            WHERE e.id = @id AND e.is_deleted = FALSE
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                id = eventId
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition GetAll(GetAllCstatiEventsQueryDb searchQuery, CancellationToken cancellationToken)
    {
        const string query =
            """
            SELECT
                e.id,
                e.name,
                e.location,
                e.status,
                e.data,
                e.concurrency_token
            FROM events e
            WHERE
                e.is_deleted = FALSE AND
                (@query IS NULL OR e.name ILIKE @query OR e.location ILIKE @query) AND
                (array_length(@statuses, 1) IS NULL OR e.status = ANY(@statuses))
                LIMIT @limit
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                query = searchQuery.Query,
                statuses = searchQuery.StatusesFilter,
                limit = searchQuery.Limit
            },
            cancellationToken: cancellationToken);

        return result;
    }
}
