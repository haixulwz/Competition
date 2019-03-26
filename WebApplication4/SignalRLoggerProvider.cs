using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class SignalRLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new SignalRLogger();
           // throw new NotImplementedException();
        }

        public void Dispose()
        {
          //  throw new NotImplementedException();
        }
    }
}
