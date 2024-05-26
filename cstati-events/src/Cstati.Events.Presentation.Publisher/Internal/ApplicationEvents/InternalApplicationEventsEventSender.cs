using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Infrastructure.Abstractions.Publishers.Internal.ApplicationEvents;
using Cstati.Events.Presentation.Abstractions;

using Google.Protobuf;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Cstati.Events.Presentation.Publisher.Internal.ApplicationEvents;

internal sealed class InternalApplicationEventsEventSender : IInternalApplicationEventsEventSender
{
    public InternalApplicationEventsEventSender(IMessageProducer<InternalApplicationEventsEventSender> producer, ILogger<InternalApplicationEventsEventSender> logger)
    {
        Producer = producer;
        Logger = logger;
    }

    private IMessageProducer<InternalApplicationEventsEventSender> Producer { get; }
    private ILogger<InternalApplicationEventsEventSender> Logger { get; }

    public Task SendProcessCommand(string eventId, CancellationToken cancellationToken)
    {
        var key = new InternalApplicationEventsEventKey
        {
            Key = eventId
        };

        byte[]? byteKey = key.ToByteArray();

        var value = new InternalApplicationEventsEventValue
        {
            Process = new ProcessApplicationEventsCommand
            {
                EventId = eventId
            }
        };

        byte[]? byteValue = value.ToByteArray();

        return TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(SendProcessCommand),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }
}
