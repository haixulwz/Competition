using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory {
                HostName="localhost",
                Port=5672,
                UserName="liwenzan",
                Password="liwenzan"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (a, e) => {
                var message = Encoding.UTF8.GetString(e.Body);
                Console.WriteLine("收到" + message);
                channel.BasicAck(e.DeliveryTag, false);
            };
            channel.BasicConsume("hello", false, consumer);
            Console.WriteLine("消费者已启动");
            Console.ReadKey();
            channel.Dispose();
            connection.Close();
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
           
            
        }
    }
}
