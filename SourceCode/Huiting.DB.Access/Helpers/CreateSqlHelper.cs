using Huiting.DB.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Huiting.DB.Access.Helpers
{
    /// <summary>
    /// 创建表帮助类
    /// </summary>
    public static class CreateSqlHelper
    {
        /// <summary>
        /// 通过model创建表sql
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <returns></returns>
        public static string CreateTableByModel(Type t, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            string indexStr = string.Empty;
            try
            {
                //var tableObj = (DataTableAttribute[])t.GetCustomAttributes(typeof(DataTableAttribute), false);
                sb.AppendFormat("CREATE TABLE IF NOT EXISTS {0} (", tableName);
                var propertyNameList = new List<string>();
                foreach (var p in t.GetProperties())
                {
                    //var jsonObj = (JsonPropertyAttribute[])p.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                    //sb.Append(jsonObj[0].PropertyName);

                    var fieldObj = (DataFieldAttribute[])p.GetCustomAttributes(typeof(DataFieldAttribute), false);
                    if (fieldObj.Length == 0)
                    {
                        continue;
                    }

                    sb.AppendFormat("[{0}]", p.Name);
                    sb.Append(" " + fieldObj[0].TypeAndSize);
                    //if (jsonObj.Length == 0 || fieldObj.Length == 0)
                    //{
                    //    continue;
                    //}

                    if (!fieldObj[0].IsNull)
                    {
                        sb.Append(" NOT NULL");
                    }
                    if (fieldObj[0].IsPrimaryKey)
                    {
                        sb.Append(" PRIMARY KEY");
                        if (fieldObj[0].IsIdentity)
                        {
                            sb.Append(" AUTOINCREMENT");
                        }
                    }
                    if (fieldObj[0].IsUnique)
                    {
                        sb.Append(" UNIQUE");
                    }
                    if (fieldObj[0].DefaultValue != null)
                    {
                        sb.Append(" DEFAULT " + fieldObj[0].DefaultValue);
                    }

                    sb.Append(",");

                    if (fieldObj[0].IsIndex)
                    {
                        propertyNameList.Add(p.Name);
                    }
                }

                if (propertyNameList.Count > 0)
                {
                    indexStr = $"CREATE INDEX IF NOT EXISTS {tableName + string.Join("", propertyNameList) + "index"} ON {tableName}({string.Join(",", propertyNameList)});";
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return sb.ToString().TrimEnd(',') + ");" + indexStr;
        }

        /// <summary>
        /// 通过Model创建Replace Sql
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <returns></returns>
        //public static string GetReplaceSqlByModel<T>()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Type t = typeof(T);
        //    var tableObj = (DataTableAttribute[])t.GetCustomAttributes(typeof(DataTableAttribute), false);
        //    sb.AppendFormat("REPLACE INTO {0} VALUES(", tableObj[0].TableName);
        //    foreach (var p in t.GetProperties())
        //    {
        //        sb.AppendFormat("@{0},", p.Name);
        //    }
        //    return sb.ToString().TrimEnd(',') + ");";
        //}

        /// <summary>
        /// 通过Model创建Replace Sql
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetReplaceSqlByModel(Type type, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            //var tableObj = (DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false);
            sb.AppendFormat("REPLACE INTO {0} VALUES(", tableName);
            foreach (var p in type.GetProperties())
            {
                var field = (DataFieldAttribute[])p.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (field?.Length <= 0)
                    continue;
                sb.AppendFormat("@{0},", p.Name);
            }
            return sb.ToString().TrimEnd(',') + ");";
        }

        /// <summary>
        /// 通过Model创建Replace Sql
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetReplaceSqlByModelKey(Type type, string tableName)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();

            foreach (var p in type.GetProperties())
            {
                var field = (DataFieldAttribute[])p.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (field?.Length <= 0)
                    continue;

                sb1.AppendFormat("{0},", p.Name);
                sb2.AppendFormat("@{0},", p.Name);
            }

            return $"REPLACE INTO {tableName} ({sb1.ToString().TrimEnd(',')}) VALUES ({sb2.ToString().TrimEnd(',')})";
        }

        /// <summary>
        /// 通过Model创建Replace Sql,不含id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        //public static string GetReplaceSqlByModelNoId(Type type)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    var tableObj = (DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false);
        //    sb.AppendFormat("REPLACE INTO {0} (", tableObj[0].TableName);
        //    foreach (var p in type.GetProperties())
        //    {
        //        if (p.Name.ToLower() != "id")
        //            sb.AppendFormat("{0},", p.Name);
        //    }
        //    string s = sb.ToString().TrimEnd(',') + ") VALUES(";
        //    sb.Clear();
        //    sb.Append(s);
        //    foreach (var p in type.GetProperties())
        //    {
        //        if (p.Name.ToLower() != "id")
        //            sb.AppendFormat("@{0},", p.Name);
        //    }
        //    return sb.ToString().TrimEnd(',') + ");";
        //}

        /// <summary>
        /// 通过Model创建Insert Sql,不含id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetInsertSqlByModel(Type type, string tableName)
        {
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            //var tableObj = (DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false);
            foreach (var p in type.GetProperties())
            {
                var field = (DataFieldAttribute[])p.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (field?.Length <= 0)
                    continue;
                if (!(field[0].IsIdentity && field[0].IsPrimaryKey))
                {
                    sb1.AppendFormat("{0},", p.Name);
                    sb2.AppendFormat("@{0},", p.Name);
                }
            }
            string sql = $"INSERT INTO {tableName} ({sb1.ToString().TrimEnd(',')}) VALUES ({sb2.ToString().TrimEnd(',')})";
            return sql;
        }

        /// <summary>
        /// 通过Model创建Update Sql,不含id,不带where
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetUpdateSqlByModel(Type type, string tableName)
        {
            StringBuilder sb = new StringBuilder();
            //var tableObj = (DataTableAttribute[])type.GetCustomAttributes(typeof(DataTableAttribute), false);
            foreach (var p in type.GetProperties())
            {
                var field = (DataFieldAttribute[])p.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (field?.Length <= 0)
                    continue;
                if (!(field[0].IsIdentity && field[0].IsPrimaryKey))
                {
                    sb.AppendFormat("{0}=@{0},", p.Name);
                }
            }
            string sql = $"UPDATE {tableName} SET {sb.ToString().TrimEnd(',')} ";
            return sql;
        }
    }
}