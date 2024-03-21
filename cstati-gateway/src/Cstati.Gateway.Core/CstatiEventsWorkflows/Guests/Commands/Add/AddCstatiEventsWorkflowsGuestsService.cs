using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Commands.Add;

public sealed class AddCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public AddCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<AddCstatiEventsWorkflowsGuestsCommandResponseBff> Add(AddCstatiEventsWorkflowsGuestsCommandBff commandBff, CancellationToken cancellationToken)
    {
        AddCstatiEventsWorkflowsGuestsCommand command = AddCstatiEventsWorkflowsGuestsCommandBffConverter.ToDto(commandBff);

        await Guests.AddAsync(command, cancellationToken: cancellationToken);

        return AddCstatiEventsWorkflowsGuestsCommandResponseBff.Instance;
    }
}
