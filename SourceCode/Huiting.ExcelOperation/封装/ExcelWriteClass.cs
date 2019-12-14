using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Huiting.ExcelOperation
{
    public class ExcelWriteClass
    {
       
        //获取单元格风格
        public static ICellStyle GetCellStyle(IWorkbook curWork, CellStyleConfig curStyle)
        {
            ICellStyle cellStyle = curWork.CreateCellStyle();

            IFont font = curWork.CreateFont();
            font.FontName = curStyle.FontName;// 字体名称，如"微软雅黑";
            font.FontHeightInPoints  = curStyle.FontSize;//字体大小
            font.Color = curStyle.FontColor;//字体颜色
            font.Underline = curStyle.FontUnderline;//下载线
            font.IsItalic = curStyle.IsItalic;//斜体
            font.Boldweight = curStyle.BoldWeight;//加粗
            //边框  
            cellStyle.BorderBottom = curStyle.curBorderLineStyle;// NPOI.SS.UserModel.BorderStyle.Dotted;
            cellStyle.BorderLeft = curStyle.curBorderLineStyle;//NPOI.SS.UserModel.BorderStyle.Hair;
            cellStyle.BorderRight = curStyle.curBorderLineStyle;//NPOI.SS.UserModel.BorderStyle.Hair;
            //cellStyle.BorderTop = curStyle.curBorderLineStyle;//NPOI.SS.UserModel.BorderStyle.Dotted;
            //边框颜色  
            cellStyle.BottomBorderColor = curStyle.curBorderLineColorIndex;// HSSFColor.OliveGreen.Blue.Index;
            //cellStyle.TopBorderColor = curStyle.curBorderLineColorIndex;//HSSFColor.OliveGreen.Blue.Index;
            cellStyle.LeftBorderColor = curStyle.curBorderLineColorIndex;
            cellStyle.RightBorderColor = curStyle.curBorderLineColorIndex;
            //背景颜色。
            cellStyle.FillBackgroundColor = curStyle.curBackGroudColorIndex;
            //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
            cellStyle.FillForegroundColor = curStyle.curBackGroudColorIndex; //HSSFColor.White.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground; 
            //cellStyle.FillBackgroundColor = HSSFColor.Blue.Index;
            //水平对齐  
            cellStyle.Alignment = curStyle.curHorizAlign;// NPOI.SS.UserModel.HorizontalAlignment.Left;
            //垂直对齐  
            cellStyle.VerticalAlignment = curStyle.curVerAlign; //VerticalAlignment.Center;
            //自动换行  
            cellStyle.WrapText = curStyle.AutoWrap;
            //缩进;当设置为1时，前面留的空白太大了。
            cellStyle.Indention = 0;

            //cellStyle.Alignment = HorizontalAlignment.

            //下面列出了常用的字段类型  
            switch (curStyle.curCellValueFormatStyle)
            {
                case CellValueFormatStyle.头:
                    // cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.时间:
                    IDataFormat datastyle = curWork.CreateDataFormat();
                    if(!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = datastyle.GetFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = datastyle.GetFormat("yyyy/mm/dd");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.数字:
                    if (!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.钱:
                    IDataFormat format = curWork.CreateDataFormat();
                    if (!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = format.GetFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = format.GetFormat("￥#,##0");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.url:
                    font.Underline = FontUnderlineType.Single;// 1;
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.百分比:
                    if (!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.中文大写:
                    IDataFormat format1 = curWork.CreateDataFormat();
                    if (!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = format1.GetFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.科学计数法:
                    if (!string.IsNullOrEmpty(curStyle.CustomFomatStr))
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat(curStyle.CustomFomatStr);
                    else
                        cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.默认:
                    cellStyle.SetFont(font);
                    break;
            }
            return cellStyle;

        }

        //合并单元格
        public static void MergedCell(ISheet curSheet,int BeginRowIndex,int EndRowIndex,int BeginColumnIndex,int EndColumnIndex)
        {
            curSheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(BeginRowIndex, EndRowIndex, BeginColumnIndex, EndColumnIndex));
            //CellRangeAddress（）该方法的参数次序是：开始行号，结束行号，开始列号，结束列号。
        }

        //设置列宽
        public static void SetColumnWidth(ISheet curSheet,int WidthValue)
        {
            curSheet.SetColumnWidth(0, WidthValue);
            //sh.SetColumnWidth(0, 15 * 256);
        }

    }

    //定义单元格常用到样式的枚举
    public enum CellValueFormatStyle
    {
        头,
        url,
        时间,
        数字,
        钱,
        百分比,
        中文大写,
        科学计数法,
        默认
    }

    public class CellStyleConfig
    {
        //字体
        public string FontName = "宋体";
        //字体大小
        public short FontSize = 9;
        //字体颜色
        public short FontColor = HSSFColor.OliveGreen.Black.Index;
        //字体下载线
        public FontUnderlineType FontUnderline = FontUnderlineType.None;
        //字体斜体
        public bool IsItalic = false;
        //字体加粗
        public short BoldWeight = (short)FontBoldWeight.Normal;
        //值显示格式
        public CellValueFormatStyle curCellValueFormatStyle = CellValueFormatStyle.默认;
        //边框线型
        public BorderStyle curBorderLineStyle = BorderStyle.Thin;
        //边框颜色索引
        public short curBorderLineColorIndex = HSSFColor.OliveGreen.Black.Index;
        //背景颜色
        public short curBackGroudColorIndex = HSSFColor.OliveGreen.White.Index;
        //水平排列位置
        public HorizontalAlignment curHorizAlign = HorizontalAlignment.Center;
        //垂直排列
        public VerticalAlignment curVerAlign = VerticalAlignment.Center;
        //自动换行
        public bool AutoWrap = false;
        //格式
        public string CustomFomatStr = "";
        

    }
   
}
/*
 
  public static ICellStyle GetCellStyle(IWorkbook wb, CellValueFormatStyle str)
        {
            ICellStyle cellStyle = wb.CreateCellStyle();
            //定义几种字体  
            //也可以一种字体，写一些公共属性，然后在下面需要时加特殊的  
            IFont font12 = wb.CreateFont();
            font12.FontHeightInPoints = 10;
            font12.FontName = "微软雅黑";

            IFont font = wb.CreateFont();
            font.FontName = "微软雅黑";
            //font.Underline = 1;下划线 

            IFont fontcolorblue = wb.CreateFont();
            fontcolorblue.Color = HSSFColor.OliveGreen.Blue.Index;
            fontcolorblue.IsItalic = true;//下划线  
            fontcolorblue.FontName = "微软雅黑";

            //边框  
            cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Dotted;
            cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Hair;
            cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Hair;
            cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Dotted;
            //边框颜色  
            cellStyle.BottomBorderColor = HSSFColor.OliveGreen.Blue.Index;
            cellStyle.TopBorderColor = HSSFColor.OliveGreen.Blue.Index;
            //背景图形，我没有用到过。感觉很丑  
            //cellStyle.FillBackgroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
            //cellStyle.FillForegroundColor = HSSFColor.OLIVE_GREEN.BLUE.index;  
            cellStyle.FillForegroundColor = HSSFColor.White.Index;
            // cellStyle.FillPattern = FillPatternType.NO_FILL;  
            cellStyle.FillBackgroundColor = HSSFColor.Blue.Index;
            //水平对齐  
            cellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;
            //垂直对齐  
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            //自动换行  
            cellStyle.WrapText = true;
            //缩进;当设置为1时，前面留的空白太大了。希旺官网改进。或者是我设置的不对  
            cellStyle.Indention = 0;
            //上面基本都是设共公的设置  
            //下面列出了常用的字段类型  
            switch (str)
            {
                case CellValueFormatStyle.头:
                    // cellStyle.FillPattern = FillPatternType.LEAST_DOTS;  
                    cellStyle.SetFont(font12);
                    break;
                case CellValueFormatStyle.时间:
                    IDataFormat datastyle = wb.CreateDataFormat();
                    cellStyle.DataFormat = datastyle.GetFormat("yyyy/mm/dd");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.数字:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.钱:
                    IDataFormat format = wb.CreateDataFormat();
                    cellStyle.DataFormat = format.GetFormat("￥#,##0");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.url:
                    fontcolorblue.Underline = FontUnderlineType.Single;// 1;
                    cellStyle.SetFont(fontcolorblue);
                    break;
                case CellValueFormatStyle.百分比:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00%");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.中文大写:
                    IDataFormat format1 = wb.CreateDataFormat();
                    cellStyle.DataFormat = format1.GetFormat("[DbNum2][$-804]0");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.科学计数法:
                    cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00E+00");
                    cellStyle.SetFont(font);
                    break;
                case CellValueFormatStyle.默认:
                    cellStyle.SetFont(font);
                    break;
            }
            return cellStyle;

        }
 
 */