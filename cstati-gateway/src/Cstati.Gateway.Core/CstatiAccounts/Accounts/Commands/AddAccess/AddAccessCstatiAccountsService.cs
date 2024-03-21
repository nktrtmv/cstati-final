using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.AddAccess;

public sealed class AddAccessCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public AddAccessCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<AddAccessCstatiAccountsCommandResponseBff> AddAccess(AddAccessCstatiAccountsCommandBff commandBff, CancellationToken cancellationToken)
    {
        AddAccessCstatiAccountsCommand command = AddAccessCstatiAccountsCommandBffConverter.ToDto(commandBff);

        await Accounts.AddAccessAsync(command, cancellationToken: cancellationToken);

        var result = AddAccessCstatiAccountsCommandResponseBff.Instance;

        return result;
    }
}
