using System.Reflection;

using Cstati.Events.Workflows.Application;
using Cstati.Events.Workflows.Application.Common.Tickets.Types;
using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot;
using Cstati.Events.Workflows.GenericSubdomain.Configuration;
using Cstati.Events.Workflows.Infrastructure;
using Cstati.Events.Workflows.Presentation.Consumers.CstatiEventsWorkflows;
using Cstati.Events.Workflows.Presentation.Controllers.Guests;
using Cstati.Events.Workflows.Presentation.Controllers.PaymentsCollectors;
using Cstati.Events.Workflows.Presentation.Controllers.Tickets;
using Cstati.Events.Workflows.Presentation.Controllers.Waves;
using Cstati.Events.Workflows.Presentation.Publisher;
using Cstati.Events.Workflows.Presentation.Publisher.Options.Kafka;

using KafkaFlow;

namespace Cstati.Events.Workflows.Presentation;

internal sealed class Startup
{
    public Startup(IConfiguration configuration, IHostEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    private IConfiguration Configuration { get; }
    private IHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(CstatiEventWorkflowTicketTypeInternal).Assembly;

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
                        .ConfigureProducers(services, kafkaOptions)));

        ApplicationServicesRegistrar.Configure(services);
        InfrastructureRegistrar.Configure(services);
        CstatiTelegramBotRegistrar.Configure(services, Environment);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<CstatiEventsWorkflowsGuestsController>();
                endpoints.MapGrpcService<CstatiEventsWorkflowsPaymentsCollectorsController>();
                endpoints.MapGrpcService<CstatiEventsWorkflowsTicketsController>();
                endpoints.MapGrpcService<CstatiEventsWorkflowsWavesController>();
            });

        IKafkaBus eventBus = app.ApplicationServices.CreateKafkaBus();

        lifetime.ApplicationStarted.Register(() => eventBus.StartAsync(lifetime.ApplicationStopped));
    }
}
