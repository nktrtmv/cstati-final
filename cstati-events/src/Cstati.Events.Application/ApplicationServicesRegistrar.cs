using Cstati.Events.Application.Services.Processors.ApplicationEvents;
using Cstati.Events.Application.Services.Processors.ApplicationEvents.CompleteWorkflow;
using Cstati.Events.Application.Services.Processors.ApplicationEvents.StartWorkflow;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Application;

public static class ApplicationServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<IApplicationEventProcessor, StartWorkflowApplicationEventProcessor>();
        services.AddSingleton<IApplicationEventProcessor, CompleteWorkflowApplicationEventProcessor>();
    }
}
