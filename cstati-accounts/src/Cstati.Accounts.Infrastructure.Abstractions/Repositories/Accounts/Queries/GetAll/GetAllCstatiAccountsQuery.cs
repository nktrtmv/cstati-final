namespace Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts.Queries.GetAll;

public sealed class GetAllCstatiAccountsQuery
{
    public GetAllCstatiAccountsQuery(string? query, int limit)
    {
        Query = query;
        Limit = limit;
    }

    public string? Query { get; }
    public int Limit { get; }
}
