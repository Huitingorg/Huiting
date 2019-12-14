using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.ExcelOperation.Test
{
    public partial class ExcelWriteTestForm : Form
    {
        public ExcelWriteTestForm()
        {
            InitializeComponent();
        }


        private void CreateExcelFile()
        {

            IWorkbook wb = new HSSFWorkbook();
            //创建表  
            ISheet sh = wb.CreateSheet("zhiyuan");
            //设置单元的宽度  
            sh.SetColumnWidth(0, 15 * 256);
            sh.SetColumnWidth(1, 35 * 256);
            sh.SetColumnWidth(2, 15 * 256);
            sh.SetColumnWidth(3, 10 * 256);
            int i = 0;
            #region 练习合并单元格
            sh.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3));
            //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。

            IRow row0 = sh.CreateRow(0);
            row0.Height = 20 * 20;
            ICell icell1top0 = row0.CreateCell(0);
            icell1top0.CellStyle = Getcellstyle(wb, CellValueFormatStyle.头);
            icell1top0.SetCellValue("标题合并单元");
            icell1top0.CellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
            #endregion
            i++;
            #region 设置表头
            IRow row1 = sh.CreateRow(1);
            row1.Height = 20 * 20;
            ICell icell1top = row1.CreateCell(0);
            icell1top.CellStyle = Getcellstyle(wb, CellValueFormatStyle.头);
            icell1top.SetCellValue("网站名");
            ICell icell2top = row1.CreateCell(1);
            icell2top.CellStyle = Getcellstyle(wb, CellValueFormatStyle.头);
            icell2top.SetCellValue("网址");
            ICell icell3top = row1.CreateCell(2);
            icell3top.CellStyle = Getcellstyle(wb, CellValueFormatStyle.头);
            icell3top.SetCellValue("百度快照");
            ICell icell4top = row1.CreateCell(3);
            icell4top.CellStyle = Getcellstyle(wb, CellValueFormatStyle.头);
            icell4top.SetCellValue("百度收录");
            #endregion
            
            using (FileStream stm = File.OpenWrite(@"c:/myMergeCell.xls"))
            {
                wb.Write(stm);
                MessageBox.Show("提示：创建成功！");
            }
        }


       
        #region 定义单元格常用到样式
        static ICellStyle Getcellstyle(IWorkbook wb, CellValueFormatStyle str)
        {
            CellStyleConfig curStyle = new CellStyleConfig();
            curStyle.curCellValueFormatStyle = str;
            curStyle.curBorderLineColorIndex = HSSFColor.OliveGreen.White.Index; 
            return ExcelWriteClass.GetCellStyle(wb, curStyle);
            

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            CreateExcelFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateSECExcelFile();
        }

        private void CreateSECExcelFile()
        {
            IWorkbook curWorkBook = new HSSFWorkbook();
            //创建表  
            ISheet curSheet = curWorkBook.CreateSheet("SEC");
            //设置列宽
            SetColumnWidth(curSheet);
            //插入第一行
            Insert1Row(curWorkBook,curSheet);
            //保存
            SaveFile(curWorkBook);
        }

        private void Insert1Row( IWorkbook curWorkBook,ISheet curSheet)
        {
            //设置合并列
            ExcelWriteClass.MergedCell(curSheet, 0, 0, 2, 9);
            IRow row0 = curSheet.CreateRow(0);
            row0.Height = 1000;
            

            CellStyleConfig curStyle = new CellStyleConfig();
            curStyle.FontName = "Dialog";
            curStyle.FontSize = 7;
            curStyle.BoldWeight = 800;
            curStyle.curCellValueFormatStyle = CellValueFormatStyle.头;
            curStyle.curBorderLineColorIndex = HSSFColor.OliveGreen.White.Index;
            curStyle.curVerAlign = VerticalAlignment.Center;
            curStyle.AutoWrap = true;
            ICellStyle curCellStyle = ExcelWriteClass.GetCellStyle(curWorkBook, curStyle);

            SetRowsStyle(curSheet, row0, curCellStyle);
            
            string Str = @"CHINA PETROLEUM & CHEMICAL CORPORATION
THE ESTIMATE OF RESERVES AND FUTURE INCOME ATTRIBUTABLE
TO CERTAIN INTERESTS";
            row0.Cells[2].SetCellValue(Str);

            
        }

        private void SetColumnWidth(ISheet curSheet)
        {
            for(int i=0;i<13;i++)
            {
                ExcelWriteClass.SetColumnWidth(curSheet, 9*256);
            }
        }

        private void SetRowsStyle(ISheet curSheet, IRow row0, ICellStyle curCellStyle)
        {
            for (int i = 0; i < 13; i++)
            {
                ICell Cell0 = row0.CreateCell(i);
                Cell0.CellStyle = curCellStyle;
                Cell0.SetCellValue("");
            }
        }

        private void SaveFile(IWorkbook curWorkBook)
        {
            string Path = @"d:/mySECTest.xls";
            if(File.Exists(Path))
            {
                File.Delete(Path);
            }
            using (FileStream stm = File.OpenWrite(Path))
            {
                curWorkBook.Write(stm);
                MessageBox.Show("提示：创建成功！");
            }
        }


    }
}
