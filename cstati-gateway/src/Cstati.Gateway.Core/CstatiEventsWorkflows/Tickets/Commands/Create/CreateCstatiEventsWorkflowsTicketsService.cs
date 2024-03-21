using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Commands.Create;

public sealed class CreateCstatiEventsWorkflowsTicketsService : CstatiEventsWorkflowsTicketsServiceClientBase
{
    public CreateCstatiEventsWorkflowsTicketsService(CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient tickets) : base(tickets)
    {
    }

    public async Task<CreateCstatiEventsWorkflowsTicketsCommandResponseBff> Create(
        CreateCstatiEventsWorkflowsTicketsCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        CreateCstatiEventsWorkflowsTicketsCommand command = CreateCstatiEventsWorkflowsTicketsCommandBffConverter.ToDto(commandBff);

        await Tickets.CreateAsync(command, cancellationToken: cancellationToken);

        return CreateCstatiEventsWorkflowsTicketsCommandResponseBff.Instance;
    }
}
