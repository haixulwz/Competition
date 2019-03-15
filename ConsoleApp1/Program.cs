using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
         {
        //    Console.WriteLine("主线程启动");
        //    //Task.Run启动一个线程
        //    //Task启动的是后台线程，要在主线程中等待后台线程执行完毕，可以调用Wait方法
        //    //Task task = Task.Factory.StartNew(() => { Thread.Sleep(1500); Console.WriteLine("task启动"); });
        //    Task task = Task.Run(() => {
        //        Thread.Sleep(1500);
        //        Console.WriteLine("task启动");
        //    });
        //    Thread.Sleep(300);
        //    //task.Wait();
        //    Console.WriteLine("主线程结束");
        //    Console.Read();

         Console.WriteLine("-------主线程启动-------");
         Task<int> task = GetStrLengthAsync();
         Console.WriteLine("主线程继续执行");
          Console.WriteLine("Task返回的值" + task.Result);
         Console.WriteLine("-------主线程结束-------");
         Console.Read();
        }
        static Task<string> GetString()
        {
            Console.WriteLine("GetString方法开始执行");
            return Task<string>.Run(() =>
            {
                Thread.Sleep(2000);
                return "GetString的返回值";
            });
        }

        static async Task<int> GetStrLengthAsync()
        {
            Console.WriteLine("GetStrLengthAsync方法开始执行");
            //此处返回的<string>中的字符串类型，而不是Task<string>
            string str = await GetString();
            Console.WriteLine("GetStrLengthAsync方法执行结束");
            return str.Length;
        }
    }
}
