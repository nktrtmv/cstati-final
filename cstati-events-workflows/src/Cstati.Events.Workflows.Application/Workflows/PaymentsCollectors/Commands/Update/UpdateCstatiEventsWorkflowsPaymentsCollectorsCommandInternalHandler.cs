using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Update.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.Services.Updaters.ValueObjects.Context.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.Factories;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors.ValueObjects.Banks;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Commands.Update;

[UsedImplicitly]
internal sealed class UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternalHandler : IRequestHandler<UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal>
{
    public UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternalHandler(CstatiEventsWorkflowsFacade workflows)
    {
        Workflows = workflows;
    }

    private CstatiEventsWorkflowsFacade Workflows { get; }

    public async Task Handle(UpdateCstatiEventsWorkflowsPaymentsCollectorsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        CstatiEventWorkflowPaymentCollectorBank preferredBank = CstatiEventWorkflowPaymentsCollectorBankInternalConverter.ToDomain(request.PreferredBank);

        CstatiEventWorkflowPaymentCollector paymentCollector = CstatiEventWorkflowPaymentCollectorFactory.CreateFrom(
            request.PersonLogin,
            preferredBank,
            request.PhoneNumber,
            request.CardNumber);

        CstatiEventWorkflowUpdatingContext context =
            CstatiEventWorkflowUpdatingContextFactory.CreateWithUpdatedPaymentCollector(workflow, paymentCollector);

        await Workflows.Update(workflow, context, cancellationToken);
    }
}
