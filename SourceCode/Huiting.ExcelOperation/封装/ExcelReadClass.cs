using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Data;
using System.IO;
namespace Huiting.ExcelOperation
{
    public class ExcelReadClass
    {
        
        /// <summary>
        /// 获取excel数据
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        /// <param name="NullOrEmptyIgnore">控制忽略</param>
        public DataSet GetExcelDataSet(string ExcelPath, Action<int> reportProcessValue = null)
        {
            IWorkbook hssfworkbook = GetIWorkbook(ExcelPath);
            return GetWorkbookDataSet(hssfworkbook,  reportProcessValue);           
        }
       
        /// <summary>
        /// 加载Excel
        /// </summary>
        /// <param name="ExcelPath"></param>
        /// <returns></returns>
        private IWorkbook GetIWorkbook(string ExcelPath)
        {
            IWorkbook hssfworkbook = null;
            try
            {
                if (Path.GetExtension(ExcelPath).Equals(".xls", StringComparison.CurrentCultureIgnoreCase))
                {

                    //可读取被读写进程占用的文件
                    FileStream fs = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);                      
                    hssfworkbook = new HSSFWorkbook(fs);

                }
                else if (Path.GetExtension(ExcelPath).Equals(".xlsx", StringComparison.CurrentCultureIgnoreCase))
                {

                    //可读取被读写进程占用的文件
                    FileStream fs = new FileStream(ExcelPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    hssfworkbook = new XSSFWorkbook(fs);

                }
                else
                {
                    throw new Exception("目前只支持.xls和.xlsx格式的Excel文件解析！");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("加载Excel失败：" + ex.Message + "\n,原因可能是不支持该Excel版本格式的解析！");
            }
            return hssfworkbook;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="iWorkbook"></param>
        /// <param name="NullOrEmptyIgnore"></param>
        /// <returns></returns>
        private DataSet GetWorkbookDataSet(IWorkbook iWorkbook,  Action<int> reportProcessValue = null)
        {
            DataSet ds = new DataSet();
            for (int k = 0; k < iWorkbook.NumberOfSheets; k++)  //NumberOfSheets是myxls.xls中总共的表数
            {
                ISheet sheet = iWorkbook.GetSheetAt(k);   //读取当前表数据
                DataTable dt = CreateDataTable(sheet);
                ds.Tables.Add(dt);
                ReadSheetData(dt, sheet, k, iWorkbook.NumberOfSheets, reportProcessValue);
            }
            return ds;
        }
        /// <summary>
        /// 创建表
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private DataTable CreateDataTable(ISheet sheet)
        {
            DataTable dt = new DataTable(sheet.SheetName);

            #region//创建表
            if (sheet.LastRowNum >= 0)
            {
                IRow rowex = sheet.GetRow(0);  //读取当前行数据
                int MaxCellNum = rowex.LastCellNum;
                AddColumnExcelDt(dt, MaxCellNum);
            }
            #endregion
            return dt;
        }

        /// <summary>
        /// 表添加列
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ColumnCount"></param>
        private void AddColumnExcelDt(DataTable dt, int ColumnCount)
        {
            for (int j = 1; j <= ColumnCount; j++)
            {
                int str10 = j / 26;
                int str1 = j % 26;
                string StrName = "";

                if (str1.Equals(0))
                {
                    str1 = 26;
                    str10--;
                }
                if (str10.Equals(0))
                {
                    StrName = Convert.ToString(Convert.ToChar(64 + str1));
                }
                else
                {
                    StrName = Convert.ToString(Convert.ToChar(64 + str10)) + Convert.ToString(Convert.ToChar(64 + str1));
                }
                dt.Columns.Add(StrName, typeof(string));
            }
        }

        /// <summary>
        /// 读取sheet数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="sheet"></param>
        /// <param name="NullOrEmptyIgnore"></param>
        private void ReadSheetData(DataTable dt, ISheet sheet, int curIndex, int sheetCount, Action<int> reportProcessValue = null)
        {
            #region//读取数据
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);  //读取当前行数据
                if (row == null)
                    continue;
                DataRow newrow = dt.NewRow();

                bool IsNullOrEmpty = true;
                for (int j = 0; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);  //当前表格
                    string cellvalue = "";
                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.Blank: //空数据类型处理
                                {
                                    cellvalue = "";
                                    break;
                                }
                            case CellType.Numeric:
                                {
                                    //特殊处理吧，木办法
                                    string DataFormat = cell.CellStyle.GetDataFormatString();
                                    if (DataFormat == "yyyymm")//
                                    {


                                        //DateTime date = cell.DateCellValue;
                                        //if (string.IsNullOrEmpty(DataFormat))
                                        //{
                                        //    cellvalue = date.ToString("yyyy-MM-dd HH:mm:ss");
                                        //}
                                        //else
                                        //{
                                        //    cellvalue = date.ToString(DataFormat);
                                        //}
                                        //cellvalue = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                        if (DataFormat == "yyyymm")
                                            DataFormat = "yyyyMM";
                                        cellvalue = cell.DateCellValue.ToString(DataFormat);
                                    }
                                    else if (HSSFDateUtil.IsCellInternalDateFormatted(cell))
                                    {
                                        cellvalue = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    else
                                    {
                                        cellvalue = cell.NumericCellValue.ToString();
                                    }
                                    break;
                                }
                            case CellType.String:
                                {
                                    cellvalue = cell.StringCellValue;
                                    break;
                                }
                            case CellType.Formula:
                                {
                                    if (cell.CachedFormulaResultType == CellType.Numeric)
                                    {
                                        cellvalue = cell.NumericCellValue.ToString();
                                    }
                                    else
                                    {
                                        cellvalue = cell.StringCellValue;
                                    }
                                    break;
                                }
                            default:
                                {
                                    cellvalue = cell.ToString();
                                    break;
                                }
                        }
                    }
                    if (!string.IsNullOrEmpty(cellvalue))
                    {
                        IsNullOrEmpty = false;
                    }
                    newrow[j] = cellvalue;


                }

                if (reportProcessValue != null)
                {

                    double dblHaveReadSheetPercent = curIndex * 1.0 / sheetCount;
                    double dblCurSheetPercent = 1 / sheetCount;
                    double dblCurReadRowCountPercent = (i + 1) * 1.0 / sheet.LastRowNum;

                    if (i >= sheet.LastRowNum/2)
                    {

                    }

                    double dblCurProcess = dblHaveReadSheetPercent + dblCurReadRowCountPercent / dblCurSheetPercent;

                    reportProcessValue((int)(dblCurProcess * 100));
                }
                   

                if (IsNullOrEmpty)//如果是空行
                    continue;

                dt.Rows.Add(newrow);
            }

            #endregion
        }

        /// <summary>
        /// 将Datatable数据输出到XLS中
        /// /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="xlsfile"></param>
        public void WriteToXLS(DataTable dataTable, string xlsfile)
        {
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            string tableName = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(dataTable.TableName))
            {
                tableName = dataTable.TableName;
            }
            HSSFSheet sheet = hssfworkbook.CreateSheet(tableName) as HSSFSheet;

            if (false)//!OutPutTableColumnName)//就是是否把table的列头输出为第一行
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sheet.CreateRow(i);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        string value = dataTable.Rows[i][j].ToString();
                        sheet.GetRow(i).CreateCell(j).SetCellValue(value);
                    }
                }
            }
            else
            {
                //输出行头
                sheet.CreateRow(0);
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    string value = string.IsNullOrEmpty(dataTable.Columns[j].Caption) ? dataTable.Columns[j].ColumnName : dataTable.Columns[j].Caption;
                    //ICell cell = sheet.GetRow(0).CreateCell(j);
                    sheet.GetRow(0).CreateCell(j).SetCellValue(value);
                    
                    
                    int value11 = sheet.GetColumnWidth(j);
                    sheet.SetColumnWidth(j, value11*2);
                }
                //
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    sheet.CreateRow(i + 1);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        string value = dataTable.Rows[i][j].ToString();
                        sheet.GetRow(i + 1).CreateCell(j).SetCellValue(value);
                    }
                }
            }
           
            FileStream file = null;
            if (File.Exists(xlsfile))
            {
                file = new FileStream(xlsfile, FileMode.Open);
            }
            else
            {
                file = new FileStream(xlsfile, FileMode.Create);
            }
            hssfworkbook.Write(file);
            file.Close();
        }

    }
}
