using Cstati.Events.Workflows.Application.Common.Guests.PaymentStatuses;
using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendTelegramMessages.Contracts;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendTelegramMessages;

[UsedImplicitly]
internal sealed class SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternalHandler
    : IRequestHandler<SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal>
{
    public SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternalHandler(ICstatiEventsWorkflowsRepository workflows, ICstatiTelegramBotClient telegramBot)
    {
        Workflows = workflows;
        TelegramBot = telegramBot;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }
    private ICstatiTelegramBotClient TelegramBot { get; }

    public async Task Handle(SendTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        CstatiEventWorkflowGuestPaymentStatus[] recipientsPaymentStatuses =
            request.RecipientsPaymentStatuses.Select(CstatiEventWorkflowGuestPaymentStatusInternalConverter.ToDomain).ToArray();

        CstatiTelegramBotMessageExternal[] messages = workflow.Waves
            .SelectMany(w => w.Guests)
            .Where(g => recipientsPaymentStatuses.Contains(g.PaymentInfo.Status))
            .Select(g => g.TelegramLogin)
            .Select(login => new CstatiTelegramBotMessageExternal(login, request.Message))
            .ToArray();

        await TelegramBot.SendMessages(messages, cancellationToken);
    }
}
