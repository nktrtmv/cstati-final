using Cstati.Events.Presentation.Publisher.CstatiEventsWorkflows.Events;
using Cstati.Events.Presentation.Publisher.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Presentation.Publisher;

public static class PublisherRegistrar
{
    public static void ConfigureProducers(this IClusterConfigurationBuilder cluster, IServiceCollection services, KafkaOptions options)
    {
        CstatiEventsWorkflowsEventsSenderRegistrar.Configure(services, cluster, options);
    }
}
