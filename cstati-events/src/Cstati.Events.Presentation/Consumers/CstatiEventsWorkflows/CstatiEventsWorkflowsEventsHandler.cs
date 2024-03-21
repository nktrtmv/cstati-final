using Cstati.Events.Application.CstatiEventsWorkflows.Events.Abstractions;
using Cstati.Events.GenericSubdomain.Tracing;
using Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events;
using Cstati.Events.Workflows.Presentation.Abstractions;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows;

[UsedImplicitly]
internal sealed class CstatiEventsWorkflowsEventsHandler : IMessageHandler<byte[]>
{
    public CstatiEventsWorkflowsEventsHandler(IMediator mediator, ILogger<CstatiEventsWorkflowsEventsHandler> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }

    private IMediator Mediator { get; }
    private ILogger<CstatiEventsWorkflowsEventsHandler> Logger { get; }

    public async Task Handle(IMessageContext context, byte[] message)
    {
        CstatiEventsWorkflowsEventValue eventValue = CstatiEventsWorkflowsEventValue.Parser.ParseFrom(message);

        await TracingFacility.TraceKafkaConsumer(
            Logger,
            nameof(CstatiEventsWorkflowsEventsHandler),
            context,
            eventValue,
            async () =>
            {
                CstatiEventsWorkflowsEventInternal? @event = CstatiEventsWorkflowsEventConverter.ToInternal(eventValue);

                if (ShouldBeSkipped(@event))
                {
                    return;
                }

                await Mediator.Send(@event!, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool ShouldBeSkipped(CstatiEventsWorkflowsEventInternal? @event)
    {
        if (@event is null)
        {
            return true;
        }

        return false;
    }
}
