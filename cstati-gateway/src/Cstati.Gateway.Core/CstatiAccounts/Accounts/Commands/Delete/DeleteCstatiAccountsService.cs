using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Delete;

public sealed class DeleteCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public DeleteCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<DeleteCstatiAccountsCommandResponseBff> Delete(DeleteCstatiAccountsCommandBff commandBff, CancellationToken cancellationToken)
    {
        DeleteCstatiAccountsCommand command = DeleteCstatiAccountsCommandBffConverter.ToDto(commandBff);

        await Accounts.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiAccountsCommandResponseBff.Instance;
    }
}
