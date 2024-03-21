namespace Cstati.Accounts.Infrastructure.Repositories.Accounts.Contracts;

public sealed class CstatiAccountDb
{
    public required string Login { get; init; }
    public required string Password { get; init; }
    public required string FullName { get; init; }
    public required string Data { get; init; }
    public required DateTime ConcurrencyToken { get; init; }
}
