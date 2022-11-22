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

        public List<News> Recive()
        {
            List<News> news = new List<News>();
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
                Console.WriteLine(stuff.ToString());
                News n = new News();
                n.Title = stuff._title;
                n.Text = stuff._text;
                n.Status = NewsStatus.PENDING;
                news.Add(n);
                Console.WriteLine("title:");
                Console.WriteLine(n.Title);
                Console.WriteLine("text:");
                Console.WriteLine(n.Text);
            };
            channel.BasicConsume("News", true, consumer);

            return news;

        }
    }
}
