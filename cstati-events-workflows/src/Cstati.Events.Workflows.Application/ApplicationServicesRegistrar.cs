using Cstati.Events.Workflows.Application.Services;
using Cstati.Events.Workflows.Application.Services.Processors.ApplicationEvents;
using Cstati.Events.Workflows.Application.Services.Processors.ApplicationEvents.GuestPaymentStatusChanged;

using Microsoft.Extensions.DependencyInjection;

namespace Cstati.Events.Workflows.Application;

public static class ApplicationServicesRegistrar
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSingleton<CstatiEventsWorkflowsFacade>();

        services.AddSingleton<IApplicationEventProcessor, GuestPaymentStatusChangedCstatiEventWorkflowApplicationEventProcessor>();
    }
}
