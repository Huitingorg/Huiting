using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Huiting.ExcelOperation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //从Excel文件读取数据集测试
          //  Application.Run(new ExcelFileReadToDataSetTest());
            //将Excel文件转换成Html测试
            //Application.Run(new ExcelFileOutPutToHTMLTest());
            //Html预览控件测试
       //     Application.Run(new ExcelViewControlTest());
            Application.Run(new Huiting.ExcelOperation.Test.ExcelWriteTestForm());
         

           
        }
    }
}
