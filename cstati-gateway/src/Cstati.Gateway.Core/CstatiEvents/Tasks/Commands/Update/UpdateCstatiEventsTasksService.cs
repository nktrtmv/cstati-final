using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Tasks.Commands.Update;

public sealed class UpdateCstatiEventsTasksService : CstatiEventsTasksServiceClientBase
{
    public UpdateCstatiEventsTasksService(CstatiEventsTasksService.CstatiEventsTasksServiceClient tasks) : base(tasks)
    {
    }

    public async Task<UpdateCstatiEventsTasksCommandResponseBff> Update(UpdateCstatiEventsTasksCommandBff commandBff, CancellationToken cancellationToken)
    {
        UpdateCstatiEventsTasksCommand command = UpdateCstatiEventsTasksCommandBffConverter.ToDto(commandBff);

        await Tasks.UpdateAsync(command, cancellationToken: cancellationToken);

        return UpdateCstatiEventsTasksCommandResponseBff.Instance;
    }
}
