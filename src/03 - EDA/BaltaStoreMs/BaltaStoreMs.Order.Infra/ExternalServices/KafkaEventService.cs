using System;
using System.Collections.Generic;
using System.Text.Json;
using BaltaStoreMs.SharedContext.Events;
using BaltaStoreMs.SharedContext.ExternalServices;
using Confluent.Kafka;

namespace BaltaStoreMs.Order.Infra.ExternalServices
{
    public class KafkaEventService : IEventService
    {
        public void Queue(IDomainEvent evt)
        {
            var config = LoadConfig();
            var value = JsonSerializer.Serialize(evt);
            Produce("payments", evt.Id.ToString(), value, config);
        }

        private static ClientConfig LoadConfig()
        {
            var cloudConfig = new Dictionary<string, string>
            {
                {"bootstrap.servers", "pkc-lzvrd.us-west4.gcp.confluent.cloud:9092"},
                {"security.protocol", "SASL_SSL"},
                {"sasl.mechanisms", "PLAIN"},
                {"sasl.username", "HIDDEN"},
                {"sasl.password", "HIDDEN"}
            };

            var clientConfig = new ClientConfig(cloudConfig);
            return clientConfig;
        }

        private static void Produce(string topic, string key, string value, ClientConfig config)
        {
            using var producer = new ProducerBuilder<string, string>(config).Build();
            producer.Produce(topic, new Message<string, string> {Key = key, Value = value},
                (deliveryReport) =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                        throw new Exception(deliveryReport.Error.Reason);
                });
            producer.Flush(TimeSpan.FromSeconds(10));
        }
    }
}
