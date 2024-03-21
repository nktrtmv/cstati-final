using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Commands.Update;

public sealed class UpdateCstatiEventsService : CstatiEventsServiceClientBase
{
    public UpdateCstatiEventsService(CstatiEventsService.CstatiEventsServiceClient events) : base(events)
    {
    }

    public async Task<UpdateCstatiEventsCommandResponseBff> Update(UpdateCstatiEventsCommandBff commandBff, CancellationToken cancellationToken)
    {
        UpdateCstatiEventsCommand command = UpdateCstatiEventsCommandBffConverter.ToDto(commandBff);

        await Events.UpdateAsync(command, cancellationToken: cancellationToken);

        return UpdateCstatiEventsCommandResponseBff.Instance;
    }
}
