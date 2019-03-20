using Competition.DbHelper;
using Competition.Tools;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Sample.lib2
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var config = ServiceLocator.Instance.GetService(typeof(IConfiguration)) as IConfiguration;
            var connSetting = config["ConnectionStrings:Default"];
            if (connSetting != null)
            {
                DbConnection connection = null;
                var dalType = DalTypeHelper.GetDalType(config["ConnectionStrings:DataType"]);
                switch (dalType)
                {
                    case DalType.MsSql:
                        connection = new SqlConnection(connSetting);
                        break;
                    case DalType.Oracle:
                        break;
                    case DalType.MySql:
                        connection = new MySqlConnection(connSetting);
                        break;
                    case DalType.SQLite:
                        throw new Exception("not support SQLite");
                    default:
                        throw new Exception("not support");
                }

              
                return connection;
            }

            throw new Exception($"{connSetting} not exist");
           
        }
    }
}
