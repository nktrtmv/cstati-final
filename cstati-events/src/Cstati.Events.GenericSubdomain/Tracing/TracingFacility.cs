using KafkaFlow;

using Microsoft.Extensions.Logging;

namespace Cstati.Events.GenericSubdomain.Tracing;

public static class TracingFacility
{
    public static async Task<TResponse> TraceGrpc<TResponse, TRequest>(
        ILogger logger,
        string name,
        TRequest request,
        Func<Task<TResponse>> func,
        LogLevel logLevel = LogLevel.Information)
    {
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

    public static async Task TraceKafkaConsumer<TMessage>(
        ILogger logger,
        string name,
        IMessageContext context,
        TMessage message,
        Func<Task> func)
    {
        try
        {
            logger.LogInformation("KAFKA CONSUMER START: 🟡 {Name:l}\n{@Value}", name, message);

            await func();

            logger.LogInformation("KAFKA CONSUMER END: {Name:l}\n{@Value}", name, message);
        }
        catch (Exception e)
        {
            logger.LogError(
                e,
                "KAFKA CONSUMER EXCEPTION: ❌ {Message:l} in {Name:l}\n{@Value}\n{@Partition}\n{@Offset}",
                e.Message,
                name,
                message,
                context.ConsumerContext.Partition,
                context.ConsumerContext.Offset);

            throw;
        }
    }

    public static async Task TraceKafkaProducer<TKey, TValue>(ILogger logger, string name, TKey key, TValue value, Func<Task> func)
    {
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
}
