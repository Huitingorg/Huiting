using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BDSoft.Common
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //exe
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //控制台
            bool b = EnumUse1.D >= EnumUse1.A;
            Console.WriteLine(b.ToString());
            Show(EnumUse2.E);
            HEnum.ForEach((x) => Console.WriteLine("{0} = {1},", x, (int)x));
        }

        static void Show(HEnum e)
        {
            Console.WriteLine(@"{0} = {1},""{2}""", e, (int)e, e.ToString());
        }
    }
}
