using Cstati.Events.Infrastructure.Abstractions.Publishers.Internal.ApplicationEvents;
using Cstati.Events.Presentation.Publisher.Options.Kafka;

using KafkaFlow.Configuration;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Presentation.Publisher.Internal.ApplicationEvents;

internal static class InternalApplicationEventsEventSenderRegistrar
{
    internal static void Configure(IServiceCollection services, IClusterConfigurationBuilder cluster, KafkaOptions options)
    {
        services.AddSingleton<IInternalApplicationEventsEventSender, InternalApplicationEventsEventSender>();

        cluster.AddProducer<InternalApplicationEventsEventSender>(producer => producer.DefaultTopic(options.InternalApplicationEventsTopic));
    }
}
