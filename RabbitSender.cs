using System;
using System.Text;
using RabbitMQ.Client;
using System.Text.Json;

namespace rabbitmq_sender
{
  class Sender
  {
    public void Send()
    {
      var factory = new ConnectionFactory() { HostName = "localhost" };
      using (var connection = factory.CreateConnection())
      using (var channel = connection.CreateModel())
      {
        channel.QueueDeclare(queue: "default",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);

        var request = new Request()
        {
          RequestId = new Guid(),
          Header = new Header()
          {
            Accept = "application/json",
            Method = "GET"
          },
          Body = "Messsage body"
        };

        for (int i = 0; i < 100_000; i++)
        {
          string message = "Hello World!" + i;
          var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(request));
          channel.BasicPublish(exchange: "",
                            routingKey: "default",
                            basicProperties: null,
                            body: body);
          Console.WriteLine(" [x] Sent {0}", message);
        }
      }

      Console.WriteLine(" Press [enter] to exit.");
      // Console.ReadLine();
    }
  }
}
