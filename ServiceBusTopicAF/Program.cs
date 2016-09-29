using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusTopicAF
{
    class Program
    {
        static void Main(string[] args)
        {
            string topicName = "orders";
            string subscription1 = "StandardOrder";
            string subscription2 = "PermiumOrder";

            var namespaceManager = NamespaceManager.Create();

            if (!namespaceManager.TopicExists(topicName))
            {
                var topicDescription = namespaceManager.CreateTopic(topicName);
            }

            if(!namespaceManager.SubscriptionExists(topicName, subscription1))
            {
                var filter = new SqlFilter("Total < 1000");
                namespaceManager.CreateSubscription(topicName, subscription1, filter);
            }

            if(!namespaceManager.SubscriptionExists(topicName, subscription2))
            {
                var filter = new SqlFilter("Total >= 1000");
                namespaceManager.CreateSubscription(topicName, subscription2, filter);
            }

            var topicClient = TopicClient.Create(topicName);
            var message = new BrokeredMessage("Some Standard Order");
            message.Properties["Total"] = 100;
            
            var message2 = new BrokeredMessage("Some Priority Order");
            message2.Properties["Total"] = 2000;
            message2.TimeToLive = new TimeSpan(0, 0, 10);

            topicClient.Send(message);
            topicClient.Send(message2);

            topicClient.Close();
        }
    }
}
