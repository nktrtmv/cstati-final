namespace Cstati.Events.Infrastructure.Repositories.Events.Contracts.Events;

internal sealed class CstatiEventDb
{
    internal required string Id { get; init; }
    internal required string Name { get; init; }
    internal string? Location { get; init; }
    internal required string Status { get; init; }
    internal required byte[] Data { get; init; }
    internal required DateTime ConcurrencyToken { get; init; }
}
