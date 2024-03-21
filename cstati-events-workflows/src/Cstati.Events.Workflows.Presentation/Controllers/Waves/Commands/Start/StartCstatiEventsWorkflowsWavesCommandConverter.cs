using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Start.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Start;

internal static class StartCstatiEventsWorkflowsWavesCommandConverter
{
    internal static StartCstatiEventsWorkflowsWavesCommandInternal ToInternal(StartCstatiEventsWorkflowsWavesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new StartCstatiEventsWorkflowsWavesCommandInternal(command.EventId, command.Ordinal, concurrencyToken);

        return result;
    }
}
