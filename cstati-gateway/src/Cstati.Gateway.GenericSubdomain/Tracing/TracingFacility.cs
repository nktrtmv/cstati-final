using Microsoft.Extensions.Logging;

namespace Cstati.Gateway.GenericSubdomain.Tracing;

public static class TracingFacility
{
    public static async Task<TResponse> TraceGrpc<TResponse, TRequest>(
        ILogger logger,
        string name,
        TRequest request,
        Func<Task<TResponse>> func,
        LogLevel logLevel = LogLevel.Information,
        bool logInProduction = false)
    {
        if (ShallBeSkipped() || logInProduction == false)
        {
            TResponse result = await func();

            return result;
        }

        try
        {
            logger.Log(logLevel, "GRPC START: ⚪️ {Name:l}\n{@Request}", name, request);

            TResponse response = await func();

            logger.Log(logLevel, "GRPC END: {Name:l}\n{@Response}", name, response);

            return response;
        }
        catch (Exception e)
        {
            logger.LogError(e, "GRPC EXCEPTION: ❌ {Message:l} in {Name:l}\n{@Request}", e.Message, name, request);

            throw;
        }
    }

    public static async Task TraceGrpc<TRequest>(ILogger logger, string name, TRequest request, Func<Task> func)
    {
        if (ShallBeSkipped())
        {
            await func();

            return;
        }

        try
        {
            logger.LogInformation("GRPC START: ⚪️ {Name:l}\n{@Request}", name, request);

            await func();

            logger.LogInformation("GRPC END: {Name:l}", name);
        }
        catch (Exception e)
        {
            logger.LogError(e, "GRPC EXCEPTION: ❌ {Message:l} in {Name:l}\n{@Request}", e.Message, name, request);

            throw;
        }
    }

    private static bool ShallBeSkipped()
    {
        string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        bool result = environment is "Production" or "Testing" or null;

        return result;
    }
}
