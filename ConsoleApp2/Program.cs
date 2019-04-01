using RabbitMQ.Client;
using System;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName="localhost",
                Port=5672,
                UserName="liwenzan",
                Password="liwenzan"

            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var exchangeName = "exchangeName";
            var queName = "hello";
            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct, false, false, null);
            channel.QueueDeclare(queName, false, false, false, null);
            channel.QueueBind(queName,exchangeName,"routekey",null);
            var input = "";
            do
            {
                input = Console.ReadLine();
                var bytes = Encoding.UTF8.GetBytes(input);
                channel.BasicPublish("", "hello", null, bytes);


            } while (input!="exit");
            Console.Read();
           
        }
    }
}
