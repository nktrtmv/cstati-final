using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows;
using Cstati.Events.Presentation.Consumers.Internal.Converter.Events;

using KafkaFlow;

using MediatR;

namespace Cstati.Events.Presentation.Consumers.Internal;

public class InternalApplicationEventsEventsHandler : IMessageHandler<byte[]>
{
    public InternalApplicationEventsEventsHandler(IMediator mediator, ILogger<InternalApplicationEventsEventsHandler> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<InternalApplicationEventsEventsHandler> Logger { get; }

    public async Task Handle(IMessageContext context, byte[] message)
    {
        InternalApplicationEventsEventValue eventValue = InternalApplicationEventsEventValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            Logger,
            nameof(CstatiEventsWorkflowsEventsHandler),
            context,
            eventValue,
            async () =>
            {
                IRequest? @event = InternalApplicationEventsEventConverter.ToInternal(eventValue);

                if (ShouldBeSkipped(@event))
                {
                    return;
                }

                await Mediator.Send(@event!, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool ShouldBeSkipped(IRequest? @event)
    {
        if (@event is null)
        {
            return true;
        }

        return false;
    }
}
