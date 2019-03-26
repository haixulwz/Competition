using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class SignalRLogger : ILogger
    {
        HubConnection connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/LogHub").Build();
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
           // throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            connection.StartAsync().Wait();
            var task = connection.SendAsync("writeLog", new {Content=formatter(state,exception) });
            task.Wait();
           // throw new NotImplementedException();
        }
    }
}
