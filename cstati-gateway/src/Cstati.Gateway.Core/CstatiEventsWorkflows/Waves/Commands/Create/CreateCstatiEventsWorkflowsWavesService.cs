using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create;

public sealed class CreateCstatiEventsWorkflowsWavesService : CstatiEventsWorkflowsWavesServiceClientBase
{
    public CreateCstatiEventsWorkflowsWavesService(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves) : base(waves)
    {
    }

    public async Task<CreateCstatiEventsWorkflowsWavesCommandResponseBff> Create(
        CreateCstatiEventsWorkflowsWavesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        CreateCstatiEventsWorkflowsWavesCommand command = CreateCstatiEventsWorkflowsWavesCommandBffConverter.ToDto(commandBff);

        await Waves.CreateAsync(command, cancellationToken: cancellationToken);

        return CreateCstatiEventsWorkflowsWavesCommandResponseBff.Instance;
    }
}
