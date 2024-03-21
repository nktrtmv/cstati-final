using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Commands.Create.Contracts;

internal static class CreateCstatiEventsWorkflowsWavesCommandBffConverter
{
    internal static CreateCstatiEventsWorkflowsWavesCommand ToDto(CreateCstatiEventsWorkflowsWavesCommandBff command)
    {
        var result = new CreateCstatiEventsWorkflowsWavesCommand
        {
            EventId = command.EventId,
            ConcurrencyToken = command.ConcurrencyToken
        };

        return result;
    }
}
