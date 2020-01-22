using Huiting.Common;
using Huiting.DBAccess.Generator;
using System;
using System.Reflection;

namespace Huiting.DBAccess
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            Log.Info("开始", MethodBase.GetCurrentMethod());

            DbConfig.DBFileFullName = @"E:\CSharpProject\work\Data\Data.db";
            DtoModelGenerator.GenerateDtosByDBTable();

            Console.WriteLine("OK");

            Console.ReadKey();
        }
    }
}
