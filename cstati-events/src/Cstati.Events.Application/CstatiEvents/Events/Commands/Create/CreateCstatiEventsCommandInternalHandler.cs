using Cstati.Events.Application.CstatiEvents.Events.Commands.Create.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Domain.Entities.Events.Factories;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiEventsCommandInternalHandler : IRequestHandler<CreateCstatiEventsCommandInternal, CreateCstatiEventsCommandResponseInternal>
{
    public CreateCstatiEventsCommandInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task<CreateCstatiEventsCommandResponseInternal> Handle(CreateCstatiEventsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent @event = CstatiEventFactory.CreateNew(request.Name);

        await Events.Upsert(@event, cancellationToken);

        var result = new CreateCstatiEventsCommandResponseInternal(@event.Id);

        return result;
    }
}
