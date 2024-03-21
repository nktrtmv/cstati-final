using System.Reflection;

using Cstati.Accounts.Application.Accounts.Contracts.Accounts;
using Cstati.Accounts.Infrastructure;
using Cstati.Accounts.Presentation.Controllers.Accounts;

namespace Cstati.Accounts.Presentation;

internal sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        Assembly assembly = typeof(CstatiAccountInternal).Assembly;

        services.AddControllers();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddGrpc(option => { option.EnableDetailedErrors = true; });
        services.AddLogging();

        InfrastructureRegistrar.Configure(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
    {
        app.UseRouting();

        app.UseEndpoints(
            endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<CstatiAccountsController>();
            });
    }
}
