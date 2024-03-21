namespace Cstati.Events.Workflows.Presentation.Publisher.Options.Kafka;

public sealed class KafkaOptions
{
    public KafkaOptions(string broker, string cstatiEventsWorkflowsEventsTopic, string publisherName, string consumerGroup)
    {
        Broker = broker;
        CstatiEventsWorkflowsEventsTopic = cstatiEventsWorkflowsEventsTopic;
        PublisherName = publisherName;
        ConsumerGroup = consumerGroup;
    }

    public required string Broker { get; init; }
    public required string CstatiEventsWorkflowsEventsTopic { get; init; }
    public required string PublisherName { get; init; }
    public required string ConsumerGroup { get; init; }
}
