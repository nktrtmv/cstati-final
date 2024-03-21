using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Delete.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Delete;

internal static class DeleteCstatiEventsWorkflowsWavesCommandConverter
{
    internal static DeleteCstatiEventsWorkflowsWavesCommandInternal ToInternal(DeleteCstatiEventsWorkflowsWavesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new DeleteCstatiEventsWorkflowsWavesCommandInternal(command.EventId, command.Ordinal, concurrencyToken);

        return result;
    }
}
