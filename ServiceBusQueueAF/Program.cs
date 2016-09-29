using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;
using System;

namespace ServiceBusQueueAF
{
    class Program
    {
        // Writer
        static void Main(string[] args)
        {
            var connectionString = "Endpoint=sb://eclevelandservicebusaf.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=dzrOCux78uVqppyQiWoIYVdqZLlcnGTUb2Z1KzlQBq8=";
            var queueName = "sampleQueue1";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            if (!namespaceManager.QueueExists(queueName))
            {
                namespaceManager.CreateQueue(queueName);
            }

            var testMessage = "";

            Console.WriteLine("Type \"exit\" to escape program.");
            do
            {
                Console.Write("Enter a message to send to the queue: ");
                testMessage = Console.ReadLine();
                var message = new BrokeredMessage(testMessage);
                if(!testMessage.Equals("exit"))
                    client.Send(message);
            } while (!testMessage.Equals("exit"));
        }
    }
}
