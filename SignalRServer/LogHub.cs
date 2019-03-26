using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class LogHub:Hub
    {
        [EnableCors("AllowSameDomain")]
        public async Task WriteLog(Log log)
        {
            await Clients.All.SendAsync("showlog",log);
        }
    }
    public class Log
    {
      //  public LogLevel Level { get; set; }

        public string Content { get; set; }
    }
}
