using Cstati.Events.Workflows.Presentation.Abstractions;

namespace Cstati.Gateway.Core.CstatiEventsWorkflows.Tickets;

public abstract class CstatiEventsWorkflowsTicketsServiceClientBase
{
    protected CstatiEventsWorkflowsTicketsServiceClientBase(CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient tickets)
    {
        Tickets = tickets;
    }

    protected CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient Tickets { get; }
}
