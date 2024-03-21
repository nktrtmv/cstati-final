namespace Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts.Accesses.Events;

public abstract class CstatiAccountEventAccessDb : CstatiAccountAccessDb
{
    public required string EventId { get; init; }
}
