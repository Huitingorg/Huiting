using Dapper;
using Huiting.DBAccess.Configs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;

namespace Huiting.DBAccess.Helpers
{
    public static class DapperHelper
    {
        /// <summary>
        /// 获取一个打开的链接
        /// </summary>
        /// <param name="open">是否打开</param>
        /// <returns></returns>
        private static SQLiteConnection GetOpenConnection()
        {
            try
            {
                string fullPath = Path.Combine(DbConfig.SAASFolder, "clientdb.dll");
                string connStr = string.Format("Data Source={0};Version=3;", fullPath);
                var connection = new SQLiteConnection(connStr);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// 带事务 复杂sql直接用这个方法,并且有返回值
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="func">带返回值委托</param>
        /// <param name="callIsCommit"></param>
        /// <returns>返回结果</returns>
        public static T SQLLiteSession<T>(Func<SQLiteConnection, SQLiteTransaction, T> func, Predicate<T> callIsCommit = null)
        {
            using (var connection = GetOpenConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    T t;
                    try
                    {
                        t = func.Invoke(connection, trans);
                        if (callIsCommit == null || callIsCommit(t))
                            trans.Commit();
                        return t;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Trace.TraceError("DapperHelper.SQLLiteSession:" + nameof(T) + ex.ToString());
                        return default(T);
                    }
                }
            }
        }

        /// <summary>
        /// (私有方法)执行简单逻辑，不含事务 --封装数据库连接逻辑
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="func">执行的内容</param>
        /// <returns></returns>
        private static T SQLLiteSession<T>(Func<SQLiteConnection, T> func)
        {
            using (var connection = GetOpenConnection())
            {
                T t;
                try
                {
                    t = func.Invoke(connection);
                    return t;
                }
                catch (Exception ex)
                {
                    Trace.TraceError("DapperHelper.SQLLiteSession:" + nameof(T) + ex.ToString());
                    return default(T);
                }
            }
        }

        /// <summary>
        /// 执行逻辑 --带事务 无返回值
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        public static void SQLLiteSession(Action<SQLiteConnection, SQLiteTransaction> action)
        {
            using (var connection = GetOpenConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    try
                    {
                        action.Invoke(connection, trans);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        Trace.TraceError("DapperHelper.SQLLiteSession:" + ex.ToString());
                    }
                }
            }
        }

        #region MyRegion

        public static T ExecuteScalar<T>(SQLiteConnection conn, string sql, object param = null, SQLiteTransaction trans = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return conn.ExecuteScalar<T>(sql, param, trans, commandTimeout, commandType);
        }

        public static int Execute(SQLiteConnection conn, string sql, object param = null, SQLiteTransaction trans = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return conn.Execute(sql, param, trans, commandTimeout, commandType);
        }

        #endregion MyRegion

        #region 查询

        /// <summary>
        /// 执行sql(包括插入、修改、删除)
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int Execute(string sql, object param = null)
        {
            return SQLLiteSession((con, trans) => con.Execute(sql, param, trans));
        }

        /// <summary>
        /// 查询多条数据 --批量查询泛型数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns></returns>
        public static IEnumerable<T> SqlWithParams<T>(string sql, object param = null)
        {
            return SQLLiteSession((con, trans) => con.Query<T>(sql, param, trans));
        }

        /// <summary>
        /// 事务查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static IEnumerable<T> Query<T>(SQLiteConnection conn, string sql, object param = null, SQLiteTransaction trans = null)
        {
            return conn.Query<T>(sql, param, trans);
        }

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns>返回实体</returns>
        public static T SqlWithParamsSingle<T>(string sql, object parms = null)
        {
            return SQLLiteSession((con, trans) => con.QueryFirstOrDefault<T>(sql, parms, trans));
        }

        /// <summary>
        /// 查询函数结果
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns>函数结果</returns>
        public static T SqlScalarWithParams<T>(string sql, object parms = null)
        {
            return SQLLiteSession((con, trans) => con.ExecuteScalar<T>(sql, parms, trans));
        }

        #endregion 查询
    }
}