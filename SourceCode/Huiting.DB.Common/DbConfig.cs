using System;
using System.IO;

namespace Huiting.DB.Common
{
    public class DbConfig
    {
        /// <summary>
        /// 数据库文件名
        /// </summary>
        public const string DBName = "data.db";

        /// <summary>
        /// 配置数据库文件路径
        /// </summary>
        public static string DBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../data");

        /// <summary>
        /// 数据库文件完整路径
        /// </summary>
        public static string DBFileFullName = Path.Combine(DBPath, DBName);
    }
}
