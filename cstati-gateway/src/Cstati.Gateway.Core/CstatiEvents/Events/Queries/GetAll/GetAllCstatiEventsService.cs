using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.GetAll;

public sealed class GetAllCstatiEventsService : CstatiEventsServiceClientBase
{
    public GetAllCstatiEventsService(CstatiEventsService.CstatiEventsServiceClient events) : base(events)
    {
    }

    public async Task<GetAllCstatiEventsQueryResponseBff> GetAll(GetAllCstatiEventsQueryBff queryBff, int limit, CancellationToken cancellationToken)
    {
        GetAllCstatiEventsQuery query = GetAllCstatiEventsQueryBffConverter.ToDto(queryBff, limit);

        GetAllCstatiEventsQueryResponse response = await Events.GetAllAsync(query, cancellationToken: cancellationToken);

        GetAllCstatiEventsQueryResponseBff result = GetAllCstatiEventsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
