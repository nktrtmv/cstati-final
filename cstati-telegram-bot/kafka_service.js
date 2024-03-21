const { KafkaClient, Consumer, Producer } = require('kafka-node');
const { loadSync } = require('protobufjs');
require('dotenv').config()
const EventEmitter = require('events');

const root = loadSync('vendor/cstati-events-workflows/kafka/events/cstati_events_workflows_events.proto');
const CstatiEventsWorkflowsEventValue = root.lookupType('Cstati.Events.Workflows.Presentation.Abstractions.CstatiEventsWorkflowsEventValue');
const CstatiEventsWorkflowsEventKey = root.lookupType('Cstati.Events.Workflows.Presentation.Abstractions.CstatiEventsWorkflowsEventKey');
const GuestPaymentRefundRequestedCstatiEventsWorkflowsEvent = root.lookupType('Cstati.Events.Workflows.Presentation.Abstractions.GuestPaymentRefundRequestedCstatiEventsWorkflowsEvent');

const eventEmitter = new EventEmitter();
const client = new KafkaClient({ kafkaHost: 'kafka:9093' });
const topicName = process.env.TOPIC_NAME;
const producer = new Producer(client, {encoding: 'buffer'});

const waitForTopics = async (topics) => {
    return new Promise((resolve, reject) => {
        console.log('Retrying....')
        client.loadMetadataForTopics(topics, (error, results) => {
            if (error) {
                console.log(error);
                reject(error);
                return;
            }
            
            const topicsMetadata = results[1].metadata;
            const topicsExist = topics.every(topic => topicsMetadata[topic]);
            console.log(topicsMetadata);
            console.log(topicsExist);
            if (topicsExist) {
                resolve();
            } else {
                setTimeout(() => resolve(waitForTopics(topics)), 5000); // Retry after 5 second
            }
        });
    });
};
const initConsumer = async () => {
    console.log('Waiting for topic ' + topicName);
    await waitForTopics([topicName]);
    console.log('Topics created');
    const consumer = new Consumer(client, [{topic: topicName}], {encoding: 'buffer'});
    

    consumer.on('message', async function (message) {
        try {
            const eventKey = CstatiEventsWorkflowsEventKey.decode(message.key);
            console.log(eventKey);
            const eventValue = CstatiEventsWorkflowsEventValue.decode(message.value);
            console.log(eventValue);
            if (eventValue.start) {
                let eventId = eventValue.eventId;
                let eventName = eventValue.start.eventName;
                eventEmitter.emit('start', eventId, eventName);
            } else if (eventValue.guestPaymentStatusChanged) {
                let eventId = eventValue.eventId;
                let statusChanged = eventValue.guestPaymentStatusChanged;
                let login = statusChanged.guestTelegramLogin.substring(1);
                let status = statusChanged.guestPaymentStatus;
                eventEmitter.emit('paymentStatus', status, login, eventId);
            } else if (eventValue.complete) {
                let eventId = eventValue.eventId;
                eventEmitter.emit('complete', eventId);
            }
    
        } catch (error) {
            console.error('Error processing message:', error);
        }
    });
    
    consumer.on('error', function (error) {
        console.error('Kafka consumer error:', error);
    });
}

function sendRefundRequest(eventId, login) {
    const key = CstatiEventsWorkflowsEventKey.encode(CstatiEventsWorkflowsEventKey.create({ key: "pupa" })).finish();
    const message = CstatiEventsWorkflowsEventValue.create({
        eventId: eventId,
        guestPaymentRefundRequested: GuestPaymentRefundRequestedCstatiEventsWorkflowsEvent.create({
            guestTelegramLogin: `@${login}`
        })
    });
    const buffer = CstatiEventsWorkflowsEventValue.encode(message).finish();
    const payload = [{ topic: topicName, messages: [buffer], key: key }];
    producer.send(payload, function (err, data) {
        console.log(data);
    });
}


initConsumer().catch(err => {
    console.error('Failed to init kafka service: ', err);
})


module.exports.sendRefundRequest = sendRefundRequest
module.exports.eventEmitter = eventEmitter