using Dapper;
using Huiting.Common;
using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.DBAccess.Generator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Text;
using Huiting.DBAccess.Entity.Dict;
using Huiting.DBAccess.Service;

namespace Huiting.DBAccess.Helpers
{
    public static class DapperHelper
    {
        /// <summary>
        /// 表名字典
        /// </summary>
        internal static readonly Dictionary<Type, string> TableNames = new Dictionary<Type, string>();

        public static void AddTableNames(Type type)
        {
            string tableName = ((DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false))[0].TableName;
            if (!TableNames.ContainsKey(type))
                TableNames.Add(type, tableName);
        }

        public static string InitDB()
        {
            try
            {
                if (!Directory.Exists(DbConfig.DBPath))
                    Directory.CreateDirectory(DbConfig.DBPath);

                if (!File.Exists(DbConfig.DBFileFullName))
                    File.Create(DbConfig.DBFileFullName).Close();

                DBTableCorrector.CorrectDBTableByDtos();

                InitTableFieldInfoDto();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString(), MethodBase.GetCurrentMethod());
                return e.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// 初始化表TableFieldInfo的内容
        /// </summary>
        private static void InitTableFieldInfoDto()
        {
            //若已经存在记录，则不用检查
            var tableFieldInfoDto = new TableFieldInfoService().GetTableFieldInfoDtos();
            if (tableFieldInfoDto.Count() > 0)
                return;

            List<TableFieldInfoDto> lstDto = GetTableFieldInfos();

            DapperHelper.SQLLiteSession<bool>((conn, trans) =>
            {
                string sql = $"delete from {TableNames[typeof(TableFieldInfoDto)]}";
                DapperHelper.Execute(conn, sql, null, trans);
                sql = SqlGenerator.GetInsertSqlByModel(typeof(TableFieldInfoDto));
                long lastID;
                for (int i = 0; i < lstDto.Count; i++)
                    lastID = DapperHelper.ExecuteScalar<long>(conn, sql, lstDto[i], trans);

                return true;
            });
        }

        /// <summary>
        /// 获取业务表字段信息列表
        /// </summary>
        /// <returns></returns>
        private static List<TableFieldInfoDto> GetTableFieldInfos()
        {
            List<TableFieldInfoDto> lstDto = new List<TableFieldInfoDto>();
            //包含所有数据库表的type数组
            List<Type> tableList = new List<Type> {
                  typeof(UnitBasicDataDto),
                  typeof(UnitDevelopDataDto),
                  typeof(WellDevelopDataDto),
                };


            foreach (var tableType in tableList)
            {
                var piAry = tableType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var pi in piAry)
                {
                    var attrAry = pi.GetCustomAttributes(typeof(DisplayFieldAttribute), true);
                    if (attrAry.Length <= 0)
                        continue;

                    var displayFieldAttri = attrAry[0] as DisplayFieldAttribute;
                    //显示值
                    string fieldDisplayText = displayFieldAttri.DisplayText;

                    //json名称
                    string fieldJsonName = string.Empty;
                    var jsonPropertyAttrAry = pi.GetCustomAttributes(typeof(JsonPropertyAttribute), true);
                    if (jsonPropertyAttrAry != null && jsonPropertyAttrAry.Count() > 0)
                        fieldJsonName = ((JsonPropertyAttribute)jsonPropertyAttrAry[0]).PropertyName;

                    //别名列表
                    string[] fieldAliasAry = displayFieldAttri.DisplayAlias?.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    List<string> lstAlasAry = new List<string>();
                    lstAlasAry.Add(fieldDisplayText);
                    if (string.IsNullOrWhiteSpace(fieldJsonName) == false)
                        lstAlasAry.Add(fieldJsonName);

                    if (fieldAliasAry != null)
                    {
                        foreach (var item in fieldAliasAry)
                        {
                            lstAlasAry.Add(item);
                            //不超过一个字符的不用考虑拼音首字符
                            if (item.Length <= 1)
                                continue;
                            //别名查重，添加中文首字母集合
                            var firstLetter = ChineseToPinYin.GetPYFirstWord(item);
                            var isContain = lstAlasAry.Exists(x => x.ToString().Trim().ToLower() == firstLetter.Trim().ToLower());
                            if (isContain)
                                continue;

                            lstAlasAry.Add(firstLetter);
                        }
                    }

                    var dataFieldAttrAry = pi.GetCustomAttributes(typeof(DataFieldAttribute), true);
                    DataFieldAttribute dataFieldAttr = null;
                    if (dataFieldAttrAry.Length > 0)
                        dataFieldAttr = dataFieldAttrAry[0] as DataFieldAttribute;

                    TableFieldInfoDto dto = new TableFieldInfoDto();
                    dto.TableName = TableNames[tableType];
                    dto.FieldName = pi.Name;
                    dto.FieldAlias = string.Join(",", lstAlasAry);
                    dto.CNUnitText = displayFieldAttri.CnUnitText;
                    dto.NoNull = dataFieldAttr.IsNull ? 0 : 1;

                    lstDto.Add(dto);
                }
            }

            return lstDto;
        }

        /// <summary>
        /// 获取一个打开的链接
        /// </summary>
        /// <param name="open">是否打开</param>
        /// <returns></returns>
        private static SQLiteConnection GetOpenConnection()
        {
            try
            {
                string connStr = string.Format("Data Source={0};Version=3;", DbConfig.DBFileFullName);
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

        internal static DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection conn = GetOpenConnection();
                SQLiteCommand com = new SQLiteCommand(sql, conn);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(com))
                {
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误sql:       {sql}");
            }

            return dt;
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
                        Log.Fatal($"执行带事务的sql异常：{ex.ToString()}", MethodBase.GetCurrentMethod());
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