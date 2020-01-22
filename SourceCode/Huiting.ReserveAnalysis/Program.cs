using Huiting.DBAccess;
using Huiting.DBAccess.Generator;
using Huiting.DBAccess.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (arg != null && arg.Length > 0)
            {
                Application.Run(new FrmMain());
                return;
            }

            //创建过度页面，并显示
            FrmTranslucent.ShowSplashScreen();

            try
            {
                DapperHelper.InitDB();

                FrmMain frmMain = new FrmMain();
                frmMain.Shown += new EventHandler(frmMain_Shown);
                Application.Run(frmMain);
            }
            catch (Exception ex)
            {
                frmMain_Shown(null, null);
            }

            //Application.Run(new Form5());
            //return;
        }

        //// 中文拼音排序规则  
        //[SQLiteFunction(FuncType = FunctionType.Collation, Name = "PinYin")]
        //class SQLiteCollation_PinYin : SQLiteFunction
        //{
        //    public override int Compare(string x, string y)
        //    {
        //        return string.Compare(x, y);
        //    }
        //}  

        static void frmMain_Shown(object sender, EventArgs e)
        {
            if (FrmTranslucent.SplashScreen != null)
            {
                FrmTranslucent.SplashScreen.BeginInvoke(new MethodInvoker(FrmTranslucent.SplashScreen.Dispose));
                FrmTranslucent.SplashScreen = null;
            }
        }
    }
}