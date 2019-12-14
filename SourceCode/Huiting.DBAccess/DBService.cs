using Dapper;
using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Dto;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess
{
    /// <summary>
    /// 数据库操作服务--DBService为操作数据库唯一入口
    /// </summary>
    public partial class DBService
    {
        #region 属性

        /// <summary>
        /// 单例
        /// </summary>
        private static DBService _uniqueInstance;

        /// <summary>
        /// 同步锁
        /// </summary>
        private static readonly object Locker = new object();

        public Dictionary<string, ICache> Logics = new Dictionary<string, ICache>();

        /// <summary>
        /// 获取DbService实例
        /// </summary>
        /// <returns>DbService实例</returns>
        public static DBService Instance
        {
            get
            {
                // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
                // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
                // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
                lock (Locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (_uniqueInstance == null)
                    {
                        _uniqueInstance = new DBService();
                    }
                }

                return _uniqueInstance;
            }
        }

        #endregion 属性

        #region 构造

        /// <summary>
        /// 构造
        /// </summary>
        private DBService()
        {
            try
            {
                //包含所有数据库表的type数组
                List<Type> tableList = new List<Type> {                  
                };

                CreateTable(tableList.ToArray());
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        #endregion 构造

        /// <summary>
        /// 检查创建数据库表，存在则更新表机构
        /// </summary>
        /// <param name="tables"></param>
        public void CreateTable(params Type[] tables)
        {
            var OldCreateSqlList = new List<SqliteMasterDto>();
            //List<SqliteMasterDto> NewCreateSqlList = new List<SqliteMasterDto>();
            //查询所有建表语句
            OldCreateSqlList = DapperHelper.SqlWithParams<SqliteMasterDto>("select * from sqlite_master where sql is not null;")?.ToList();
            //所有建表Sql语句
            var tableSB = new StringBuilder();
            //var isFirstSync = false;

            foreach (var table in tables)
            {
                var dataTableAttribute = ((DataTableAttribute[])table.GetCustomAttributes(typeof(DataTableAttribute), false))[0];

                string tableName = dataTableAttribute.TableName;
                string sqlStr = CreateSqlHelper.CreateTableByModel(table, tableName);
                CacheService.GetInstance().AddTableNames(table);
                var temp = OldCreateSqlList?.FirstOrDefault(old => old.Tbl_Name == tableName && old.Type.ToLower() == "table");
                //存在新旧表名一致
                if (temp != null)
                {
                    var newSqlList = sqlStr.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    //新旧表的建表语句不一致，则表需要更新
                    if (temp.Sql.Replace(" ", "") != newSqlList[0].Replace(" ", "").Replace("IFNOTEXISTS", "")
                        || (newSqlList.Count() > 1 && newSqlList[1].Replace(" ", "").Replace("IFNOTEXISTS", "") != OldCreateSqlList?.FirstOrDefault(old => old.Tbl_Name == tableName && old.Type.ToLower() == "index")?.Sql.Replace(" ", "")))
                    {
                        //isFirstSync = true;
                        var li = new SqliteMasterDto { Name = tableName, Tbl_Name = tableName, Sql = sqlStr, TableType = table };
                        UpdateDatabase(temp, li, dataTableAttribute.IsClearData);
                    }
                }
                else
                {
                    tableSB.Append(sqlStr);
                    //isFirstSync = true;
                }
            }

            //CacheInfo.IsFirstSync = isFirstSync;

            if (!string.IsNullOrWhiteSpace(tableSB.ToString()))
                DapperHelper.Execute(tableSB.ToString());
        }

        /// <summary>
        /// 更新数据库
        /// </summary>
        /// <param name="oldTable"></param>
        /// <param name="newTable"></param>
        /// <param name="isClearData"></param>
        /// <returns></returns>
        public bool UpdateDatabase(SqliteMasterDto oldTable, SqliteMasterDto newTable, bool isClearData)
        {
            return DapperHelper.SQLLiteSession<int>((conn, trans) =>
            {
                StringBuilder sql = new StringBuilder();
                //修改原表名
                sql.Append($"ALTER TABLE {oldTable.Tbl_Name} RENAME TO {oldTable.Tbl_Name + "_Temp"};");
                //创建新表
                sql.Append(newTable.Sql);

                if (!isClearData)
                {
                    //查询原表结构
                    List<TableInfoDto> oldFieldList = conn.Query<TableInfoDto>($"pragma table_info({oldTable.Tbl_Name});", null, trans)?.ToList();
                    //反射得到新表的属性List
                    var newFieldList = newTable.TableType.GetProperties();
                    //拼接原表和新表共有属性
                    StringBuilder fieldStr = new StringBuilder();
                    oldFieldList.ForEach(s =>
                    {
                        string fieldName = s.Name.ToLower();
                        var fieldNameExists = newFieldList.FirstOrDefault(f => f.Name.ToLower() == fieldName);
                        if (fieldNameExists != null)
                        {
                            fieldStr.Append("[" + fieldName + "],");
                        }
                    });
                    string fieldS = fieldStr.ToString().TrimEnd(',');
                    //将原表的数据导入到新表
                    sql.Append($"INSERT INTO {newTable.Tbl_Name}({fieldS}) SELECT {fieldS} FROM {oldTable.Tbl_Name + "_Temp"};");
                }

                //删除原表
                sql.Append($"DROP TABLE {oldTable.Tbl_Name + "_Temp"};");
                return conn.Execute(sql.ToString(), null, trans);
            }) > 0;
        }


        public void DeleteTableOnce(Type[] types)
        {
            string tempName = "DeleteTableOnce_temp2";
            int existTemp = DapperHelper.SqlScalarWithParams<int>($"select count(*) from sqlite_master where tbl_name='{tempName}'");
            if (existTemp <= 0)
            {
                DapperHelper.SQLLiteSession((conn, trans) =>
                {
                    conn.Execute("delete from saas_employee where isDisabled is null or isDisabled='';", null, trans);
                    foreach (var t in types)
                    {
                        string tableName = CacheService.GetInstance().TableNames[t];
                        conn.Execute($"delete from {tableName};", null, trans);
                    }
                    conn.Execute($"create table if not exists {tempName} (id integer);", null, trans);
                });
            }
        }

        public void SetPositionIdForOldData()
        {
            string sql = "update saas_order_detail set positionId=(select positionId from saas_inventory_lot_number where productPref=saas_order_detail.productCode and lotNumber=saas_order_detail.BatchNo) where positionId is null or positionId<=0;update saas_prescription_detail set positionId=(select positionId from saas_inventory_lot_number where productPref=saas_prescription_detail.productPref and lotNumber=saas_prescription_detail.lotNumber) where positionId is null or positionId<=0;";
            DapperHelper.Execute(sql);
        }

        public void DeleteTableData(Type[] types)
        {
            DapperHelper.SQLLiteSession((conn, trans) =>
            {
                foreach (var t in types)
                {
                    string name = CacheService.GetInstance().TableNames[t];// ((DataTableAttribute[])t.GetCustomAttributes(typeof(DataTableAttribute), false))[0].TableName;
                    conn.Execute($"delete from {name};", null, trans);
                }
            });
        }
        public static DBService GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            lock (Locker)
            {
                // 如果类的实例不存在则创建，否则直接返回
                if (_uniqueInstance == null)
                {
                    _uniqueInstance = new DBService();
                }
            }

            return _uniqueInstance;
        }




    }

}
