using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start;

public sealed class StartCstatiEventsWorkflowsWavesService : CstatiEventsWorkflowsWavesServiceClientBase
{
    public StartCstatiEventsWorkflowsWavesService(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves) : base(waves)
    {
    }

    public async Task<StartCstatiEventsWorkflowsWavesCommandResponseBff> Start(
        StartCstatiEventsWorkflowsWavesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        StartCstatiEventsWorkflowsWavesCommand command = StartCstatiEventsWorkflowsWavesCommandBffConverter.ToDto(commandBff);

        await Waves.StartAsync(command, cancellationToken: cancellationToken);

        return StartCstatiEventsWorkflowsWavesCommandResponseBff.Instance;
    }
}
