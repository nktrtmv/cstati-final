using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Update;

public sealed class UpdateCstatiEventsWorkflowsPaymentsCollectorsService : CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase
{
    public UpdateCstatiEventsWorkflowsPaymentsCollectorsService(
        CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient guests) : base(guests)
    {
    }

    public async Task<UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Update(
        UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        UpdateCstatiEventsWorkflowsPaymentsCollectorsCommand command = UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter.ToDto(commandBff);

        await PaymentsCollectors.UpdateAsync(command, cancellationToken: cancellationToken);

        return UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff.Instance;
    }
}
