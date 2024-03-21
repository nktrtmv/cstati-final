using Cstati.Events.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get.Contracts;

namespace Cstati.Gateway.Core.CstatiEvents.Events.Queries.Get;

public sealed class GetCstatiEventsService : CstatiEventsServiceClientBase
{
    public GetCstatiEventsService(CstatiEventsService.CstatiEventsServiceClient events) : base(events)
    {
    }

    public async Task<GetCstatiEventsQueryResponseBff> Get(GetCstatiEventsQueryBff queryBff, CancellationToken cancellationToken)
    {
        GetCstatiEventsQuery query = GetCstatiEventsQueryBffConverter.ToDto(queryBff);

        GetCstatiEventsQueryResponse response = await Events.GetAsync(query, cancellationToken: cancellationToken);

        GetCstatiEventsQueryResponseBff result = GetCstatiEventsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
