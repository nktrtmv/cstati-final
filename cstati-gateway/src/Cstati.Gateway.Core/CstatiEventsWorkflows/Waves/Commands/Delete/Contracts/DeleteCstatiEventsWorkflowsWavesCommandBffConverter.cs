using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Delete.Contracts;

internal static class DeleteCstatiEventsWorkflowsWavesCommandBffConverter
{
    internal static DeleteCstatiEventsWorkflowsWavesCommand ToDto(DeleteCstatiEventsWorkflowsWavesCommandBff command)
    {
        var result = new DeleteCstatiEventsWorkflowsWavesCommand
        {
            EventId = command.EventId,
            Ordinal = command.Ordinal,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
