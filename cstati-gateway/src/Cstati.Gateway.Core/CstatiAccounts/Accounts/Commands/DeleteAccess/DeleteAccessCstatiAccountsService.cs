using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.DeleteAccess;

public sealed class DeleteAccessCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public DeleteAccessCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<DeleteAccessCstatiAccountsCommandResponseBff> DeleteAccess(DeleteAccessCstatiAccountsCommandBff commandBff, CancellationToken cancellationToken)
    {
        DeleteAccessCstatiAccountsCommand command = DeleteAccessCstatiAccountsCommandBffConverter.ToDto(commandBff);

        await Accounts.DeleteAccessAsync(command, cancellationToken: cancellationToken);

        return DeleteAccessCstatiAccountsCommandResponseBff.Instance;
    }
}
