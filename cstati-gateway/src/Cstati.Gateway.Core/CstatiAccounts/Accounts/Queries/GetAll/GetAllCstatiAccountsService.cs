using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Queries.GetAll;

public sealed class GetAllCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public GetAllCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<GetAllCstatiAccountsQueryResponseBff> GetAll(GetAllCstatiAccountsQueryBff queryBff, int limit, CancellationToken cancellationToken)
    {
        GetAllCstatiAccountsQuery query = GetAllCstatiAccountsQueryBffConverter.ToDto(queryBff, limit);

        GetAllCstatiAccountsQueryResponse response = await Accounts.GetAllAsync(query, cancellationToken: cancellationToken);

        GetAllCstatiAccountsQueryResponseBff result = GetAllCstatiAccountsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
