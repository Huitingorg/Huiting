using System;
using System.IO;

namespace Huiting.DBAccess
{
    public class DbConfig
    {
        /// <summary>
        /// 数据库文件名
        /// </summary>
        public static string DBName { get; internal set; } = "data.db";

        /// <summary>
        /// 配置数据库文件路径
        /// </summary>
        public static string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../data");

        /// <summary>
        /// 数据库文件完整路径
        /// </summary>
        public static string DBFileFullName { get; internal set; } = Path.Combine(DBPath, DBName);
    }
}
