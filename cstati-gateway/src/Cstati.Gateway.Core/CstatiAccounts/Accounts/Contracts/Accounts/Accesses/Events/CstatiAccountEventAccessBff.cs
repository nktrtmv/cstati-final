namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Contracts.Accounts.Accesses.Events;

public abstract class CstatiAccountEventAccessBff : CstatiAccountAccessBff
{
    public required string EventId { get; init; }
}
