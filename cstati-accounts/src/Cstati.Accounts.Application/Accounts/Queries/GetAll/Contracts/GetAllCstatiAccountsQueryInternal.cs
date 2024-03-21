using MediatR;

namespace Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;

public sealed class GetAllCstatiAccountsQueryInternal : IRequest<GetAllCstatiAccountsQueryResponseInternal>
{
    public GetAllCstatiAccountsQueryInternal(string? query, int limit)
    {
        Query = query;
        Limit = limit;
    }

    internal string? Query { get; }
    internal int Limit { get; }
}
