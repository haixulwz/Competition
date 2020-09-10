using Competition.DbHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competition.Host.Data
{
    public class UserStore
    {
       
        private readonly ILogger<UserStore> _log;
        private static List<User> _users = new List<User>();
    
        public UserStore(   ILogger<UserStore>  log )
        {
           
            _log = log;
          
        }
        public User FindUser(string userName, string password)
        {
         //   var serviceCollection = new ServiceCollection();
            //serviceCollection.Configure<MyOptions>(o=>o.Name="Bob1" );
          ////  var serviceProvider = serviceCollection.BuildServiceProvider();
          //  _log.LogError(serviceProvider.GetService<IConfiguration>()["ConnectionStrings:Default"]);
            return DapperHelper.ExecuteReaderReturnList<User>($"select * from bypal_cust_info where cust_loadname=@username",new { userName=$"{userName}"}).FirstOrDefault();
        }
    }
}
