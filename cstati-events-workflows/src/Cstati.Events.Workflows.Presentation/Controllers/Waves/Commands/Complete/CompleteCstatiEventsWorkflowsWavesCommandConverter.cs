using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Complete.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Complete;

internal static class CompleteCstatiEventsWorkflowsWavesCommandConverter
{
    internal static CompleteCstatiEventsWorkflowsWavesCommandInternal ToInternal(CompleteCstatiEventsWorkflowsWavesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new CompleteCstatiEventsWorkflowsWavesCommandInternal(command.EventId, command.Ordinal, concurrencyToken);

        return result;
    }
}
