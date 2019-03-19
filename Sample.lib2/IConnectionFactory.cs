using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sample.lib2
{
   public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
