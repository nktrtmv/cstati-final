namespace Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses.Events;

public abstract class CstatiAccountEventAccess : CstatiAccountAccess
{
    protected CstatiAccountEventAccess(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
