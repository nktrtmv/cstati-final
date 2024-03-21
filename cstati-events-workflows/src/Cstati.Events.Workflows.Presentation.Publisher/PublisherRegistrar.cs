using Cstati.Events.Workflows.Presentation.Publisher.CstatiEventsWorkflows.Events;
using Cstati.Events.Workflows.Presentation.Publisher.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Workflows.Presentation.Publisher;

public static class PublisherRegistrar
{
    public static void ConfigureProducers(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        CstatiEventsWorkflowsEventsSenderRegistrar.Configure(services, cluster, options);
    }
}
