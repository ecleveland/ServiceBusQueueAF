using Microsoft.ServiceBus.Messaging;
using System;

namespace ServiceBusQueueRAF
{
    class Program
    {
        // Reader
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://eclevelandservicebusaf.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dzrOCux78uVqppyQiWoIYVdqZLlcnGTUb2Z1KzlQBq8=";
            var queueName = "sampleQueue1";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage(message => {
                Console.WriteLine(String.Format("Message Id: {0}", message.MessageId));
                Console.WriteLine(String.Format("Message Body: {0}", message.GetBody<string>()));
                Console.WriteLine(String.Format("Session Id: {0}", message.SessionId));
            });

            Console.ReadLine();
        }
    }
}
