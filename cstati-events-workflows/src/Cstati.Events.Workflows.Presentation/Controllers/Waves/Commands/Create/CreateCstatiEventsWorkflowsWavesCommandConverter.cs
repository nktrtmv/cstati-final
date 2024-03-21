using Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Create.Contracts;
using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Commands.Create;

internal static class CreateCstatiEventsWorkflowsWavesCommandConverter
{
    internal static CreateCstatiEventsWorkflowsWavesCommandInternal ToInternal(CreateCstatiEventsWorkflowsWavesCommand command)
    {
        ConcurrencyToken concurrencyToken = ConcurrencyTokenConverterFrom.FromString(command.ConcurrencyToken);

        var result = new CreateCstatiEventsWorkflowsWavesCommandInternal(command.EventId, concurrencyToken);

        return result;
    }
}
