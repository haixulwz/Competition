using Logging.Batching;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.File
{
    public class FileLoggerProvider : BatchingLoggerProvider
    {
        private readonly RollingIntervalEnum _rollingInterval;
        private readonly string _path;
        private readonly string _fileName;
        private readonly long? _maxFileSize;
        public FileLoggerProvider(IOptionsMonitor<FileLoggerOptions> options):base(options)
        {

        }
        protected override async Task WriteMessagesAsync(IEnumerable<LogMessage> messages, CancellationToken token)
        {
            Directory.CreateDirectory(_path);
            foreach (var group in messages.GroupBy(GetGrouping))
            {
                var fullName = Path.Combine(_path, _fileName + "-" + group.Key + ".txt");
                var fileInfo = new FileInfo(fullName);
                if (_maxFileSize > 0 && fileInfo.Exists && fileInfo.Length > _maxFileSize)
                {
                    return;
                }
                using (StreamWriter write= System.IO.File.AppendText(fullName) )
                {
                    foreach (var item in group)
                    {
                        await write.WriteAsync(item.Message);
                    }
                }
            }
            RollFiles();
        }
        private string GetGrouping(LogMessage message)
        {
            return message.Timestamp.ToString(_rollingInterval.GetFormat());
        }
        protected void RollFiles()
        {
            if (_maxRetainedFiles > 0)
            {
                var files = new DirectoryInfo(_path)
                    .GetFiles(_fileName + "*")
                    .OrderByDescending(f => f.Name)
                    .Skip(_maxRetainedFiles.Value);

                foreach (var item in files)
                {
                    item.Delete();
                }
            }
        }
    }
}
