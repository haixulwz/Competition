using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRLoggerSample
{
    public class SignalRLoggerProvider : ILoggerProvider
    {
        public SignalRLoggerProvider()
        {

        }
        public ILogger CreateLogger(string categoryName)
        {
            //  throw new NotImplementedException();
            return new SignalRLogger();
        }

        public void Dispose()
        {

           // throw new NotImplementedException();
        }
    }
}
