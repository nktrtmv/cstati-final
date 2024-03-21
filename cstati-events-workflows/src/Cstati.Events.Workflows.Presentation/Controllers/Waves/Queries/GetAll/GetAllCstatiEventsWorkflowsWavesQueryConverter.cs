using Cstati.Events.Workflows.Application.Workflows.Waves.Queries.GetAll.Contracts;
using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Events.Workflows.Presentation.Controllers.Waves.Queries.GetAll;

internal static class GetAllCstatiEventsWorkflowsWavesQueryConverter
{
    internal static GetAllCstatiEventsWorkflowsWavesQueryInternal ToInternal(GetAllCstatiEventsWorkflowsWavesQuery query)
    {
        var result = new GetAllCstatiEventsWorkflowsWavesQueryInternal(query.EventId);

        return result;
    }
}
