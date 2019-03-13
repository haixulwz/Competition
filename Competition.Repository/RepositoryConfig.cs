
using System;
using System.Collections.Concurrent;
using System.Data.Common;
using Competition.Tools.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Competition.Repository
{
    public class RepositoryConfig
    {
        /// <summary>
        /// 默认的链接字符串名称
        /// </summary>
        public const string DefaultConnectionString = "Default";
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;
        private static ConcurrentDictionary<string, DbConnection> _dbConnectionCache = new ConcurrentDictionary<string, DbConnection>();
         public  RepositoryConfig(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();

        }
        /// <summary>
        /// 获取数据库连接
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public   DbConnection GetConn(string conn = null)
        {
            if (string.IsNullOrEmpty(conn))
            {
                conn = DefaultConnectionString;
            }

            if (_dbConnectionCache.ContainsKey(conn))
            {
                return _dbConnectionCache[conn];
            }

            var connSetting = _appConfiguration.GetConnectionString(conn)  ;
            if (connSetting != null)
            {
                DbConnection connection = null;
                var dalType = GetDalType(_appConfiguration.GetConnectionString("DataType"));
                switch (dalType)
                {
                    case DalType.MsSql:
                        connection = new   SqlConnection(connSetting);
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


        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
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
                    throw new Exception($"Not Support Now [{providerName}]");
            }
        }
    }

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DalType
    {
        /// <summary>
        /// SQL Server
        /// </summary>
        MsSql,

        /// <summary>
        /// Oracle
        /// </summary>
        Oracle,

        /// <summary>
        /// MySql
        /// </summary>
        MySql,

        /// <summary>
        /// SQLite
        /// </summary>
        SQLite,
    }
}

