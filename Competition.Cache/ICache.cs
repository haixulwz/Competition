using System;
using System.Threading.Tasks;

namespace Competition.Cache
{
    public interface ICache
    {
        string Name { get; }
        TimeSpan DefaultSlidingExpireTime { get; set; }
        TimeSpan? DefaultAbsoluteExpireTime { get; set; }
        object Get(string key, Func<string, object> factory);
        object[] Get(string[] keys, Func<string, object> factory);
        Task<object> GetAsync(string key, Func<string, Task<object>> factory);
    }
}
