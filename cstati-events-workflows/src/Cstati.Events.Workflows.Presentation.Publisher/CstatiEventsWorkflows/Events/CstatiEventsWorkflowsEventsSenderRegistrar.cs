using Cstati.Events.Workflows.Infrastructure.Abstractions.Publishers.CstatiEventWorkflows.Events;
using Cstati.Events.Workflows.Presentation.Publisher.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Workflows.Presentation.Publisher.CstatiEventsWorkflows.Events;

internal static class CstatiEventsWorkflowsEventsSenderRegistrar
{
    internal static void Configure(IServiceCollection services, IClusterConfigurationBuilder cluster, KafkaOptions options)
    {
        services.AddSingleton<ICstatiEventsWorkflowsEventsSender, CstatiEventsWorkflowsEventsSender>();

        cluster.AddProducer<CstatiEventsWorkflowsEventsSender>(
            producer =>
                producer.DefaultTopic(options.CstatiEventsWorkflowsEventsTopic));
    }
}
