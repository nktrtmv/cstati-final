using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Create.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Tickets.ValueObjects.Types;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Tickets.Commands.Create;

[UsedImplicitly]
internal sealed class CreateCstatiEventsWorkflowsTicketsCommandInternalHandler : IRequestHandler<CreateCstatiEventsWorkflowsTicketsCommandInternal>
{
    public CreateCstatiEventsWorkflowsTicketsCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(CreateCstatiEventsWorkflowsTicketsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowWave wave = workflow.Waves.Single(w => w.Ordinal == request.WaveOrdinal);

        if (wave.StartedAt is not null)
        {
            throw new ApplicationException("Cannot create ticket in started wave");
        }

        CstatiEventWorkflowTicketType ticketType = CstatiEventWorkflowTicketTypeInternalConverter.ToDomain(request.TicketType);

        var ticket = new CstatiEventWorkflowTicket(ticketType, request.Price);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithNewTicket(workflow, request.WaveOrdinal, ticket);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
