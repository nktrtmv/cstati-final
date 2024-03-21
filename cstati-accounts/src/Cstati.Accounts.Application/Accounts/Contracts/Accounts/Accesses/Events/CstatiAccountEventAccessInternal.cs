namespace Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses.Events;

public abstract class CstatiAccountEventAccessInternal : CstatiAccountAccessInternal
{
    protected CstatiAccountEventAccessInternal(string eventId)
    {
        EventId = eventId;
    }

    public string EventId { get; }
}
