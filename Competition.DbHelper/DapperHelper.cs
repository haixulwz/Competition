﻿using System;
using System.Data;

namespace Competition.DbHelper
{
    
        //public class DapperHelper
        //{
        //private readonly static string connStr = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        ////private readonly static string connStr = MemoryCacheUtil.GetOrAddCacheItem("dbConnName", () =>
        ////{

        ////    return ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        ////}, HttpContext.Current.Request.PhysicalApplicationPath + "Web.config");

        ////private readonly static int commandTimeout = MemoryCacheUtil.GetOrAddCacheItem("DapperTimeOut", () => { return Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["DapperTimeOut"]); }, HttpContext.Current.Request.PhysicalApplicationPath + "Web.config");
        ///// <summary>
        ///// 获取连接
        ///// </summary>
        ///// <param name="useWriteConn"></param>
        ///// <returns></returns>
        //public static IDbConnection GetConnection(bool useWriteConn = false)
        //    {
        //        return new MySqlConnection(connStr);
        //    }
        //    /// <summary>
        //    /// 打开连接
        //    /// </summary>
        //    /// <returns></returns>
        //    public static MySqlConnection GetOpenConnection()
        //    {
        //        var conn = new SqlConnection(connStr);
        //        conn.Open();
        //        return conn;
        //    }

        //    /// <summary>
        //    ///  执行sql返回一个对象
        //    /// </summary>
        //    /// <typeparam name="T"></typeparam>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <returns></returns>
        //    public static T ExecuteReaderReturnT<T>(string sql, object param = null, bool useWriteConn = false, IDbTransaction transaction = null)
        //    {
        //        if (transaction == null)
        //        {
        //            using (IDbConnection conn = GetConnection(useWriteConn))
        //            {
        //                // conn.Open();
        //                return conn.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout);
        //            }
        //        }
        //        else
        //        {
        //            var conn = transaction.Connection;
        //            return conn.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout, transaction: transaction);
        //        }

        //    }
        //    /// <summary>
        //    /// 执行sql返回多个对象
        //    /// </summary>
        //    /// <typeparam name="T"></typeparam>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <returns></returns>
        //    public static List<T> ExecuteReaderReturnList<T>(string sql, object param = null, bool useWriteConn = false, IDbTransaction transaction = null)
        //    {
        //        using (IDbConnection conn = GetConnection(useWriteConn))
        //        {
        //            // conn.Open();

        //            return conn.Query<T>(sql, param, commandTimeout: commandTimeout, transaction: transaction).ToList();
        //        }
        //    }
        //    /// <summary>
        //    /// 执行sql返回一个对象--异步
        //    /// </summary>
        //    /// <typeparam name="T"></typeparam>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <returns></returns>
        //    public static async Task<T> ExecuteReaderRetTAsync<T>(string sql, object param = null, bool useWriteConn = false)
        //    {
        //        using (IDbConnection conn = GetConnection(useWriteConn))
        //        {
        //            //conn.Open();
        //            return await conn.QueryFirstOrDefaultAsync<T>(sql, param, commandTimeout: commandTimeout).ConfigureAwait(false);
        //        }
        //    }
        //    /// <summary>
        //    /// 执行sql返回多个对象--异步
        //    /// </summary>
        //    /// <typeparam name="T"></typeparam>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <returns></returns>
        //    public static async Task<List<T>> ExecuteReaderRetListAsync<T>(string sql, object param = null, bool useWriteConn = false)
        //    {
        //        using (IDbConnection conn = GetConnection(useWriteConn))
        //        {
        //            //conn.Open();
        //            var list = await conn.QueryAsync<T>(sql, param, commandTimeout: commandTimeout).ConfigureAwait(false);
        //            return list.ToList();
        //        }
        //    }
        //    /// <summary>
        //    /// 执行sql，返回影响行数 
        //    /// </summary>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <param name="transaction"></param>
        //    /// <returns></returns>
        //    public static int ExecuteSqlInt(string sql, object param = null, bool useWriteConn = false, IDbTransaction transaction = null)
        //    {
        //        if (transaction == null)
        //        {
        //            using (IDbConnection conn = GetConnection(useWriteConn))
        //            {
        //                //conn.Open();
        //                return conn.Execute(sql, param, commandTimeout: commandTimeout, commandType: CommandType.Text);
        //            }
        //        }
        //        else
        //        {
        //            var conn = transaction.Connection;
        //            return conn.Execute(sql, param, transaction: transaction, commandTimeout: commandTimeout, commandType: CommandType.Text);
        //        }
        //    }
        //    /// <summary>
        //    /// 执行sql，返回影响行数--异步
        //    /// </summary>
        //    /// <param name="sql"></param>
        //    /// <param name="param"></param>
        //    /// <param name="useWriteConn"></param>
        //    /// <param name="transaction"></param>
        //    /// <returns></returns>
        //    public static async Task<int> ExecuteSqlIntAsync(string sql, object param = null, bool useWriteConn = false, IDbTransaction transaction = null)
        //    {
        //        if (transaction == null)
        //        {
        //            using (IDbConnection conn = GetConnection(useWriteConn))
        //            {
        //                //conn.Open();
        //                return await conn.ExecuteAsync(sql, param, commandTimeout: commandTimeout, commandType: CommandType.Text).ConfigureAwait(false);
        //            }
        //        }
        //        else
        //        {
        //            var conn = transaction.Connection;
        //            return await conn.ExecuteAsync(sql, param, transaction: transaction, commandTimeout: commandTimeout, commandType: CommandType.Text).ConfigureAwait(false);
        //        }
        //    }
        //    /// <summary>
        //    /// 分页查询 
        //    /// </summary>
        //    /// <typeparam name="T"></typeparam>
        //    /// <param name="sql">先total后数据分号分割</param>        
        //    /// <param name="useWriteConn">是否主库</param>
        //    /// <returns></returns>
        //    public static Tuple<int, List<T>> ExecutePageList<T>(string sql, bool useWriteConn = false, object param = null)
        //    {

        //        using (IDbConnection conn = GetConnection(useWriteConn))
        //        {

        //            using (var reader = conn.QueryMultiple(sql))
        //            {
        //                Tuple<int, List<T>> tuple = new Tuple<int, List<T>>(reader.Read<int>().Single(), reader.Read<T>().ToList<T>());
        //                return tuple;
        //            }
        //        }
        //    }
        //    #region  扩展
        //    ///// <summary>
        //    ///// 根据id获取实体
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="id"></param>
        //    ///// <param name="transaction"></param>
        //    ///// <param name="useWriteConn"></param>
        //    ///// <returns></returns>
        //    //public static T GetById<T>(int id, IDbTransaction transaction = null, bool useWriteConn = false) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(useWriteConn))
        //    //        {
        //    //            conn.Open();

        //    //            return conn.Get<T>(id, commandTimeout: commandTimeout);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        return conn.Get<T>(id, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}
        //    ///// <summary>
        //    ///// 根据id获取实体--异步
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="id"></param>
        //    ///// <param name="transaction"></param>
        //    ///// <param name="useWriteConn"></param>
        //    ///// <returns></returns>
        //    //public static async Task<T> GetByIdAsync<T>(int id, IDbTransaction transaction = null, bool useWriteConn = false) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(useWriteConn))
        //    //        {
        //    //            conn.Open();
        //    //            return await conn.GetAsync<T>(id, commandTimeout: commandTimeout);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        return await conn.GetAsync<T>(id, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}

        //    ///// <summary>
        //    ///// 插入实体
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="item"></param>
        //    ///// <param name="transaction"></param>
        //    ///// <returns></returns>
        //    //public static string ExecuteInsert<T>(T item, IDbTransaction transaction = null) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(true))
        //    //        {
        //    //            conn.Open();
        //    //            var res = conn.Insert<T>(item, commandTimeout: commandTimeout);
        //    //            return res;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        return conn.Insert(item, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}

        //    ///// <summary>
        //    ///// 批量插入实体
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="list"></param>
        //    ///// <param name="transaction"></param>
        //    //public static void ExecuteInsertList<T>(IEnumerable<T> list, IDbTransaction transaction = null) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(true))
        //    //        {
        //    //            conn.Open();
        //    //            conn.Insert<T>(list, commandTimeout: commandTimeout);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        conn.Insert(list, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}

        //    ///// <summary>
        //    ///// 更新单个实体
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="item"></param>
        //    ///// <param name="transaction"></param>
        //    ///// <returns></returns>
        //    //public static bool ExecuteUpdate<T>(T item, IDbTransaction transaction = null) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(true))
        //    //        {
        //    //            conn.Open();
        //    //            return conn.Update(item, commandTimeout: commandTimeout);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        return conn.Update(item, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}

        //    ///// <summary>
        //    ///// 批量更新实体
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="item"></param>
        //    ///// <param name="transaction"></param>
        //    ///// <returns></returns>
        //    //public static bool ExecuteUpdateList<T>(List<T> item, IDbTransaction transaction = null) where T : class
        //    //{
        //    //    if (transaction == null)
        //    //    {
        //    //        using (IDbConnection conn = GetConnection(true))
        //    //        {
        //    //            conn.Open();
        //    //            return conn.Update(item, commandTimeout: commandTimeout);
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        var conn = transaction.Connection;
        //    //        return conn.Update(item, transaction: transaction, commandTimeout: commandTimeout);
        //    //    }
        //    //}


        //    ///// <summary>
        //    ///// 分页查询
        //    ///// </summary>
        //    ///// <typeparam name="T"></typeparam>
        //    ///// <param name="sql">主sql 不带 order by</param>
        //    ///// <param name="sort">排序内容 id desc，add_time asc</param>
        //    ///// <param name="pageIndex">第几页</param>
        //    ///// <param name="pageSize">每页多少条</param>
        //    ///// <param name="useWriteConn">是否主库</param>
        //    ///// <returns></returns>
        //    //public static List<T> ExecutePageList<T>(string sql, string sort, int pageIndex, int pageSize, bool useWriteConn = false, object param = null)
        //    //{
        //    //    string pageSql = @"SELECT TOP {0} * FROM (SELECT ROW_NUMBER() OVER (ORDER BY {1}) _row_number_,*  FROM 
        //    //      ({2})temp )temp1 WHERE temp1._row_number_>{3} ORDER BY _row_number_";
        //    //    string execSql = string.Format(pageSql, pageSize, sort, sql, pageSize * (pageIndex - 1));
        //    //    using (IDbConnection conn = GetConnection(useWriteConn))
        //    //    {
        //    //        conn.Open();

        //    //        return conn.Query<T>(execSql, param, commandTimeout: commandTimeout).ToList();
        //    //    }
        //    //}
        //    #endregion
        //}
    }
 