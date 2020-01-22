using Huiting.Common;
using Huiting.DB.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Huiting.DB.Access.Helpers
{
    internal class DBAccessHelper
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
                string fullPath = Path.Combine(@"D:\Project\TestData", "data.db");
                string connStr = string.Format("Data Source={0};Version=3;", DbConfig.DBFileFullName);
                var connection = new SQLiteConnection(connStr);
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString(),System.Reflection.MethodBase.GetCurrentMethod());
            }
            return null;
        }

        public static DataTable GetDataTable(string sql)
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

                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"错误sql:       {sql}");
            }

            return dt;
        }
    }
}
