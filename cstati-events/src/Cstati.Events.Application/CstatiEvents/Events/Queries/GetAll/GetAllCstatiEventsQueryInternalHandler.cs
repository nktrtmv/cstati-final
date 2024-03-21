using Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll.Contracts;
using Cstati.Events.Domain.Entities.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events;
using Cstati.Events.Infrastructure.Abstractions.Repositories.Events.Queries;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Application.CstatiEvents.Events.Queries.GetAll;

[UsedImplicitly]
internal sealed class GetAllCstatiEventsQueryInternalHandler : IRequestHandler<GetAllCstatiEventsQueryInternal, GetAllCstatiEventsQueryResponseInternal>
{
    public GetAllCstatiEventsQueryInternalHandler(ICstatiEventsRepository events)
    {
        Events = events;
    }

    private ICstatiEventsRepository Events { get; }

    public async Task<GetAllCstatiEventsQueryResponseInternal> Handle(GetAllCstatiEventsQueryInternal request, CancellationToken cancellationToken)
    {
        GetAllCstatiEventsQuery query = GetAllCstatiEventsQueryInternalConverter.ToDomain(request);

        CstatiEvent[] response = await Events.GetAll(query, cancellationToken);

        GetAllCstatiEventsQueryResponseInternal result = GetAllCstatiEventsQueryResponseInternalConverter.FromDomain(response);

        return result;
    }
}
