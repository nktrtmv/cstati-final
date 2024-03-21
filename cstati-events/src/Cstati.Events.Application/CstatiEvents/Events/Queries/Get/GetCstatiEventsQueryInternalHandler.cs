using Cstati.Events.Application.CstatiEvents.Events.Queries.Get.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.Get;

[UsedImplicitly]
internal sealed class GetCstatiEventsQueryInternalHandler : IRequestHandler<GetCstatiEventsQueryInternal, GetCstatiEventsQueryResponseInternal>
{
    public GetCstatiEventsQueryInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task<GetCstatiEventsQueryResponseInternal> Handle(GetCstatiEventsQueryInternal request, CancellationToken cancellationToken)
    {
        CstatiEvent response = await Events.GetRequired(request.EventId, cancellationToken);

        GetCstatiEventsQueryResponseInternal result = GetCstatiEventsQueryResponseInternalConverter.FromDomain(response);

        return result;
    }
}
