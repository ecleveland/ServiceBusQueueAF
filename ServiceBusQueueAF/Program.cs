﻿using Microsoft.ServiceBus.Messaging;
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

            var testMessage = "";

            do
            {
                testMessage = Console.ReadLine();
                var message = new BrokeredMessage(testMessage);
                client.Send(message);
            } while (testMessage.Equals("exit"));
        }
    }
}
