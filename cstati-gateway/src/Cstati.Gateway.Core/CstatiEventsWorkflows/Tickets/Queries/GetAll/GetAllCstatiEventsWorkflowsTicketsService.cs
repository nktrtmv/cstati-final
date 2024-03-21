using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll.Contracts;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets.Queries.GetAll;

public sealed class GetAllCstatiEventsWorkflowsTicketsService : CstatiEventsWorkflowsTicketsServiceClientBase
{
    public GetAllCstatiEventsWorkflowsTicketsService(CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient tickets) : base(tickets)
    {
    }

    public async Task<GetAllCstatiEventsWorkflowsTicketsQueryResponseBff> GetAll(
        GetAllCstatiEventsWorkflowsTicketsQueryBff queryBff,
        CancellationToken cancellationToken)
    {
        GetAllCstatiEventsWorkflowsTicketsQuery query = GetAllCstatiEventsWorkflowsTicketsQueryBffConverter.ToDto(queryBff);

        GetAllCstatiEventsWorkflowsTicketsQueryResponse? response = await Tickets.GetAllAsync(query, cancellationToken: cancellationToken);

        GetAllCstatiEventsWorkflowsTicketsQueryResponseBff result = GetAllCstatiEventsWorkflowsTicketsQueryResponseBffConverter.FromDto(response);

        return result;
    }
}
