using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Rabbit.Models;
using Rabbit.Models.Entities;

// See https://aka.ms/new-console-template for more information

var factory = new ConnectionFactory { 
    HostName = "localhost",
    UserName = "admin",
    Password = "123456"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "rabbitMessageQueue",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var json = Encoding.UTF8.GetString(body);
    RabbitMessage message = JsonSerializer.Deserialize<RabbitMessage>(json);

    System.Threading.Thread.Sleep(1000);

    Console.WriteLine($"Name: {message.Name}, Text: {message.Text}, Id: {message.Id}");
};
channel.BasicConsume(queue: "rabbitMessageQueue",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
