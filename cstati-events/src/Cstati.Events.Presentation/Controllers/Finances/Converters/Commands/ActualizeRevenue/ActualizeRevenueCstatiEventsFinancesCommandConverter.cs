using Cstati.Events.Application.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;
using Cstati.Events.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Events.Presentation.Controllers.Finances.Converters.Commands.ActualizeRevenue;

internal static class ActualizeRevenueCstatiEventsFinancesCommandConverter
{
    internal static ActualizeRevenueCstatiEventsFinancesCommandInternal ToInternal(ActualizeRevenueCstatiEventsFinancesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new ActualizeRevenueCstatiEventsFinancesCommandInternal(command.EventId, concurrencyToken);

        return result;
    }
}
