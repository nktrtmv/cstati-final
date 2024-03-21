using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete;

public sealed class CompleteCstatiEventsWorkflowsWavesService : CstatiEventsWorkflowsWavesServiceClientBase
{
    public CompleteCstatiEventsWorkflowsWavesService(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves) : base(waves)
    {
    }

    public async Task<CompleteCstatiEventsWorkflowsWavesCommandResponseBff> Complete(
        CompleteCstatiEventsWorkflowsWavesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        CompleteCstatiEventsWorkflowsWavesCommand command = CompleteCstatiEventsWorkflowsWavesCommandBffConverter.ToDto(commandBff);

        await Waves.CompleteAsync(command, cancellationToken: cancellationToken);

        return CompleteCstatiEventsWorkflowsWavesCommandResponseBff.Instance;
    }
}
