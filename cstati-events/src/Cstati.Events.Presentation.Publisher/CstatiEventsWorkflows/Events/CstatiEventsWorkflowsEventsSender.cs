using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;
using Cstati.Events.Workflows.Presentation.Abstractions;

using Google.Protobuf;

using JetBrains.Annotations;

using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Cstati.Events.Presentation.Publisher.CstatiEventsWorkflows.Events;

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

    public Task SendStartRequest(string eventId, string eventName, CancellationToken cancellationToken)
    {
        var key = new CstatiEventsWorkflowsEventKey
        {
            Key = eventId
        };

        byte[]? byteKey = key.ToByteArray();

        var value = new CstatiEventsWorkflowsEventValue
        {
            EventId = eventId,

            Start = new StartCstatiEventsWorkflowsEvent
            {
                EventName = eventName
            }
        };

        byte[]? byteValue = value.ToByteArray();

        return TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(SendStartRequest),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }

    public Task SendCompleteRequest(string eventId, CancellationToken cancellationToken)
    {
        var key = new CstatiEventsWorkflowsEventKey
        {
            Key = eventId
        };

        byte[]? byteKey = key.ToByteArray();

        var value = new CstatiEventsWorkflowsEventValue
        {
            EventId = eventId,
            Complete = new CompleteCstatiEventsWorkflowsEvent()
        };

        byte[]? byteValue = value.ToByteArray();

        return TracingFacility.TraceKafkaProducer(
            Logger,
            nameof(SendCompleteRequest),
            key,
            value,
            async () => await Producer.ProduceAsync(byteKey, byteValue));
    }
}
