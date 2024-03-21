using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Delete;

public sealed class DeleteCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public DeleteCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<DeleteCstatiEventsWorkflowsGuestsCommandResponseBff> Delete(
        DeleteCstatiEventsWorkflowsGuestsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        DeleteCstatiEventsWorkflowsGuestsCommand command = DeleteCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
