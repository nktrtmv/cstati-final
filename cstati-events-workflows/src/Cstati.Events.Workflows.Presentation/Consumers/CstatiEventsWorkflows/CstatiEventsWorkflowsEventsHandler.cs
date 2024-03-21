using Cstati.Events.Workflows.GenericSubdomain.Tracing;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows.Converters.Events;

using JetBrains.Annotations;

using KafkaFlow;

using MediatR;

namespace Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows;

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
                IRequest? request = CstatiEventsWorkflowsEventConverter.ToInternal(eventValue);

                if (ShouldBeSkipped(request))
                {
                    return;
                }

                await Mediator.Send(request!, context.ConsumerContext.WorkerStopped);
            });
    }

    private static bool ShouldBeSkipped(IRequest? request)
    {
        if (request is null)
        {
            return true;
        }

        return false;
    }
}
