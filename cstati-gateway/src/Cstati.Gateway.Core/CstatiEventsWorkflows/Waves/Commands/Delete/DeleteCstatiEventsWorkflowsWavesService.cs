using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete;

public sealed class DeleteCstatiEventsWorkflowsWavesService : CstatiEventsWorkflowsWavesServiceClientBase
{
    public DeleteCstatiEventsWorkflowsWavesService(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves) : base(waves)
    {
    }

    public async Task<DeleteCstatiEventsWorkflowsWavesCommandResponseBff> Delete(
        DeleteCstatiEventsWorkflowsWavesCommandBff commandBff,
        CancellationToken cancellationToken)
    {
        DeleteCstatiEventsWorkflowsWavesCommand command = DeleteCstatiEventsWorkflowsWavesCommandBffConverter.ToDto(commandBff);

        await Waves.DeleteAsync(command, cancellationToken: cancellationToken);

        return DeleteCstatiEventsWorkflowsWavesCommandResponseBff.Instance;
    }
}
