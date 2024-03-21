using Cstati.Accounts.Application.Accounts.Commands.AddAccess.Contracts;
using Cstati.Accounts.Application.Accounts.Contracts.Accounts.Accesses;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Domain.Entities.Accounts.Services.Updaters;
using Cstati.Accounts.Domain.Entities.Accounts.ValueObjects.Accesses;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.AddAccess;

[UsedImplicitly]
internal sealed class AddAccessCstatiAccountsCommandInternalHandler : IRequestHandler<AddAccessCstatiAccountsCommandInternal>
{
    public AddAccessCstatiAccountsCommandInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task Handle(AddAccessCstatiAccountsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount account = await Accounts.GetRequired(request.Login, cancellationToken);

        account.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiAccountAccess access = CstatiAccountAccessInternalConverter.ToDomain(request.Access);

        CstatiAccountUpdater.AddAccess(account, access);

        await Accounts.Upsert(account, cancellationToken);
    }
}
