using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Create;

public sealed class CreateCstatiEventsTasksService : CstatiEventsTasksServiceClientBase
{
    public CreateCstatiEventsTasksService(CstatiEventsTasksService.CstatiEventsTasksServiceClient tasks) : base(tasks)
    {
    }

    public async Task<CreateCstatiEventsTasksCommandResponseBff> Create(CreateCstatiEventsTasksCommandBff commandBff, CancellationToken cancellationToken)
    {
        CreateCstatiEventsTasksCommand command = CreateCstatiEventsTasksCommandBffConverter.ToDto(commandBff);

        await Tasks.CreateAsync(command, cancellationToken: cancellationToken);

        return CreateCstatiEventsTasksCommandResponseBff.Instance;
    }
}
