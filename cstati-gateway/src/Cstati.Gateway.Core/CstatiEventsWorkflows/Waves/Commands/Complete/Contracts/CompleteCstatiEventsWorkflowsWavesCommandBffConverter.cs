using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Complete.Contracts;

internal static class CompleteCstatiEventsWorkflowsWavesCommandBffConverter
{
    internal static CompleteCstatiEventsWorkflowsWavesCommand ToDto(CompleteCstatiEventsWorkflowsWavesCommandBff command)
    {
        var result = new CompleteCstatiEventsWorkflowsWavesCommand
        {
            EventId = command.EventId,
            Ordinal = command.Ordinal,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
