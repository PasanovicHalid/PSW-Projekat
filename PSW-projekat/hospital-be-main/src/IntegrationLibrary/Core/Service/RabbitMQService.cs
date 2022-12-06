using IntegrationLibrary.Core.Exceptions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Newses;
using IntegrationLibrary.Migrations;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Service
{

    public class RabbitMQService : IRabbitMQService
    {
        public RabbitMQService() {}
        public void Send()
        {
            News n1 = new News("Title 1", "Text1", DateTime.Now, 2);
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("News",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var message = new { Name = "Producer", Message = n1.ToString() };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "News", null, body);
        }
        public void SendScheduledOrder(ScheduledOrder scheduledOrder)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("ScheduledOrders_From_hospital@gmail.com",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var message = new { Name = "Producer", Message = JsonConvert.SerializeObject(scheduledOrder) };
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "ScheduledOrders_From_hospital@gmail.com", null, body);
        }

        public List<News> Recive(List<BloodBank> bloodBanks)
        {
            List<News> newses = new List<News>();
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("News",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(message);
                dynamic stuff = JsonConvert.DeserializeObject(message);
                try
                {
                    News n = new News();
                    n.Title = stuff.title;
                    n.Text = stuff.text;
                    n.Status = NewsStatus.PENDING;
                    if (checkBloodBankExists((string)stuff.bloodBank.email, bloodBanks) &&
                    checkBloodBankApiKey((string)stuff.bloodBank.email, (string)stuff.bloodBank.apikey, bloodBanks))
                    {
                        newses.Add(n);
                    }
                } catch
                {
                    throw;
                }
            };
            channel.BasicConsume("News", true, consumer);

            return newses;

        }

        public List<FilledOrder> ReciveSheduledOrders(List<BloodBank> bloodBanks)
        {
            List<FilledOrder> filledOrders = new List<FilledOrder>();
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("SentOrders_To_hospital@gmail.com",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("message:");
                Console.WriteLine(message);
                dynamic stuff = JsonConvert.DeserializeObject(message);
                try
                {
                    FilledOrder filledOrder = new FilledOrder();
                    filledOrder.APlus = stuff.aPlus;
                    filledOrder.BPlus = stuff.bPlus;
                    filledOrder.BankEmail = stuff.bloodBank.email;
                    filledOrder.IsSent = stuff.isSent;
                    if (checkBloodBankExists((string)stuff.bloodBank.email, bloodBanks) &&
                    checkBloodBankApiKey((string)stuff.bloodBank.email, (string)stuff.bloodBank.apikey, bloodBanks))
                    {
                        filledOrders.Add(filledOrder);
                    }
                }
                catch
                {
                    throw;
                }
            };
            channel.BasicConsume("SentOrders_To_hospital@gmail.com", true, consumer);

            return filledOrders;

        }
        public bool checkBloodBankApiKey(string bankEmail, string bankApiKey, List<BloodBank> bloodBanks)
        {
            foreach (BloodBank entity in bloodBanks)
            {
                if (entity.Email.Equals(bankEmail))
                {
                    if (!entity.ApiKey.Equals(bankApiKey)){
                        return false;
                    }
                }
            }
            return true;
        }
        public bool checkBloodBankExists(string bankEmail, List<BloodBank> bloodBanks)
        {
            foreach (BloodBank entity in bloodBanks)
            {
                if (entity.Email.Equals(bankEmail))
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
