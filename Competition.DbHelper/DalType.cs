using System;
using System.Collections.Generic;
using System.Text;

namespace Competition.DbHelper
{
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
        SQLite  
    }
    public static class DalTypeHelper
    {
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
 
