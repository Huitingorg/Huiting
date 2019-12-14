using Huiting.Common;
using Huiting.DB.Access.Helpers;
using System;
using System.Reflection;

namespace Huiting.DB.Access
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            Log.Info("开始", MethodBase.GetCurrentMethod());
            DapperHelper.InitDB();
            DBService.GetInstance();

            Console.WriteLine("OK");

            Console.ReadKey();
        }
    }
}
