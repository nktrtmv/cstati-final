using Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendPaymentTelegramMessages.Contracts;
using Cstati.Events.Workflows.Application.Workflows.PaymentsCollectors.Contracts.Banks;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.PaymentsCollectors;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests;
using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Contracts.Messages;
using Cstati.Events.Workflows.GenericSubdomain.Dates;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Repositories.EventsWorkflows;

using JetBrains.Annotations;

using MediatR;

namespace Cstati.Events.Workflows.Application.Workflows.Guests.Commands.SendPaymentTelegramMessages;

[UsedImplicitly]
internal sealed class SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternalHandler
    : IRequestHandler<SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal>
{
    public SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternalHandler(ICstatiEventsWorkflowsRepository workflows, ICstatiTelegramBotClient telegramBot)
    {
        Workflows = workflows;
        TelegramBot = telegramBot;
    }

    private ICstatiEventsWorkflowsRepository Workflows { get; }
    private ICstatiTelegramBotClient TelegramBot { get; }

    public async Task Handle(SendPaymentTelegramMessagesCstatiEventsWorkflowsGuestsCommandInternal request, CancellationToken cancellationToken)
    {
        CstatiEventWorkflow workflow = await Workflows.GetRequired(request.EventId, cancellationToken);

        workflow.ConcurrencyToken.AssertEqualsTo(request.ConcurrencyToken);

        if (workflow.PaymentCollectors.Length == 0)
        {
            throw new ApplicationException("U should add payment collectors before send payment messages to guests.");
        }

        CstatiEventWorkflowWave activeWave = workflow.Waves.Single(w => w.IsActive);

        var messages = new List<CstatiTelegramBotMessageExternal>();

        var paymentCollectorsIndex = 0;

        var deadline = UtcDateTimeConverterTo.ToString(request.Deadline);

        foreach (CstatiEventWorkflowGuest guest in activeWave.Guests.Where(g => g.PaymentInfo.Status == CstatiEventWorkflowGuestPaymentStatus.Pending))
        {
            double price = activeWave.Tickets.Single(t => t.Type == guest.TicketType).Price;

            CstatiEventWorkflowPaymentCollector paymentCollector = workflow.PaymentCollectors[paymentCollectorsIndex++];

            paymentCollector.GuestsIds.Add(guest.Id);

            if (paymentCollectorsIndex >= workflow.PaymentCollectors.Length)
            {
                paymentCollectorsIndex = 0;
            }

            var bank = CstatiEventWorkflowPaymentsCollectorBankInternalConverter.ToString(paymentCollector.PreferredBank);

            string messageText =
                $"{request.Message}\n" +
                $"\n" +
                $"Стоимость: {price}\n" +
                $"Дедлайн оплаты: {deadline}\n" +
                $"\n" +
                $"Банк: {bank}\n" +
                $"Номер телефона: {paymentCollector.PhoneNumber}\n" +
                $"Номер карты: {paymentCollector.CardNumber}";

            var message = new CstatiTelegramBotMessageExternal(guest.TelegramLogin, messageText);

            messages.Add(message);
        }

        await Workflows.Upsert(workflow, cancellationToken);

        await TelegramBot.SendMessages(messages, cancellationToken);
    }
}
