using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests.Queries.GetAll;

public sealed class GetAllCstatiEventsWorkflowsGuestsService : CstatiEventsWorkflowsGuestsServiceClientBase
{
    public GetAllCstatiEventsWorkflowsGuestsService(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests) : base(guests)
    {
    }

    public async Task<GetAllCstatiEventsWorkflowsGuestsQueryResponseBff> GetAll(GetAllCstatiEventsWorkflowsGuestsQueryBff queryBff, CancellationToken cancellationToken)
    {
        GetAllCstatiEventsWorkflowsGuestsQuery query = GetAllCstatiEventsWorkflowsGuestsQueryBffConverter.ToDto(queryBff);

        GetAllCstatiEventsWorkflowsGuestsQueryResponse response = await Guests.GetAllAsync(query, cancellationToken: cancellationToken);

        GetAllCstatiEventsWorkflowsGuestsQueryResponseBff result = GetAllCstatiEventsWorkflowsGuestsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
