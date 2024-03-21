using Cstati.Events.Workflows.Domain.Entities.EventsWorkflows.ValueObjects.Waves.ValueObjects.Guests.ValueObjects.PaymentsInfo.ValueObjects.Statuses;
using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Publisher.CstatiEventsWorkflows.Events.Converters.GuestsPaymentsStatuses;

using Google.Protobuf;

using JetBrains.Annotations;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Cstati.Events.Workflows.Presentation.Publisher.CstatiEventsWorkflows.Events;

[UsedImplicitly]
internal sealed class CstatiEventsWorkflowsEventsSender : ICstatiEventsWorkflowsEventsSender
{
    public CstatiEventsWorkflowsEventsSender(IMessageProducer<CstatiEventsWorkflowsEventsSender> producer, ILogger<CstatiEventsWorkflowsEventsSender> logger)
    {
        Producer = producer;
        Logger = logger;
    }

    private IMessageProducer<CstatiEventsWorkflowsEventsSender> Producer { get; }
    private ILogger<CstatiEventsWorkflowsEventsSender> Logger { get; }

    public Task SendGuestPaymentStatusChangedEvent(
        string eventId,
        string guestTelegramLogin,
        CstatiEventWorkflowGuestPaymentStatus guestPaymentStatus,
        double ticketPrice,
        CancellationToken cancellationToken)
    {
        var key = new CstatiEventsWorkflowsEventKey
        {
            Key = eventId
        };

        byte[]? byteKey = key.ToByteArray();

        CstatiEventWorkflowGuestPaymentStatusDto guestPaymentStatusDto =
            CstatiEventWorkflowGuestPaymentStatusDtoConverter.FromDomain(guestPaymentStatus);

        var value = new CstatiEventsWorkflowsEventValue
        {
            EventId = eventId,
            GuestPaymentStatusChanged = new GuestPaymentStatusChangedCstatiEventsWorkflowsEvent
            {
                GuestTelegramLogin = guestTelegramLogin,
                GuestPaymentStatus = guestPaymentStatusDto,
                TicketPrice = ticketPrice
            }
        };

        byte[]? byteValue = value.ToByteArray();

        return TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(SendGuestPaymentStatusChangedEvent),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }
}
