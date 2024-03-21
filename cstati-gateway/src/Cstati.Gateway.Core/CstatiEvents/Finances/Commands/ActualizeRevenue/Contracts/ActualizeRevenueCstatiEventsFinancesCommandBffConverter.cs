using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;

internal static class ActualizeRevenueCstatiEventsFinancesCommandBffConverter
{
    internal static ActualizeRevenueCstatiEventsFinancesCommand ToDto(ActualizeRevenueCstatiEventsFinancesCommandBff command)
    {
        var result = new ActualizeRevenueCstatiEventsFinancesCommand
        {
            EventId = command.EventId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
