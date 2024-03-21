using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Delete;

public sealed class DeleteCstatiEventsTasksService : CstatiEventsTasksServiceClientBase
{
    public DeleteCstatiEventsTasksService(CstatiEventsTasksService.CstatiEventsTasksServiceClient tasks) : base(tasks)
    {
    }

    public async Task<DeleteCstatiEventsTasksCommandResponseBff> Delete(DeleteCstatiEventsTasksCommandBff commandBff, CancellationToken cancellationToken)
    {
        DeleteCstatiEventsTasksCommand command = DeleteCstatiEventsTasksCommandBffConverter.ToDto(commandBff);

        await Tasks.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsTasksCommandResponseBff.Instance;
    }
}
