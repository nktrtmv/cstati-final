using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiAccounts.Accounts.Commands.Create;

public sealed class CreateCstatiAccountsService : CstatiAccountsServiceClientBase
{
    public CreateCstatiAccountsService(CstatiAccountsService.CstatiAccountsServiceClient accounts) : base(accounts)
    {
    }

    public async Task<CreateCstatiAccountsCommandResponseBff> Create(CreateCstatiAccountsCommandBff commandBff, CancellationToken cancellationToken)
    {
        CreateCstatiAccountsCommand command = CreateCstatiAccountsCommandBffConverter.ToDto(commandBff);

        await Accounts.CreateAsync(command, cancellationToken: cancellationToken);

        return CreateCstatiAccountsCommandResponseBff.Instance;
    }
}
