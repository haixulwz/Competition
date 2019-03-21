using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace OptionMonitor
{
    class Program
    {
        private IOptionsMonitor<MyOptions> _options;
        public Program()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("app.json",optional:false, reloadOnChange: true).Build();
            var serviceCollection = new  ServiceCollection();
            //serviceCollection.Configure<MyOptions>(o=>o.Name="Bob1" );
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _options = serviceProvider.GetRequiredService<IOptionsMonitor<MyOptions>>();
        }
        static void Main(string[] args)
        {
            new Program().Execute(args);
            Console.Read();
        }
        public void Execute(string[] args)
        {
            Console.WriteLine(_options.CurrentValue.Name);
            _options.OnChange(_ => Console.WriteLine(_.Name));
            Console.ReadKey();
        }
    }
}
