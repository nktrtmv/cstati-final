using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.FinancesDetails;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Statuses;
using Cstati.Events.Domain.Entities.Events.ValueObjects.States.ValueObjects.Tasks;

namespace Cstati.Events.Domain.Entities.Events.ValueObjects.States;

public sealed partial class CstatiEventState
{
    public CstatiEventStatus Status { get; private set; }
    public CstatiEventTask[] Tasks { get; private set; }
    public CstatiEventFinancesDetails FinancesDetails { get; }
}
