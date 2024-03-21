using Cstati.Accounts.Application.Accounts.Commands.DeleteAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Domain.Entities.Accounts.Services.Updaters;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.DeleteAccess;

[UsedImplicitly]
internal sealed class DeleteAccessCstatiAccountsCommandInternalHandler : IRequestHandler<DeleteAccessCstatiAccountsCommandInternal>
{
    public DeleteAccessCstatiAccountsCommandInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task Handle(DeleteAccessCstatiAccountsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount account = await Accounts.GetRequired(request.Login, cancellationToken);

        account.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiAccountAccess access = CstatiAccountAccessInternalConverter.ToDomain(request.Access);

        CstatiAccountUpdater.DeleteAccess(account, access);

        await Accounts.Upsert(account, cancellationToken);
    }
}
