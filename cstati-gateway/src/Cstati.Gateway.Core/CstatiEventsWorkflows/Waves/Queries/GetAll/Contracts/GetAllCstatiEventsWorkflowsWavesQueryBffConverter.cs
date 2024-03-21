using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves.Queries.GetAll.Contracts;

internal static class GetAllCstatiEventsWorkflowsWavesQueryBffConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQuery ToDto(GetAllCstatiEventsWorkflowsWavesQueryBff query)
    {
        var result = new GetAllCstatiEventsWorkflowsWavesQuery
        {
            EventId = query.EventId
        };

        return result;
    }
}
