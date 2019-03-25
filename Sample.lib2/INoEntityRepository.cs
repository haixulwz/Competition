using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.lib2
{
   public interface INoEntityRepository
    {
        T ExecuteReaderReturnT<T>(string sql, object param = null);
        List<T> ExecuteReaderReturnList<T>(string sql, object param = null);
        int ExecuteSqlInt(string sql, object param = null);
        Tuple<int, List<T>> ExecutePageList<T>(string sql, object param = null);
    }
}
