using Cstati.Accounts.Application.Accounts.Commands.Create.Contracts;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Domain.Entities.Accounts.Factories;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiAccountsCommandInternalHandler : IRequestHandler<CreateCstatiAccountsCommandInternal>
{
    public CreateCstatiAccountsCommandInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task Handle(CreateCstatiAccountsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount account = CstatiAccountFactory.CreateNew(request.Login, request.Password, request.FullName);

        await Accounts.Upsert(account, cancellationToken);
    }
}
