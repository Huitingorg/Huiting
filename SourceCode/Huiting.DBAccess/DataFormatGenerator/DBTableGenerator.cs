using Dapper;
using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Dto;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.DBAccess.DataFormatGenerator
{
    public class DBTableGenerator
    {
        /// <summary>
        /// 检查创建数据库表，存在则更新表机构
        /// </summary>
        /// <param name="tables"></param>
        public static void CreateTable(params Type[] tables)
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
        public static bool UpdateDatabase(SqliteMasterDto oldTable, SqliteMasterDto newTable, bool isClearData)
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
    }
}
