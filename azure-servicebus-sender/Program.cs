using Microsoft.Azure.ServiceBus;
using System;
using System.Text;

namespace azureservicebussender
{
    class Program
    {
        static void Main(string[] args)
        {
            string messageBusConnectionString = Environment.GetEnvironmentVariable("MessageBusConnectionString");
            string messageBusTopic = Environment.GetEnvironmentVariable("MessageBusTopic");
            string messageBody = Environment.GetEnvironmentVariable("MessageBody");
            string messageLabel = Environment.GetEnvironmentVariable("MessageLabel");

            if (!ValidateEnvironmentVariables(messageBusConnectionString, messageBusTopic))
            {
                Environment.Exit(1);
            }


            ServiceBusConnectionStringBuilder serviceBusConnectionStringBuilder = new ServiceBusConnectionStringBuilder(messageBusConnectionString);
            serviceBusConnectionStringBuilder.EntityPath = messageBusTopic;

            TopicClient topicClient = new TopicClient(serviceBusConnectionStringBuilder);
            Message message = new Message(Encoding.ASCII.GetBytes(messageBody));

            if (!string.IsNullOrEmpty(messageLabel))
            {
                message.Label = messageLabel;

            }
            else
            {
                messageLabel = "[No Label Defined]";
            }

            Console.WriteLine("Sending message to Topic: '{0}' with Label '{1}'.", messageBusTopic, messageLabel);
            topicClient.SendAsync(message).GetAwaiter().GetResult();
            Console.WriteLine("Sent message to Topic: '{0}' with Label '{1}'.", messageBusTopic, messageLabel);
        }
        private static bool ValidateEnvironmentVariables(string messageBusConnectionString, string messageBusTopic)
        {
            if (string.IsNullOrEmpty(messageBusConnectionString))
            {
                Console.Error.WriteLine("Error: MessageBusConnectionString not defined");
                return false;
            }

            if (string.IsNullOrEmpty(messageBusTopic))
            {
                Console.Error.WriteLine("Error: MessageBusTopic is not defined");
            }
            return true;
        }
    }
}
