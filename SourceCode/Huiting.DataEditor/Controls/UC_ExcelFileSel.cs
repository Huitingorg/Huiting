using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Huiting.DataEditor.Enum;
using Huiting.Common;
using Huiting.DataEditor.Models;
using Huiting.DataEditor.ExcelHelper;
using Huiting.ExcelOperation;

namespace Huiting.DataEditor.Controls
{
    public partial class UC_ExcelFileSel : MyUserControl
    {
        string userSelFilePath = "";

        /// <summary>
        /// 用户选择的Excel文件转换成了数据集
        /// </summary>
        public DataSet curExcelSet = new DataSet();

        /// <summary>
        /// 用户选择的数据操作类型
        /// </summary>
        public DataImportOpType curImportType
        {
            get
            {
                if(radio_UnitBase.Checked)
                {
                    return DataImportOpType.UnitBaseData;
                }
                else if(radio_UnitDevolopData.Checked)
                {
                    return DataImportOpType.UnitDevelopData;
                }
                else if(radio_WellDevelopData.Checked)
                {
                    return DataImportOpType.WellDevelopData;
                }
                else
                {
                    return DataImportOpType.None;
                }

            }
        }

        //用户设置的字段映射关系
        public ExcelColumnMappingConfig curColumnMappingConfig = new ExcelColumnMappingConfig();
        public UC_ExcelFileSel()
        {
            InitializeComponent();
            this.Title = "请选择导入Excel文件";
        }

        ~UC_ExcelFileSel()
        {
            //Excel_curFile.Close();
        }

        //选择文件
        private void btn_SelFile_Click(object sender, EventArgs e)
        {
            userSelFilePath = PublicMethods.GetFilePath("Excel文件|*.xls;*.xlsx"); 
            if(string.IsNullOrEmpty(userSelFilePath))
            {
                return;
            }
            text_UserSelPath.Text = userSelFilePath;
            //ProgressForm form = new ProgressForm("正在解析文件……");
            //form.StartPosition = FormStartPosition.CenterParent;
            //form.Show(this);
            //form.Refresh();

            ExcelReadClass opExcel = new ExcelReadClass();
            curExcelSet = new DataSet();
            curExcelSet = opExcel.GetExcelDataSet(userSelFilePath);
            //初始化预览
            InitPreView();
            //Excel_curFile.Open(userSelFilePath);//,true,this,null,null);
            //form.Close();
            //form.Dispose();

            group_DataType.Enabled = true;
            btn_FieldConfig.Enabled = true;
            //根据用户选择的类型，自动初始化一种导入类型模式
            InitImportType();
        }

        private void InitPreView()
        {
            int index = 0;
            foreach(DataTable curTable in curExcelSet.Tables)
            {
                if(tab_ExcelPreView.TabPages.Count > index)
                {
                    DataGridView curView = (DataGridView)tab_ExcelPreView.TabPages[index].Controls[0];
                    curView.DataSource = curTable;
                    tab_ExcelPreView.TabPages[index].Text = curTable.TableName;
                    index++;
                    continue;
                }

                TabPage newPage = new TabPage(curTable.TableName);
                DataGridView newView = new DataGridView();
                newView.BackgroundColor = Color.White;
                newView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                newView.DataSource = curTable;
                newView.AllowUserToAddRows = false;
                newView.ReadOnly = true;
                newPage.Controls.Add(newView);
                
                newView.Dock = DockStyle.Fill;
                tab_ExcelPreView.TabPages.Add(newPage);
                index++;
            }

            if(tab_ExcelPreView.TabPages.Count>index)
            {
                for (int i = tab_ExcelPreView.TabPages.Count-1; i >=index; i--)
                {
                    TabPage curPage = tab_ExcelPreView.TabPages[i];
                    curPage.Parent = null;
                    curPage.Dispose();
                }
            }
        }

        //获取模板
        private void btn_GetTempleate_Click(object sender, EventArgs e)
        {
            ExcelTempleateGetForm form = new ExcelTempleateGetForm();
            form.ShowDialog(this);           
            form.Dispose();
        }

        //映射字段配置
        private void btn_FieldConfig_Click(object sender, EventArgs e)
        {
            string UserSelSheetName = GetUserSelSheetName();
            //将当前解析的数据集、当前用户选择的sheet页，及当前操作的类型传过去
            ExcelFiledMappingConfig form = new ExcelFiledMappingConfig(curExcelSet, UserSelSheetName,curImportType);
            if((curImportType == curColumnMappingConfig.curSelImportType) &&(curColumnMappingConfig.ColumnConfig.Rows.Count>0))
            {
                form.curMappingConfig = curColumnMappingConfig;
            }

            form.ShowDialog(this);
            if (form.DialogResult == DialogResult.OK)
            {
                //获取列配置关系
                curColumnMappingConfig = form.curMappingConfig;
                curColumnMappingConfig.curSelImportType = curImportType;
            }
            form.Dispose();
        }

        //获取用户在预览区选择的Sheet页
        private string GetUserSelSheetName()
        {
            /*
            //作的测试，匆删
            //string NAme = Excel_curFile.ActiveDocument.GetType().Name;

            ////Microsoft.Office.Interop.Excel.Workbook wk = (Microsoft.Office.Interop.Excel.Workbook)Excel_curFile.ActiveDocument;

            //Microsoft.Office.Interop.Excel.Workbook curObject = (Microsoft.Office.Interop.Excel.Workbook)Excel_curFile.ActiveDocument;

            //int a = curObject.Worksheets.Count;
            ////string bb = curObject.Worksheets.Application.ActiveSheet.ToString();
            ////string cc = curObject.Worksheets.ToString();

            //Microsoft.Office.Interop.Excel.Worksheet ews = (Microsoft.Office.Interop.Excel.Worksheet)curObject.Worksheets[1];
            //string mm = ews.Name;


            //Microsoft.Office.Interop.Excel.Worksheet ews1 = curObject.ActiveSheet;
            //string SS = ews1.Name;
            //string LL = ews1.Index.ToString();
            */
            string SheetName = "";
            try
            {
                //Microsoft.Office.Interop.Excel.Workbook curObject = (Microsoft.Office.Interop.Excel.Workbook)Excel_curFile.ActiveDocument;
                //Microsoft.Office.Interop.Excel.Worksheet ews1 = curObject.ActiveSheet;
                //SheetName = ews1.Name;

                SheetName = tab_ExcelPreView.SelectedTab.Text;
            }
            catch (Exception E)
            {
                MessageBox.Show(this, E.Message);
            }

            return SheetName;

        }

        private void InitImportType()
        {
            if(curExcelSet.Tables.Count<=0)
            {
                return;
            }
            BaseDataMappingTable opMapping = new BaseDataMappingTable();

            DataImportOpType SS = DataImportOpType.None;
            //获取当前文档对应的导入类型
            DataImportOpType curImportType = opMapping.JugeImportType(curExcelSet.Tables[0], ref SS);

            if(curImportType == DataImportOpType.None)
            {
                //说明没有全匹配，不确定
                curImportType = SS;
            }

            switch(curImportType)
            {
                case DataImportOpType.UnitBaseData:
                    radio_UnitBase.Checked = true;
                    break;
                case DataImportOpType.UnitDevelopData:
                    radio_UnitDevolopData.Checked = true;
                    break;
                case DataImportOpType.WellDevelopData:
                    radio_WellDevelopData.Checked = true;
                    break;
                default:
                    break;
            }

        }

        private void UC_ExcelFileSel_Load(object sender, EventArgs e)
        {
            //Excel_curFile.Menubar = false;
            //Excel_curFile.Titlebar = false;
            //Excel_curFile.Toolbars = false;
        }
    }

    //定义了一个类，用来存储要导入的单元资产数据、单元开发数据、单井开发数据有哪些字段，方便Excel导入映射时直接获取
    public class BaseDataMappingTable
    {
        public DataTable UnitBaseData = new DataTable();
        public DataTable UnitDevelopData = new DataTable();
        public DataTable WellDevelopData = new DataTable();

        public string UnitBaseTableName = "DYDAB01";
        public string UnitDevelopDataTableName = "DYMonthData";
        public string WellDevelopDataTableName = "JHMonthData";

        public BaseDataMappingTable()
        {
            InitColumn();
            InitData();
        }

        private void InitColumn()
        {
            UnitBaseData.TableName = UnitBaseTableName;
            UnitBaseData.Columns.Add("FiledName");
            UnitBaseData.Columns.Add("FiledTitle");
            UnitBaseData.Columns.Add("Unit");
            UnitBaseData.Columns.Add("NotNull");
            UnitBaseData.Columns.Add("Remark");

            UnitDevelopData.TableName = UnitDevelopDataTableName;
            UnitDevelopData.Columns.Add("FiledName");
            UnitDevelopData.Columns.Add("FiledTitle");
            UnitDevelopData.Columns.Add("Unit");
            UnitDevelopData.Columns.Add("NotNull");
            UnitDevelopData.Columns.Add("Remark");

            WellDevelopData.TableName = WellDevelopDataTableName;
            WellDevelopData.Columns.Add("FiledName");
            WellDevelopData.Columns.Add("FiledTitle");
            WellDevelopData.Columns.Add("Unit");
            WellDevelopData.Columns.Add("NotNull");
            WellDevelopData.Columns.Add("Remark");
        }

        private void InitData()
        {
            //单元基本信息对应表
            AddRowInfo(UnitBaseData, "FGSMC", "分公司名称", "", "", "");
            AddRowInfo(UnitBaseData, "CYCMC", "采油厂名称", "", "","1");
            AddRowInfo(UnitBaseData, "YTMC", "油田名称", "", "", "1");
            AddRowInfo(UnitBaseData, "DYDM", "单元代码", "", "", "1");
            AddRowInfo(UnitBaseData, "DYMC", "单元名称", "", "", "1");
            AddRowInfo(UnitBaseData, "HYMJ", "含油面积", "千方公里", "");
            AddRowInfo(UnitBaseData, "HQMJ", "含气面积", "", "");
            AddRowInfo(UnitBaseData, "YYDZCL", "原油地质储量", "万吨", "");
            AddRowInfo(UnitBaseData, "YYKCCL", "原油可采储量", "万吨", "");
            AddRowInfo(UnitBaseData, "YQCLX", "油气藏类型", "", "");
            AddRowInfo(UnitBaseData, "QDLX", "驱动类型", "", "");
            AddRowInfo(UnitBaseData, "QBLX", "圈闭类型", "", "");
            AddRowInfo(UnitBaseData, "KFFS", "开发方式", "", "");
            AddRowInfo(UnitBaseData, "CLLB", "储量类别", "", "");
            AddRowInfo(UnitBaseData, "WZJS", "完钻井数", "", "");
            AddRowInfo(UnitBaseData, "BZ", "备注", "", "");
            AddRowInfo(UnitBaseData, "yymd", "原油密度", "g/cm3", "");
            AddRowInfo(UnitBaseData, "kfzt", "开发状态", "", "");
            //AddRowInfo(UnitBaseData, "DYType", "单元类型", "", "");
            //AddRowInfo(UnitBaseData, "InvolvedEconEval", "是否参与经济评价", "", "");
            //AddRowInfo(UnitBaseData, "MainProduct", "主产品项", "", "");
            //AddRowInfo(UnitBaseData, "projectID", "工程ID", "", "");
            //AddRowInfo(UnitBaseData, "pjnd", "评价年度", "", "");

            //单元开发数据
            AddRowInfo(UnitDevelopData, "DYDM", "单元代码", "", "", "1");
            AddRowInfo(UnitDevelopData, "NY", "年月", "", "", "1");
            AddRowInfo(UnitDevelopData, "YCY", "月产油量", "吨", "", "1");
            AddRowInfo(UnitDevelopData, "YCQ", "月产气量", "方", "", "1");
            AddRowInfo(UnitDevelopData, "YCS", "月产水量", "吨", "");
            AddRowInfo(UnitDevelopData, "YZS", "月注水量", "吨", "");
            AddRowInfo(UnitDevelopData, "LCY", "累产油量", "吨", "");

            AddRowInfo(UnitDevelopData, "LCQ", "累产气量", "", "");
            AddRowInfo(UnitDevelopData, "LCS", "累产水量", "吨", "");
            AddRowInfo(UnitDevelopData, "LZS", "累注水量", "吨", "");
            AddRowInfo(UnitDevelopData, "ZYJS", "总油井数", "", "");
            AddRowInfo(UnitDevelopData, "KYJS", "开油井数", "", "");
            AddRowInfo(UnitDevelopData, "ZSJS", "总水井数", "", "");
            AddRowInfo(UnitDevelopData, "KSJS", "开水井数", "", "");

            //单井开发数据
            AddRowInfo(WellDevelopData, "JH", "井号", "", "", "1");
            AddRowInfo(WellDevelopData, "NY", "年月", "", "", "1");
            //AddRowInfo(WellDevelopData, "CW", "层位", "", "");
            //AddRowInfo(WellDevelopData, "CS", "", "", "");
            //AddRowInfo(WellDevelopData, "YXHD", "", "", "");
            AddRowInfo(WellDevelopData, "DYDM", "单元代码", "", "", "1");
            AddRowInfo(WellDevelopData, "SCTS", "生产天数", "", "");
            //AddRowInfo(WellDevelopData, "CYFS", "", "", "");
            //AddRowInfo(WellDevelopData, "BS", "", "", "");
            //AddRowInfo(WellDevelopData, "BJ", "", "", "");
            //AddRowInfo(WellDevelopData, "BJ1", "", "", "");
            //AddRowInfo(WellDevelopData, "BX", "", "", "");
            AddRowInfo(WellDevelopData, "YCYL", "月产油量", "吨", "", "1");
            AddRowInfo(WellDevelopData, "YCQL", "月产气量", "方", "");
            AddRowInfo(WellDevelopData, "YCSL", "月产水量", "吨", "");
            AddRowInfo(WellDevelopData, "LJCYL", "累产油量", "吨", "");
            AddRowInfo(WellDevelopData, "LJCQL", "累产气量", "万方", "");
            AddRowInfo(WellDevelopData, "LJCSL", "累产水量", "吨", "");
            AddRowInfo(WellDevelopData, "DYM", "动液面", "", "");
            AddRowInfo(WellDevelopData, "MQJB", "目前井别", "", "");
           
        }

        private void AddRowInfo(DataTable curTable,string FiledName,string FileTitle,string Unit,string Remark="",string NotNull="0")
        {
            DataRow newRow = curTable.NewRow();
            newRow["FiledName"] = FiledName;
            newRow["FiledTitle"] = FileTitle;
            newRow["Unit"] = Unit;
            newRow["NotNull"] = NotNull;
            newRow["Remark"] = Remark;
            curTable.Rows.Add(newRow);
        }

        //判断用户选择是什么数据导入，如果没有准确的数据，引用返回一个推荐的
        public DataImportOpType JugeImportType(DataTable JugeDataTable,ref DataImportOpType Advice)
        {
            //判断是否为单元基本数据
            decimal UnitBaseDataSimilarity = 0;
            if (JugeImportType(JugeDataTable,UnitBaseData,ref UnitBaseDataSimilarity))
            {
                return DataImportOpType.UnitBaseData;
            }
            //判断是否为单元开发数据
            decimal UnitDevDataSimilarity = 0;
            if (JugeImportType(JugeDataTable, UnitDevelopData,ref UnitDevDataSimilarity))
            {
                return DataImportOpType.UnitDevelopData;
            }
            //判断是否为单井开发数据
            decimal WellDevDataSimilarity = 0;
            if (JugeImportType(JugeDataTable, WellDevelopData,ref WellDevDataSimilarity))
            {
                return DataImportOpType.WellDevelopData;
            }

            //如果不能完全匹配，就计算一下相似度，引用返回一个比较接近的
            if (UnitBaseDataSimilarity > UnitDevDataSimilarity)
            {
                if (UnitBaseDataSimilarity > WellDevDataSimilarity)
                {
                    Advice = DataImportOpType.UnitBaseData;
                }
                else
                {
                    Advice = DataImportOpType.WellDevelopData;
                }
            }
            else
            {
                if (UnitDevDataSimilarity > WellDevDataSimilarity)
                {
                    Advice = DataImportOpType.UnitDevelopData;
                }
                else
                {
                    Advice = DataImportOpType.WellDevelopData;
                }
            }


            return DataImportOpType.None;
        }

        //将单元基本信息、单元开发数据、单井开发数据的字段明细进来比对，看用户是不是选择了默认的模板
        private bool JugeImportType(DataTable JugeDataTable, DataTable TypeColumnConfigTable, ref decimal Similarity)
        {
            DataTable curDataTable = JugeDataTable;
            //如果用户做了映射配置，取用户选择的Sheet页，否则选第一个Sheet页
            //if (string.IsNullOrEmpty(curColumnConfig.SelSheetName))
            //{
            //    curDataTable = curExcelFileData.Tables[curColumnConfig.SelSheetName];
            //}
            //else
            //{
            //    curDataTable = curExcelFileData.Tables[0];
            //}

            string FiledTitle = "";
            string TempValue = "";
            int FindColumnCount = 0;
            foreach (DataRow curRow in TypeColumnConfigTable.Rows)
            {

                //取出当前项所有的字段名称，在当前数据表里比对，看是否有，这里比对的是中文名称，不是实际字段名
                FiledTitle = curRow["FiledTitle"].ToString().Trim();
                //将当前的字段名称在数据集的第一行中遍历查找
                foreach (DataColumn curColumn in curDataTable.Columns)
                {
                    TempValue = curDataTable.Rows[0][curColumn.ColumnName].ToString().Trim();
                    if (FiledTitle == TempValue)
                    {
                        FindColumnCount++;
                    }
                }

            }

            //大于等于2/3
            if (FindColumnCount >= TypeColumnConfigTable.Rows.Count)
            {
                //找着的与传过来的完全匹配返回
                return true;
            }
            //获取相似度
            Similarity = (decimal)(FindColumnCount * 1.0 / TypeColumnConfigTable.Rows.Count);

            return false;
        }

        //获取指定类别字段的实际对应字段名称
        public string GetDBFieldName(DataImportOpType curImportType,string FiledTitle)
        {
            DataTable QueryTable = null;
            switch(curImportType)
            {
                case DataImportOpType.UnitBaseData:
                    QueryTable = UnitBaseData;
                    break;
                case DataImportOpType.UnitDevelopData:
                    QueryTable = UnitDevelopData;
                    break;
                case DataImportOpType.WellDevelopData:
                    QueryTable = WellDevelopData;
                    break;
                default:
                    break;

            }

            string ConditionStr = "FiledTitle='"+ FiledTitle+  "'";
            DataRow[] Rows = QueryTable.Select(ConditionStr);
            if(Rows.Length == 0)
            {
                return "";
            }

            return Rows[0]["FiledName"].ToString();
        }
    }
}

