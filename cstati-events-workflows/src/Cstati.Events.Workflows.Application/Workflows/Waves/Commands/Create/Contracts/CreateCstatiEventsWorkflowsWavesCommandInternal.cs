using Cstati.Events.Workflows.GenericSubdomain.Tokens.Concurrency;

namespace Cstati.Events.Workflows.Application.Workflows.Waves.Commands.Create.Contracts;

public sealed class CreateCstatiEventsWorkflowsWavesCommandInternal : CstatiEventsWorkflowsWavesCommandInternal
{
    public CreateCstatiEventsWorkflowsWavesCommandInternal(string eventId, ConcurrencyToken concurrencyToken) : base(eventId, concurrencyToken)
    {
    }
}
