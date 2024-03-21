using Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot.Clients;
using Cstati.Telegram.Bot.Api;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cstati.Events.Workflows.ExternalServices.CstatiTelegramBot;

public static class CstatiTelegramBotRegistrar
{
    public static void Configure(IServiceCollection services, IHostEnvironment environment)
    {
        string serviceUri = environment.IsDevelopment() ? "http://localhost:50051" : "http://telegram_bot:5005";

        services.AddGrpcClient<CstatiTelegramBotService.CstatiTelegramBotServiceClient>(o => o.Address = new Uri(serviceUri));

        services.AddSingleton<ICstatiTelegramBotClient, CstatiTelegramBotClient>();
    }
}
