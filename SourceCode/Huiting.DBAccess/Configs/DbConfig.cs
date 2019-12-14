using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;

namespace Huiting.DBAccess.Configs
{
    public class DbConfig
    {
        /// <summary>
        /// 配置文件SAAS路径
        /// </summary>
        public static string SAASFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SAAS\\";

        /// <summary>
        /// 数据库文件名常量
        /// </summary>
        public const string DB = "clientdb.dll";

        /// <summary>
        /// 分页信息记录文件常量
        /// </summary>
        public const string PAGEINFO = "pageInfo.json";

        /// <summary>
        /// 记录用户信息
        /// </summary>
        public const string USERINFO = "user.json";

        /// <summary>
        /// 身份证前六位地址对照码
        /// </summary>
        public const string ADDRESSINFO = "address.json";

        /// <summary>
        /// 读配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>T.</returns>
        public static T ReadConfig<T>(string fileName)
        {
            try
            {
                if (File.Exists(SAASFolder + fileName))
                {
                    var serializer = new JsonSerializer();
                    using (var sr = new StreamReader(SAASFolder + fileName))
                    using (JsonReader reader = new JsonTextReader(sr))
                    {
                        var setting = serializer.Deserialize<T>(reader);
                        return setting;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return default(T);
        }

        /// <summary>
        ///     存配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="data">The data.</param>
        public static void SaveConfig<T>(string fileName, T data)
        {
            try
            {
                if (!Directory.Exists(SAASFolder))
                    Directory.CreateDirectory(SAASFolder);

                var serializer = new JsonSerializer();
                using (var sw = new StreamWriter(SAASFolder + "\\" + fileName))
                {
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, data);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
}
