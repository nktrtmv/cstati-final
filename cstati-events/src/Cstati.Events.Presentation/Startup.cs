using System.Reflection;

using Cstati.Events.Application;
using Cstati.Events.Application.CstatiEvents.Events.Contracts.Events.Statuses;
using Cstati.Events.GenericSubdomain.Configuration;
using Cstati.Events.Infrastructure;
using Cstati.Events.Presentation.Consumers.CstatiEventsWorkflows;
using Cstati.Events.Presentation.Consumers.Internal;
using Cstati.Events.Presentation.Controllers.Events;
using Cstati.Events.Presentation.Controllers.Finances;
using Cstati.Events.Presentation.Controllers.Tasks;
using Cstati.Events.Presentation.Publisher;
using Cstati.Events.Presentation.Publisher.Options.Kafka;

using KafkaFlow;

namespace Cstati.Events.Presentation;

internal sealed class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(CstatiEventStatusInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(option => { option.EnableDetailedErrors = true; });
        services.AddLogging();

        var kafkaOptions = ConfigurationValueFetcher.GetRequired<KafkaOptions>(Configuration);

        services.AddKafka(
            kafka => kafka.AddCluster(
                cluster =>
                    cluster
                        .WithBrokers(new[] { kafkaOptions.Broker })
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.CstatiEventsWorkflowsEventsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<CstatiEventsWorkflowsEventsHandler>())))
                        .AddConsumer(
                            consumer => consumer
                                .Topic(kafkaOptions.InternalApplicationEventsTopic)
                                .WithGroupId(kafkaOptions.ConsumerGroup)
                                .WithBufferSize(10000)
                                .AddMiddlewares(
                                    middlewares => middlewares
                                        .AddTypedHandlers(
                                            handlers =>
                                                handlers
                                                    .WithHandlerLifetime(InstanceLifetime.Singleton)
                                                    .AddHandler<InternalApplicationEventsEventsHandler>())))
                        .ConfigureProducers(services, kafkaOptions)));

        ApplicationServicesRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<CstatiEventsController>();
                endpoints.MapGrpcService<CstatiEventsFinancesDetailsController>();
                endpoints.MapGrpcService<CstatiEventsTasksController>();
            });

        IKafkaBus eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));
    }
}
