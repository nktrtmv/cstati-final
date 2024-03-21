using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Guests;

public abstract class CstatiEventsWorkflowsGuestsServiceClientBase
{
    protected CstatiEventsWorkflowsGuestsServiceClientBase(CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient guests)
    {
        Guests = guests;
    }

    protected CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient Guests { get; }
}
