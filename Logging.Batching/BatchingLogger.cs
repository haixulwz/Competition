using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logging.Batching
{
    public class BatchingLogger : ILogger
    {
        private readonly string _category;
        private readonly BatchingLoggerProvider _batchingLoggerProvider;
        public BatchingLogger(string categoryName,BatchingLoggerProvider batchingLoggerProvider)
        {
            _category = categoryName;
            _batchingLoggerProvider = batchingLoggerProvider;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            var builder = new StringBuilder();
            builder.Append(DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss.fff zzz"));
            builder.Append(" [");
            builder.Append(logLevel.ToString());
            builder.Append("] ");
            builder.Append(_category);
            builder.Append(": ");
            builder.AppendLine(formatter(state, exception));

            if (exception != null)
            {
                builder.AppendLine(exception.ToString());
            }

           // _provider.AddMessage(timestamp, builder.ToString());
        }
    }
}
