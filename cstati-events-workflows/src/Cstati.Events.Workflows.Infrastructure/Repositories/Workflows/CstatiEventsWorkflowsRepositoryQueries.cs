using Cstati.Events.Workflows.Infrastructure.Repositories.Workflows.Contracts.EventsWorkflows;

using Dapper;

namespace Cstati.Events.Workflows.Infrastructure.Repositories.Workflows;

internal static class CstatiEventsWorkflowsRepositoryQueries
{
    internal static CommandDefinition Upsert(CstatiEventWorkflowDb workflow, CancellationToken cancellationToken)
    {
        const string query =
            """
            INSERT INTO workflows
            (
               event_id,
               data
            )
            VALUES
            (
               @event_id,
               @data::jsonb
            )
            ON CONFLICT (event_id) DO UPDATE
            SET
               data = excluded.data::jsonb,
               concurrency_token = timezone('utc'::text, CURRENT_TIMESTAMP)
            WHERE
               workflows.event_id = @event_id AND
               workflows.concurrency_token = @concurrency_token;
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                event_id = workflow.EventId,
                data = workflow.Data,
                concurrency_token = DateTime.SpecifyKind(workflow.ConcurrencyToken, DateTimeKind.Utc)
            },
            cancellationToken: cancellationToken);

        return result;
    }

    internal static CommandDefinition Get(string eventId, CancellationToken cancellationToken)
    {
        const string query =
            """
            SELECT
                e.event_id,
                e.data,
                e.concurrency_token
            FROM workflows e
            WHERE e.event_id = @event_id
            """;

        var result = new CommandDefinition(
            query,
            new
            {
                event_id = eventId
            },
            cancellationToken: cancellationToken);

        return result;
    }
}
