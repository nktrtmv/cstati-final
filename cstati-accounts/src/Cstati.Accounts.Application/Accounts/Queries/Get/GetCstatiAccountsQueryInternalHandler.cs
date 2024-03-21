using Cstati.Accounts.Application.Accounts.Contracts.Accounts;
using Cstati.Accounts.Application.Accounts.Queries.Get.Contracts;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Queries.Get;

[UsedImplicitly]
internal sealed class GetCstatiAccountsQueryInternalHandler : IRequestHandler<GetCstatiAccountsQueryInternal, GetCstatiAccountsQueryResponseInternal>
{
    public GetCstatiAccountsQueryInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task<GetCstatiAccountsQueryResponseInternal> Handle(GetCstatiAccountsQueryInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount[] accounts = await Accounts.Get(request.Logins, cancellationToken);

        CstatiAccountInternal[] accountsInternal = accounts.Select(CstatiAccountInternalConverter.FromDomain).ToArray();

        var result = new GetCstatiAccountsQueryResponseInternal(accountsInternal);

        return result;
    }
}
