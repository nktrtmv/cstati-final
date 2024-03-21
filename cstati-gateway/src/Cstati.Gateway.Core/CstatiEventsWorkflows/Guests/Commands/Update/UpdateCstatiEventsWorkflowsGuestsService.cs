using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Update;

public sealed class UpdateCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public UpdateCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<UpdateCstatiEventsWorkflowsGuestsCommandResponseBff> Update(
        UpdateCstatiEventsWorkflowsGuestsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        UpdateCstatiEventsWorkflowsGuestsCommand command = UpdateCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.UpdateAsync(command, cancellationToken: cancellationToken);

        return UpdateCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
