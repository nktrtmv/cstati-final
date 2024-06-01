using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.ProcessApplicationEvents.Contracts;

public sealed class ProcessApplicationEventsCommandInternal : IRequest
{
    public required string EventId { get; init; }
}
