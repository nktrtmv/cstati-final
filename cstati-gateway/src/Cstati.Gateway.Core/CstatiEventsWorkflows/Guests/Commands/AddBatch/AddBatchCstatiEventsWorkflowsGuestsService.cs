using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.AddBatch;

public sealed class AddBatchCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public AddBatchCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<AddBatchCstatiEventsWorkflowsGuestsCommandResponseBff> AddBatch(
        AddBatchCstatiEventsWorkflowsGuestsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        AddCstatiEventsWorkflowsGuestsCommand command = AddBatchCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.AddAsync(command, cancellationToken: cancellationToken);

        return AddBatchCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
