using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.PaymentsCollectors.Commands.Create;

public sealed class CreateCstatiEventsWorkflowsPaymentsCollectorsService : CstatiEventsWorkflowsPaymentsCollectorsServiceClientBase
{
    public CreateCstatiEventsWorkflowsPaymentsCollectorsService(
        CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient guests) : base(guests)
    {
    }

    public async Task<CreateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff> Create(
        CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        CreateCstatiEventsWorkflowsPaymentsCollectorsCommand command = CreateCstatiEventsWorkflowsPaymentsCollectorsCommandBffConverter.ToDto(commandBff);

        await PaymentsCollectors.CreateAsync(command, cancellationToken: cancellationToken);

        return CreateCstatiEventsWorkflowsPaymentsCollectorsCommandResponseBff.Instance;
    }
}
