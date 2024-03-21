using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Start.Contracts;

internal static class StartCstatiEventsWorkflowsWavesCommandBffConverter
{
    internal static StartCstatiEventsWorkflowsWavesCommand ToDto(StartCstatiEventsWorkflowsWavesCommandBff command)
    {
        var result = new StartCstatiEventsWorkflowsWavesCommand
        {
            EventId = command.EventId,
            Ordinal = command.Ordinal,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
