using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.lib2
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
