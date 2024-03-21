using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Delete;

public sealed class DeleteCstatiEventsWorkflowsPaymentsCollectorsService : CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase
{
    public DeleteCstatiEventsWorkflowsPaymentsCollectorsService(
        CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient guests) : base(guests)
    {
    }

    public async Task<DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Delete(
        DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        DeleteCstatiEventsWorkflowsPaymentsCollectorsCommand command = DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter.ToDto(commandBff);

        await PaymentsCollectors.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff.Instance;
    }
}
