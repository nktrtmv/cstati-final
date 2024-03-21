using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Waves;

public abstract class CstatiEventsWorkflowsWavesServiceClientBase
{
    protected CstatiEventsWorkflowsWavesServiceClientBase(CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient waves)
    {
        Waves = waves;
    }

    protected CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient Waves { get; }
}
