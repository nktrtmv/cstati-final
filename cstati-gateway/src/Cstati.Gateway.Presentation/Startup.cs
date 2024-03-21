using System.Text.Json.Serialization;

using Cstati.Accounts.Presentation.Abstractions;
using Cstati.Events.Presentation.Abstractions;
using Cstati.Events.Workflows.Presentation.Abstractions;
using Cstati.Gateway.Core;
using Cstati.Gateway.Presentation.Configuration;

using Hellang.Middleware.ProblemDetails;

using Microsoft.Net.Http.Headers;

namespace Cstati.Gateway.Presentation;

public sealed class Startup
{
    public Startup(IHostEnvironment environment)
    {
        Environment = environment;
    }

    private IHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(o => o.CustomSchemaIds(x => x.FullName));

        services.AddGrpc(options => { options.EnableDetailedErrors = true; });

        services.AddProblemDetails(ProblemDetailsConfiguration.Configure);
        services.AddHttpContextAccessor();

        CoreRegistrar.Configure(services);

        string accountsServiceUri = Environment.IsDevelopment() ? "http://localhost:5001" : "http://accounts:5003";
        services.AddGrpcClient<CstatiAccountsService.CstatiAccountsServiceClient>(o => o.Address = new Uri(accountsServiceUri));

        string eventsServiceUri = Environment.IsDevelopment() ? "http://localhost:5002" : "http://events:5001";
        services.AddGrpcClient<CstatiEventsService.CstatiEventsServiceClient>(o => o.Address = new Uri(eventsServiceUri));
        services.AddGrpcClient<CstatiEventsFinancesService.CstatiEventsFinancesServiceClient>(o => o.Address = new Uri(eventsServiceUri));
        services.AddGrpcClient<CstatiEventsTasksService.CstatiEventsTasksServiceClient>(o => o.Address = new Uri(eventsServiceUri));

        string workflowsServiceUri = Environment.IsDevelopment() ? "http://localhost:5003" : "http://events_workflows:5002";
        services.AddGrpcClient<CstatiEventsWorkflowsGuestsService.CstatiEventsWorkflowsGuestsServiceClient>(o => o.Address = new Uri(workflowsServiceUri));
        services.AddGrpcClient<CstatiEventsWorkflowsPaymentsCollectorsService.CstatiEventsWorkflowsPaymentsCollectorsServiceClient>(
            o => o.Address = new Uri(workflowsServiceUri));
        services.AddGrpcClient<CstatiEventsWorkflowsTicketsService.CstatiEventsWorkflowsTicketsServiceClient>(o => o.Address = new Uri(workflowsServiceUri));
        services.AddGrpcClient<CstatiEventsWorkflowsWavesService.CstatiEventsWorkflowsWavesServiceClient>(o => o.Address = new Uri(workflowsServiceUri));

        services.AddCors();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseProblemDetails();

        app.UseEndpoints(endpoints => endpoints.MapControllers());

        app.UseSwagger();
        app.UseSwaggerUI();
    }
}
