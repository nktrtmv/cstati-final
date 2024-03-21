namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;

public sealed class ActualizeRevenueCstatiEventsFinancesCommandBff
{
    public required string EventId { get; init; }
    public required string ConcurrencyToken { get; init; }
}
