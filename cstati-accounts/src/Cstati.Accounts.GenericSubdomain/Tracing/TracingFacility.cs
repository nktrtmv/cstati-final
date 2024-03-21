using Confluent.Kafka;

using Microsoft.Extensions.Logging;

namespace Cstati.Accounts.GenericSubdomain.Tracing;

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

    public static async Task TraceKafkaConsumer<TKey, TValue>(
        ILogger logger,
        string name,
        ConsumeResult<TKey, TValue> message,
        Func<Task> func,
        bool logInProduction = false)
    {
        if (ShallBeSkipped() && logInProduction == false)
        {
            await func();

            return;
        }

        try
        {
            logger.LogInformation("KAFKA CONSUMER START: 🟡 {Name:l}\n{@Value}", name, message.Message.Value);

            await func();

            logger.LogInformation("KAFKA CONSUMER END: {Name:l}\n{@Value}", name, message.Message.Value);
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                "KAFKA CONSUMER EXCEPTION: ❌ {Message:l} in {Name:l}\n{@Value}\n{@Partition}\n{@Offset}",
                e.Message,
                name,
                message.Message.Value,
                message.Partition,
                message.Offset);

            // NOTE: WE ARE NOT RE-THROWING EXCEPTION ON DEV OR STG,TO PREVENT KAFKA MESSAGE ENDLESS STREAMING.

            if (ShallBeSkipped())
            {
                throw;
            }
        }
    }

    public static async Task TraceKafkaProducer<TKey, TValue>(ILogger logger, string name, TKey key, TValue value, Func<Task> func)
    {
        if (ShallBeSkipped())
        {
            await func();

            return;
        }

        try
        {
            logger.LogInformation("KAFKA PRODUCER START: 🟠 {Name:l}\n{@Value}\n{@Key}", name, value, key);

            await func();

            logger.LogInformation("KAFKA PRODUCER END: {Name:l}\n{@Value}\n{@Key}", name, value, key);
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                "KAFKA PRODUCER EXCEPTION: ❌ {Message:l} in {Name:l}\n{@Value}\n{@Key}",
                e.Message,
                name,
                value,
                key);

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
