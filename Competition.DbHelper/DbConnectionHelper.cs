using Competition.Tools.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
 
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Competition.Tools;
using System.Data.Common;

namespace Competition.DbHelper
{
  public  class DbConnectionHelper
    {
        public const string DefaultConnectionString = "Default";
       
        private static ConcurrentDictionary<string,  IDbConnection> _dbConnectionCache = new ConcurrentDictionary<string,  IDbConnection>();
      
        public static  IDbConnection GetConnection(string conn = "")
        {
            
            if (string.IsNullOrEmpty(conn))
            {
                conn = DefaultConnectionString;
            }
            if (_dbConnectionCache.ContainsKey(conn))
            {
                return _dbConnectionCache[conn];
            }
            var config = ServiceLocator.Instance.GetService(typeof(IConfiguration)) as IConfiguration;

            var connSetting = config["ConnectionStrings:Default"];
            if (connSetting != null)
            {
                 DbConnection connection = null;
                var dalType = GetDalType(config["ConnectionStrings:DataType"]);
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

                if (connection != null)
                {
                    _dbConnectionCache.AddOrUpdate(connSetting, connection, (s, d) => connection);
                }
                return connection;
            }

            throw new Exception($"{conn} not exist");
        }
      
        public static DalType GetDalType(string providerName)
        {
            switch (providerName)
            {
                case "System.Data.SqlClient":
                    return DalType.MsSql;
                case "System.Data.OracleClient":
                    return DalType.Oracle;
                case "System.Data.SQLite":
                    return DalType.SQLite;
                case "MySql.Data.MySqlClient":
                    return DalType.MySql;
                default:
                    return DalType.MySql;
            }
        }
    }
}
