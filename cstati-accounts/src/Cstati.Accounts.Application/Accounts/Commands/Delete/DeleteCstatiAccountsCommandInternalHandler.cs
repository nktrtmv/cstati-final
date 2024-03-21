using Cstati.Accounts.Application.Accounts.Commands.Delete.Contracts;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Delete;

[UsedImplicitly]
internal sealed class DeleteCstatiAccountsCommandInternalHandler : IRequestHandler<DeleteCstatiAccountsCommandInternal>
{
    public DeleteCstatiAccountsCommandInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task Handle(DeleteCstatiAccountsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount account = await Accounts.GetRequired(request.Login, cancellationToken);

        account.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        if (account.Password != request.Password)
        {
            throw new ApplicationException("Incorrect password");
        }

        await Accounts.Delete(request.Login, request.ConcurrencyToken, cancellationToken);
    }
}
