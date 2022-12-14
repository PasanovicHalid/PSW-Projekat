using IntegrationLibrary.Core.Exceptions;
using IntegrationLibrary.Core.Model;
using IntegrationLibrary.Core.Repository.Newses;
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
                    n.Title = stuff._title;
                    n.Text = stuff._text;
                    n.Status = NewsStatus.PENDING;
                    if (checkBloodBankExists((string)stuff._bloodBankEmail, bloodBanks) &&
                    checkBloodBankApiKey((string)stuff._bloodBankEmail, (string)stuff._apiKey, bloodBanks))
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
        public bool checkBloodBankApiKey(string bankEmail, string bankApiKey, List<BloodBank> bloodBanks)
        {
            foreach (BloodBank entity in bloodBanks)
            {
                if (entity.Email.EmailAddress.Equals(bankEmail))
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
                if (entity.Email.EmailAddress.Equals(bankEmail))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
