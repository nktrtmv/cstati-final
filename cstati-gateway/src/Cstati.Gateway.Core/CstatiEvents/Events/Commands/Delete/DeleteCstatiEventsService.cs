using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Delete;

public sealed class DeleteCstatiEventsService : CstatiEventsServiceClientBase
{
    public DeleteCstatiEventsService(CstatiEventsService.CstatiEventsServiceClient events) : base(events)
    {
    }

    public async Task<DeleteCstatiEventsCommandResponseBff> Delete(DeleteCstatiEventsCommandBff commandBff, CancellationToken cancellationToken)
    {
        DeleteCstatiEventsCommand command = DeleteCstatiEventsCommandBffConverter.ToDto(commandBff);

        await Events.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsCommandResponseBff.Instance;
    }
}
