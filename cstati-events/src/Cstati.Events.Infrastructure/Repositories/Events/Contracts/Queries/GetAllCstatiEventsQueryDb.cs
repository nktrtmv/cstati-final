namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Queries;

internal sealed class GetAllCstatiEventsQueryDb
{
    internal string? Query { get; init; }
    internal required string[] StatusesFilter { get; init; }
    internal int Limit { get; init; }
}
