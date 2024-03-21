using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Finances.Commands.ActualizeRevenue;

public sealed class ActualizeRevenueCstatiEventsFinancesService : CstatiEventsFinancesServiceClientBase
{
    public ActualizeRevenueCstatiEventsFinancesService(CstatiEventsFinancesService.CstatiEventsFinancesServiceClient finances) : base(finances)
    {
    }

    public async Task<ActualizeRevenueCstatiEventsFinancesCommandResponseBff> ActualizeRevenue(
        ActualizeRevenueCstatiEventsFinancesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        ActualizeRevenueCstatiEventsFinancesCommand command = ActualizeRevenueCstatiEventsFinancesCommandBffConverter.ToDto(commandBff);

        await Finances.ActualizeRevenueAsync(command, cancellationToken: cancellationToken);

        return ActualizeRevenueCstatiEventsFinancesCommandResponseBff.Instance;
    }
}
