using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Delete;

public sealed class DeleteCstatiEventsWorkflowsTicketsService : CstatiEventsWorkflowsTicketsServiceClientBase
{
    public DeleteCstatiEventsWorkflowsTicketsService(CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient tickets) : base(tickets)
    {
    }

    public async Task<DeleteCstatiEventsWorkflowsTicketsCommandResponseBff> Delete(
        DeleteCstatiEventsWorkflowsTicketsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        DeleteCstatiEventsWorkflowsTicketsCommand command = DeleteCstatiEventsWorkflowsTicketsCommandBffConverter.ToDto(commandBff);

        await Tickets.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsWorkflowsTicketsCommandResponseBff.Instance;
    }
}
