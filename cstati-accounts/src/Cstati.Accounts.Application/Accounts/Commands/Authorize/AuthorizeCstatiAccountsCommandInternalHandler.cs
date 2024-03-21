using Cstati.Accounts.Application.Accounts.Commands.Authorize.Contracts;
using Cstati.Accounts.Domain.Entities.Accounts;
using Cstati.Accounts.Infrastructure.Abstractions.Repositories.Accounts;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Accounts.Application.Accounts.Commands.Authorize;

[UsedImplicitly]
internal sealed class AuthorizeCstatiAccountsCommandInternalHandler
    : IRequestHandler<AuthorizeCstatiAccountsCommandInternal, AuthorizeCstatiAccountsCommandResponseInternal>
{
    public AuthorizeCstatiAccountsCommandInternalHandler(ICstatiAccountsRepository accounts)
    {
        Accounts = accounts;
    }

    private ICstatiAccountsRepository Accounts { get; }

    public async Task<AuthorizeCstatiAccountsCommandResponseInternal> Handle(AuthorizeCstatiAccountsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiAccount[] accounts = await Accounts.Get(new[] { request.Login }, cancellationToken);

        bool succeed = accounts.Any() && request.Password == accounts.Single().Password;

        var result = new AuthorizeCstatiAccountsCommandResponseInternal(succeed);

        return result;
    }
}
