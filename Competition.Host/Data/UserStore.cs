using Competition.DbHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competition.Host.Data
{
    public class UserStore
    {
        private readonly IHostingEnvironment _env;
        private readonly DapperHelper dapperHelper;
        private readonly ILogger<UserStore> _log;
        private static List<User> _users = new List<User>() {
        new User {  Id="1", Name="alice", Password="alice", Email="alice@gmail.com", PhoneNumber="18800000001", Birthday=DateTime.Now },
        new User {  Id="1", Name="bob", Password="bob", Email="bob@gmail.com", PhoneNumber="18800000002", Birthday=DateTime.Now.AddDays(1) }
    };
        public UserStore(IHostingEnvironment env,    ILogger<UserStore>  log )
        {
            _env = env;
            _log = log;
            dapperHelper = new DapperHelper(env );
        }
        public User FindUser(string userName, string password)
        {
            _log.LogError(dapperHelper._connection.ConnectionString+"aa");
            return dapperHelper.ExecuteReaderReturnList<User>($"select * from sc_user where username='{userName}'").FirstOrDefault();
        }
    }
}
