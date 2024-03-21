using Cstati.Accounts.Application.Accounts.Contracts.Accounts;
using Cstati.Accounts.Application.Accounts.Queries.GetAll.Contracts;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts.Queries.GetAll;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiAccountsQueryInternalHandler : IRequestHandler<GetAllCstatiAccountsQueryInternal, GetAllCstatiAccountsQueryResponseInternal>
{
    public GetAllCstatiAccountsQueryInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task<GetAllCstatiAccountsQueryResponseInternal> Handle(GetAllCstatiAccountsQueryInternal request, CancellationToken cancellationToken)
    {
        GetAllCstatiAccountsQuery query = GetAllCstatiAccountsQueryInternalConverter.TomDomain(request);

        CstatiAccount[] accounts = await Accounts.GetAll(query, cancellationToken);

        CstatiAccountInternal[] accountsInternal = accounts.Select(CstatiAccountInternalConverter.FromDomain).ToArray();

        var result = new GetAllCstatiAccountsQueryResponseInternal(accountsInternal);

        return result;
    }
}
