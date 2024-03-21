using Cstati.Events.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEvents.Finances;

public abstract class CstatiEventsFinancesServiceClientBase
{
    protected CstatiEventsFinancesServiceClientBase(CstatiEventsFinancesService.CstatiEventsFinancesServiceClient finances)
    {
        Finances = finances;
    }

    protected CstatiEventsFinancesService.CstatiEventsFinancesServiceClient Finances { get; }
}
