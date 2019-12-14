using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using BDSoft.Components;
using System.Windows.Forms;
using NPOI.HSSF.Util;
namespace Huiting.ExcelOperation
{
    public class ExcelReadClass
    {
        /// <summary>
        /// 获取excel数据
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        public DataSet GetExcelDataSet(string ExcelPath)
        {
            return GetExcelDataSet(ExcelPath, true);
        }

        /// <summary>
        /// 获取excel 数据至数据表，直接把第一行转成表头
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        /// <returns>数据表</returns>
        public DataSet GetExcelDataSetEx(string ExcelPath)
        {
            DataSet curSet = new DataSet();
            curSet = GetExcelDataSet(ExcelPath, true);
            if (curSet.Tables.Count == 0) 
            {
                return curSet;
            }
            int index = 0;
            string tempValue = "";
            foreach (DataTable curTable in curSet.Tables)
            {
                if((curTable.Columns.Count == 0)||(curTable.Rows.Count == 0))
                {
                    continue;
                }
                index = 0;
                foreach (DataColumn curColumn in curTable.Columns)
                {
                    tempValue = curTable.Rows[0][index].ToString();
                    if (!string.IsNullOrEmpty(tempValue))
                    {
                        curColumn.ColumnName = tempValue;

                    }

                    index++;
                }
                curTable.Rows.RemoveAt(0);
            }
            
            return curSet;
        }
        /// <summary>
        /// 获取excel数据
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        /// <param name="NullOrEmptyIgnore">控制忽略</param>
        public DataSet GetExcelDataSet(string ExcelPath, bool NullOrEmptyIgnore)
        {
            IWorkbook hssfworkbook = GetIWorkbook(ExcelPath);
            return GetWorkbookDataSet(hssfworkbook, NullOrEmptyIgnore);           
        }
        /// <summary>
        /// 获取excel数据
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        /// <param name="SheetIndexList">Sheet页名称列表</param>
        /// <param name="NullOrEmptyIgnore">控制忽略</param>
        public DataSet GetExcelDataSet(string ExcelPath, List<int> SheetIndexList, bool NullOrEmptyIgnore)
        {
            IWorkbook iWorkbook = GetIWorkbook(ExcelPath);
            DataSet ds = new DataSet();
            for (int k = 0; k < iWorkbook.NumberOfSheets; k++)  //NumberOfSheets是myxls.xls中总共的表数
            {
                if (SheetIndexList.Contains(k))
                {
                    ISheet sheet = iWorkbook.GetSheetAt(k);   //读取当前表数据
                    DataTable dt = CreateDataTable(sheet);
                    ds.Tables.Add(dt);
                    ReadSheetData(dt, sheet, NullOrEmptyIgnore);
                }
            }
            return ds;
            
        }
        /// <summary>
        /// 获取excel数据
        /// </summary>
        /// <param name="ExcelPath">Excel路径</param>
        /// <param name="SheetNameList">Sheet页名称列表</param>
        /// <param name="NullOrEmptyIgnore">控制忽略</param>
        public DataSet GetExcelDataSet(string ExcelPath, List<string> SheetNameList, bool NullOrEmptyIgnore)
        {
            IWorkbook iWorkbook = GetIWorkbook(ExcelPath);
            DataSet ds = new DataSet();
            for (int k = 0; k < iWorkbook.NumberOfSheets; k++)  //NumberOfSheets是myxls.xls中总共的表数
            {
                ISheet sheet = iWorkbook.GetSheetAt(k);   //读取当前表数据
                if (SheetNameList.Contains(sheet.SheetName))
                {
                    DataTable dt = CreateDataTable(sheet);
                    ds.Tables.Add(dt);
                    ReadSheetData(dt, sheet, NullOrEmptyIgnore);
                }
            }
            return ds;
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
        private DataSet GetWorkbookDataSet(IWorkbook iWorkbook, bool NullOrEmptyIgnore)
        {
            DataSet ds = new DataSet();
            for (int k = 0; k < iWorkbook.NumberOfSheets; k++)  //NumberOfSheets是myxls.xls中总共的表数
            {
                ISheet sheet = iWorkbook.GetSheetAt(k);   //读取当前表数据
                DataTable dt = CreateDataTable(sheet);
                ds.Tables.Add(dt);
                ReadSheetData(dt, sheet, NullOrEmptyIgnore);
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
                int MaxCellNum = 0;
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    IRow rowex = sheet.GetRow(i);  //读取当前行数据
                    if (rowex != null && rowex.LastCellNum > MaxCellNum)
                    {
                        MaxCellNum = rowex.LastCellNum;
                    }
                }
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
        private void ReadSheetData(DataTable dt, ISheet sheet, bool NullOrEmptyIgnore)
        {
            #region//读取数据
            List<DataRow> NullOrEmptyRowList = new List<DataRow>();//空行
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);  //读取当前行数据
                DataRow newrow = dt.NewRow();
                
                bool IsNullOrEmpty = true;
                if (row != null)
                {
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
                }

                if ((IsNullOrEmpty))//如果是空行
                {
                    if (!NullOrEmptyIgnore)//如果是空置不忽略
                    {
                        NullOrEmptyRowList.Add(newrow);//添加空行队列中
                    }
                }
                else
                {
                    foreach (DataRow currow in NullOrEmptyRowList)
                    {
                        dt.Rows.Add(currow);
                    }
                    NullOrEmptyRowList.Clear();
                    dt.Rows.Add(newrow);
                }
            }


            //去除多余的空列
            bool HasEmptyColumn = true;
            while (HasEmptyColumn)
            {
                if (dt == null || dt.Columns.Count == 0||dt.Rows.Count==0)
                    break;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[dt.Columns.Count - 1].ToString() != "")
                    {
                        HasEmptyColumn = false;
                        break;
                    }
                }
                if (HasEmptyColumn)
                {
                    dt.Columns.RemoveAt(dt.Columns.Count - 1);
                }
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
    public class OpTreeHeadDataGridViewToExcelClass
    {
        string FilePath = "";
        TreeHeadDataGridView curGrid;
        DataGridViewColumnNode curColumnNode = null;
        DataTable curTable = null;
        
        IWorkbook curWorkBook = null;
        ISheet curSheet = null;

        ICellStyle HeadStyle = null;//标题头风格
        ICellStyle ContentStyle = null;//内容风格
        //当前排序字段
        string SortFiled = "";
        int curRowsIndex = 0;
        public OpTreeHeadDataGridViewToExcelClass(string FilePath, TreeHeadDataGridView curGrid)
        {
            this.FilePath = FilePath;
            this.curGrid = curGrid;
            curColumnNode = curGrid.TreeHeadRootColumn;

            curWorkBook = new HSSFWorkbook();
            curSheet = curWorkBook.CreateSheet("数据");
            InitSortColumnsInfo();
           
        }

        private void InitSortColumnsInfo()
        {
            DataGridViewColumn curSortColumn = curGrid.SortedColumn;
            if(curSortColumn == null)
            {
                return;
            }

            SortFiled = curSortColumn.DataPropertyName;
            //curGrid.SortOrder == SortOrder.Ascending

        }

        //初始化单元格备用风格
        private void InitCommonCellStyle()
        {
            CellStyleConfig curHeadStyle = new CellStyleConfig();
            curHeadStyle.FontName = "黑体";
            curHeadStyle.FontSize = 10;
            curHeadStyle.BoldWeight = 1;// 700;
            //curStyle.curCellValueFormatStyle = CellValueFormatStyle.头;
            curHeadStyle.curBackGroudColorIndex = HSSFColor.OliveGreen.Grey25Percent.Index;
            curHeadStyle.curBorderLineColorIndex = HSSFColor.OliveGreen.Black.Index;
            curHeadStyle.curVerAlign = VerticalAlignment.Center;
            curHeadStyle.AutoWrap = true;
            HeadStyle = ExcelWriteClass.GetCellStyle(curWorkBook, curHeadStyle);

            CellStyleConfig curDataStyle = new CellStyleConfig();
            curDataStyle.FontName = "宋体";
            curDataStyle.FontSize = 10;
            curDataStyle.BoldWeight = 1;// 700;
            //curStyle.curCellValueFormatStyle = CellValueFormatStyle.头;
            //curDataStyle.curBackGroudColorIndex = HSSFColor.OliveGreen.LightBlue.Index;
            curDataStyle.curBorderLineColorIndex = HSSFColor.OliveGreen.Black.Index;
            curDataStyle.curVerAlign = VerticalAlignment.Center;
            curDataStyle.AutoWrap = true;
            ContentStyle = ExcelWriteClass.GetCellStyle(curWorkBook, curDataStyle);


        }

        //初始化网格绑定的数据表
        private void InitDataTable()
        {
            DataTable BindTable = null;
            switch (curGrid.DataSource.GetType().Name)
            {
                case "DataTable":
                    BindTable = (DataTable)curGrid.DataSource;
                    break;
                case "BindingSource":
                    BindTable = (DataTable)((BindingSource)curGrid.DataSource).DataSource;
                    break;
                default:
                    throw new Exception("未处理的数据源类型");

            }
            curTable = BindTable.Copy();
        }

        public void BeginOp()
        {
            //初始化单元风格
            InitCommonCellStyle();
            //获取相关数据
            InitDataTable();
            //构建Excel头
            BuilderHeadColumn();
            //写入数据
            WriteTableData();
            //保存文件
            SaveFile();


        }

        private void BuilderHeadColumn_Old()//旧版本只支持二层目录
        {
            //设置表头单元格式
            for(int i=0;i<curColumnNode.Deep;i++)
            {
                IRow curRow = curSheet.CreateRow(i);
                curRow.Height = 300;
                SetRowsStyle(curRow, HeadStyle);
            }
            int curColumnIndex = 0;
            foreach(DataGridViewColumnNode curNode in curColumnNode.GetLstLeafColumn())
            {
                curSheet.SetColumnWidth(curColumnIndex, curNode.Width*38);
                curColumnIndex++;
            }
            curColumnIndex = 0;
            foreach(DataGridViewColumnNode curNode in curColumnNode.ChildColumns)
            {
                //处理表头合并功能
                OpMergedCell(curNode, 0,curColumnIndex);
                curColumnIndex = curColumnIndex + curNode.GetLstLeafColumn().Count;


                //IRow row1 = curSheet.CreateRow(1);
                

                //ICell curCell0 = row1.CreateCell(0);
                //curCell0.CellStyle = HeadStyle;
                //curCell0.SetCellValue("COMPANY:");
                //curColumnIndex++;
            }
        }

        private void BuilderHeadColumn()
        {
            //设置表头单元格式
            for (int i = 0; i < curColumnNode.Deep; i++)
            {
                IRow curRow = curSheet.CreateRow(i);
                curRow.Height = 300;
                SetRowsStyle(curRow, HeadStyle);
            }
            int curColumnIndex = 0;
            foreach (DataGridViewColumnNode curNode in curColumnNode.GetLstLeafColumn())
            {
                curSheet.SetColumnWidth(curColumnIndex, curNode.Width * 38);
                curColumnIndex++;
            }
            curColumnIndex = 0;
            foreach (DataGridViewColumnNode curNode in curColumnNode.ChildColumns)
            {
                //处理表头合并功能
                OpMergedCell(curNode, 0, curColumnIndex);
                curColumnIndex = curColumnIndex + curNode.GetLstLeafColumn().Count;


                //IRow row1 = curSheet.CreateRow(1);


                //ICell curCell0 = row1.CreateCell(0);
                //curCell0.CellStyle = HeadStyle;
                //curCell0.SetCellValue("COMPANY:");
                //curColumnIndex++;
            }
        }

        private void WriteTableDataEx()
        {
            int curRowIndex = curColumnNode.Deep;
            int ColumnIndex = 0;
            string TempValue = "";

           
            if(string.IsNullOrEmpty(SortFiled))
            {
                foreach (DataRow curRow in curTable.Rows)
                {
                    ColumnIndex = 0;
                    foreach (DataGridViewColumnNode curNode in curColumnNode.GetLstLeafColumn())
                    {
                        TempValue = curRow[curNode.DataPropertyName].ToString();
                        if (string.IsNullOrEmpty(TempValue))
                        {
                            ColumnIndex++;
                            continue;
                        }
                        if (IsNumType(curNode.DataPropertyName))
                        {
                            SetCellValue(curRowIndex, ColumnIndex, TempValue, true, ContentStyle);
                        }
                        else
                        {
                            SetCellValue(curRowIndex, ColumnIndex, TempValue, false, ContentStyle);

                        }
                        ColumnIndex++;

                    }
                    curRowIndex++;
                }
            }
            else
            {
                DataRow[] Rows = null;
                if(curGrid.SortOrder == SortOrder.Ascending)
                {
                    Rows = curTable.Select("", SortFiled);
                }
                else
                {
                    Rows = curTable.Select("", SortFiled + " desc");
                }
                foreach (DataRow curRow in Rows)
                {
                    ColumnIndex = 0;
                    foreach (DataGridViewColumnNode curNode in curColumnNode.GetLstLeafColumn())
                    {
                        TempValue = curRow[curNode.DataPropertyName].ToString();
                        if (string.IsNullOrEmpty(TempValue))
                        {
                            ColumnIndex++;
                            continue;
                        }
                        if (IsNumType(curNode.DataPropertyName))
                        {
                            SetCellValue(curRowIndex, ColumnIndex, TempValue, true, ContentStyle);
                        }
                        else
                        {
                            SetCellValue(curRowIndex, ColumnIndex, TempValue, false, ContentStyle);

                        }
                        ColumnIndex++;

                    }
                    curRowIndex++;
                }
            }

           
           
        }

        //从DataGridView中取数据源，确保顺序一致
        private void WriteTableData()
        {
            int curRowIndex = curColumnNode.Deep;
            int ColumnIndex = 0;
            string TempValue = "";

            foreach (DataGridViewRow curGridRow in curGrid.Rows)
            {
                
                DataRowView curRow = (DataRowView)curGridRow.DataBoundItem;
                if(curRow == null)
                {
                    continue;
                }
                ColumnIndex = 0;
                foreach (DataGridViewColumnNode curNode in curColumnNode.GetLstLeafColumn())
                {
                    TempValue = curRow[curNode.DataPropertyName].ToString();
                    if (string.IsNullOrEmpty(TempValue))
                    {
                        ColumnIndex++;
                        continue;
                    }
                    if (IsNumType(curNode.DataPropertyName))
                    {
                        SetCellValue(curRowIndex, ColumnIndex, TempValue, true, ContentStyle);
                    }
                    else
                    {
                        SetCellValue(curRowIndex, ColumnIndex, TempValue, false, ContentStyle);
                    }
                    ColumnIndex++;
                }
                curRowIndex++;
            }
            
            
        }

        //处理单元格合并
        private void OpMergedCell(DataGridViewColumnNode curNode,int RowIndex,int ColumnIndex)
        {
            SetCellValue(RowIndex, ColumnIndex, curNode.Text, false, HeadStyle);
            int curColumnIndex = ColumnIndex;
            int curRowIndex = RowIndex;
            int MergedColumnCount = curNode.GetLstLeafColumn().Count;
            //如果是叶子节点
            if (curNode.IsLeafColumn)
            {
                int MergedRowCount = curColumnNode.Deep - curNode.FakeLevel;
                if((MergedRowCount==1)&&(MergedColumnCount==1))
                {
                    return;

                }
                //直接向下合并

                ExcelWriteClass.MergedCell(curSheet, RowIndex, RowIndex + MergedRowCount - 1, curColumnIndex, curColumnIndex + MergedColumnCount - 1);
                //ExcelWriteClass.MergedCell(curSheet, curRowsIndex, curRowsIndex + MergedRowCount - 1, curColumnIndex, curColumnIndex + MergedColumnCount - 1);
                return;

            }
            else
            {
                //如果有子项
                if (MergedColumnCount>1)
                {
                    ExcelWriteClass.MergedCell(curSheet, RowIndex, RowIndex, curColumnIndex, curColumnIndex + MergedColumnCount - 1);
                    //ExcelWriteClass.MergedCell(curSheet, curRowsIndex, curRowsIndex, curColumnIndex, curColumnIndex + MergedColumnCount - 1);
                }
                foreach (DataGridViewColumnNode curChildNode in curNode.ChildColumns)
                {
                    OpMergedCell(curChildNode, curRowIndex+1,curColumnIndex);
                    curColumnIndex = curColumnIndex + curChildNode.GetLstLeafColumn().Count;
                }
                return;

            }
          


        }

        private void SetCellValue(int RowIndex, int ColumnIndex, string Value, bool IsNum, ICellStyle curCellStyle)
        {
            IRow curExcelRow = curSheet.GetRow(RowIndex);
            if (curExcelRow == null)
            {
                curExcelRow = curSheet.CreateRow(RowIndex);
                SetRowsStyle(curExcelRow, curCellStyle);
            }

            if (string.IsNullOrEmpty(Value))
            {
                return;
            }

            ICell curCell = curExcelRow.GetCell(ColumnIndex);
            if (curCell == null)
            {
                curCell = curExcelRow.CreateCell(ColumnIndex);

            }
            curCell.CellStyle = curCellStyle;
            if (IsNum)
            {
                curCell.SetCellValue(double.Parse(Value));
            }
            else
            {
                curCell.SetCellValue(Value);

            }
        }
        private void SetRowsStyle(IRow curRow, ICellStyle curCellStyle)
        {
            int Count = curColumnNode.GetLstLeafColumn().Count;
            for (int i = 0; i < Count; i++)
            {
                ICell curCell = curRow.CreateCell(i);
                curCell.CellStyle = curCellStyle;
            }
        }

        private void SaveFile()
        {
            string Path = FilePath;// @"c:/myExcelTest.xls";
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
            using (FileStream stm = File.OpenWrite(Path))
            {
                curWorkBook.Write(stm);
                //MessageBox.Show("提示：创建成功！");
                stm.Close();
                stm.Dispose();
            }
        }

        public bool IsNumType(string FieldName)
        {
            bool isNum = true;
            Type curType = curTable.Columns[FieldName].DataType;
            switch (curType.Name)
            {
                case "Char":
                    isNum = false;
                    break;
                case "String":
                    isNum = false;
                    break;
                case "DateTime":
                    isNum = false;
                    break;
                default:
                    isNum = true;
                    break;
            }
            return isNum;
        }
    }
}
