﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.Batching
{
    public abstract class BatchingLoggerProvider : ILoggerProvider
    {
        private readonly List<LogMessage> _currentBatch = new List<LogMessage>();
        private readonly TimeSpan _interval;
        private readonly int? _queueSize;
        private readonly int? _batchSize;
        private readonly IDisposable _optionsChangeToken;
        private CancellationTokenSource _cancellationTokenSource;
        private BlockingCollection<LogMessage> _messageQueue;
        private Task _outputTask;
        public BatchingLoggerProvider(IOptionsMonitor<BatchingLoggerOptions> options)
        {
            var loggerOptions = options.CurrentValue;
            if (loggerOptions.BatchSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(loggerOptions.BatchSize), $"{nameof(loggerOptions.BatchSize)} must be a positive number.");
            }
            if (loggerOptions.FlushPeriod <= TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(loggerOptions.FlushPeriod), $"{nameof(loggerOptions.FlushPeriod)} must be longer than zero.");
            }
            _interval = loggerOptions.FlushPeriod;
            _batchSize = loggerOptions.BatchSize;
            _queueSize = loggerOptions.BackgroundQueueSize;
            _optionsChangeToken = options.OnChange(UpdateOptions);
            UpdateOptions(options.CurrentValue);
        }
        protected abstract Task WriteMessagesAsync(IEnumerable<LogMessage> messages, CancellationToken token);
        private async Task ProcessLogQueue(object state) {
            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var limit = _batchSize ?? int.MaxValue;
                while (limit > 0 && _messageQueue.TryTake(out var message))
                {
                    _currentBatch.Add(message);
                }
                if (_currentBatch.Count > 0)
                {
                    try
                    {
                        await WriteMessagesAsync(_currentBatch, _cancellationTokenSource.Token);
                    }
                    catch (Exception e)
                    {

                        //throw;
                    }
                    _currentBatch.Clear();
                }
                await IntervalAsync(_interval, _cancellationTokenSource.Token);
            }
        }
        protected virtual Task IntervalAsync(TimeSpan interval, CancellationToken cancellationToken)
        {
            return Task.Delay(interval, cancellationToken);
        }
        private void UpdateOptions(BatchingLoggerOptions currentValue)
        {
            var oldIsEnabled = IsEnabled;
            IsEnabled = currentValue.IsEnabled;
            if (oldIsEnabled != IsEnabled)
            {
                if (IsEnabled)
                {
                    Start();
                }
                else
                {
                    Stop();
                }
            }
        }
        public bool IsEnabled { get; private set; }
        public ILogger CreateLogger(string categoryName)
        {
            return new BatchingLogger(categoryName, this);
            // throw new NotImplementedException();
        }
        public void AddMessage(DateTimeOffset timestamp, string message) {

            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(new LogMessage { Message=message, Timestamp=timestamp });
                }
                catch (Exception)
                {

                   // throw;
                }
            }
        }
        public void Dispose()
        {
            _optionsChangeToken?.Dispose();
            if (IsEnabled)
            {
                Stop();
            }
            //throw new NotImplementedException();
        }

        private void Start()
        {
            _messageQueue = _queueSize == null ?
               new BlockingCollection<LogMessage>(new ConcurrentQueue<LogMessage>()) :
               new BlockingCollection<LogMessage>(new ConcurrentQueue<LogMessage>(), _queueSize.Value);
            _cancellationTokenSource = new CancellationTokenSource();
            _outputTask = Task.Factory.StartNew(ProcessLogQueue,null, TaskCreationOptions.LongRunning);
        }

        private void Stop()
        {
            _cancellationTokenSource.Cancel();
            _messageQueue.CompleteAdding();

            try
            {
                _outputTask.Wait(_interval);
            }
            catch (TaskCanceledException)
            {
            }
            catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is TaskCanceledException)
            {
            }
        }
    }
}
