using Huiting.Common;
using Huiting.Components;
using Huiting.DataEditor.Enum;
using Huiting.DataEditor.ExcelHelper;
using Huiting.DataEditor.Models;
using Huiting.DBAccess.Attributes;
using Huiting.DBAccess.Entity.Dtos;
using Huiting.ExcelOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Huiting.DataEditor.Controls
{
    public partial class UC_ExcelFileSel : UserControlByInheritScale
    {
        string userSelFilePath = "";

        /// <summary>
        /// 映射关系
        /// </summary>
        private Dictionary<TabPage, Dictionary<string, string>> dictTabPageMapping = new Dictionary<TabPage, Dictionary<string, string>>();

        /// <summary>
        /// 用户选择的Excel文件转换成了数据集
        /// </summary>
        private DataSet curExcelSet = new DataSet();

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
        }

        //选择文件
        private void btn_SelFile_Click(object sender, EventArgs e)
        {
            userSelFilePath = PublicMethods.GetFilePath("Excel文件|*.xls;*.xlsx"); 
            if(string.IsNullOrEmpty(userSelFilePath))
                return;

            text_UserSelPath.Text = userSelFilePath;

            tsProgressBar1.Visible = true;

            BackgroundWorker bgwLoadExcel = new BackgroundWorker();
            bgwLoadExcel.WorkerReportsProgress = true;
            bgwLoadExcel.WorkerSupportsCancellation = true;
            bgwLoadExcel.DoWork += BgwLoadExcel_DoWork;
            bgwLoadExcel.ProgressChanged += BgwLoadExcel_ProgressChanged;
            bgwLoadExcel.RunWorkerCompleted += BgwLoadExcel_RunWorkerCompleted;
            bgwLoadExcel.RunWorkerAsync();
        }

        private void BgwLoadExcel_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgwLoadExcel = sender as BackgroundWorker;
            Action<int> reportProcessValue = delegate(int processValue)
            {
                bgwLoadExcel.ReportProgress(processValue, null);
            };
            ExcelReadClass opExcel = new ExcelReadClass();
            curExcelSet = new DataSet();
            curExcelSet = opExcel.GetExcelDataSet(userSelFilePath, reportProcessValue);
        }

        private void BgwLoadExcel_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.tsProgressBar1.Value = e.ProgressPercentage;
        }

        private void BgwLoadExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            tsProgressBar1.Visible = true;

            if (e.Cancelled)
                return;

            //初始化预览
            InitPreView();

            group_DataType.Enabled = true;
            btn_FieldConfig.Enabled = true;
            //根据用户选择的类型，自动初始化一种导入类型模式
            InitImportType();
        }

        private void InitPreView()
        {
            this.tab_ExcelPreView.SelectedIndexChanged -= Tab_ExcelPreView_SelectedIndexChanged;


            if (dictTabPageMapping == null)
                dictTabPageMapping = new Dictionary<TabPage, Dictionary<string, string>>();
            else
                dictTabPageMapping.Clear();

            //删除多余的TabPage
            for (int i = tab_ExcelPreView.TabPages.Count - 1; i >= curExcelSet.Tables.Count; i--)
            {
                TabPage curPage = tab_ExcelPreView.TabPages[i];
                curPage.Parent = null;
                curPage.Dispose();
            }
            //更新或添加TabPage
            for (int i = 0; i < curExcelSet.Tables.Count; i++)
            {
                DataTable curTable = curExcelSet.Tables[i];
                TabPage curPage = null;
                DataGridView curView = null;
                if (i < tab_ExcelPreView.TabPages.Count)
                {
                    curPage = tab_ExcelPreView.TabPages[i];
                    curView = (DataGridView)curPage.Controls[0];
                }
                else
                {
                    curPage = new TabPage();
                    DataGridView newView = new DataGridView();
                    newView.BackgroundColor = Color.White;
                    newView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    newView.DataSource = curTable;
                    newView.AllowUserToAddRows = false;
                    newView.ReadOnly = true;
                    curPage.Controls.Add(newView);

                    newView.Dock = DockStyle.Fill;
                    tab_ExcelPreView.TabPages.Add(curPage);
                }

                curView.DataSource = curTable;
                curPage.Text = curTable.TableName;

                var dictFieldMapping = GetFieldMapping(curTable, curPage);
                dictTabPageMapping.Add(curPage, dictFieldMapping);

                // 列检查，不匹配值为浅黄色背景
                CheckDGVColumn(curView, dictFieldMapping);
                //行检查，不合格的标红色前景色
                CheckDGVRows(curView, dictFieldMapping, curPage.Tag as Type);
            }

            if (curExcelSet.Tables.Count == 1)
                InitRadioGroup(tab_ExcelPreView.SelectedTab);
            this.tab_ExcelPreView.SelectedIndexChanged += Tab_ExcelPreView_SelectedIndexChanged;
        }

        private void Tab_ExcelPreView_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitRadioGroup(tab_ExcelPreView.SelectedTab);
        }

        private void InitRadioGroup(TabPage tabPage)
        {
            if (tabPage.Tag as Type == typeof(UnitBasicDataDto))
                radio_UnitBase.Checked = true;
            else if (tabPage.Tag as Type == typeof(UnitDevelopDataDto))
                radio_UnitDevolopData.Checked = true;
            else //if (tab_ExcelPreView.Tag == typeof(WellDevelopDataDto))
                radio_WellDevelopData.Checked = true;
        }

        /// <summary>
        /// 获取映射关系
        /// </summary>
        /// <param name="curTable"></param>
        /// <param name="tabPage"></param>
        /// <returns>AA:JH</returns>
        private Dictionary<string,string> GetFieldMapping(DataTable curTable, TabPage tabPage)
        {
            var dict1Mapping1 = CheckDataColumn(curTable, typeof(UnitBasicDataDto));
            if (curTable.Columns.Count == dict1Mapping1.Count)
            {
                tabPage.Tag = typeof(UnitBasicDataDto);
                return dict1Mapping1;
            }
            var dictMapping2 = CheckDataColumn(curTable, typeof(UnitDevelopDataDto));
            if (curTable.Columns.Count == dict1Mapping1.Count)
            {
                tabPage.Tag = typeof(UnitDevelopDataDto);
                return dictMapping2;
            }

            var dictMapping3 = CheckDataColumn(curTable, typeof(WellDevelopDataDto));
            if (curTable.Columns.Count == dict1Mapping1.Count)
            {
                tabPage.Tag = typeof(WellDevelopDataDto);
                return dictMapping3;
            }

            if (dict1Mapping1.Count > dictMapping2.Count)
            {
                if (dict1Mapping1.Count > dictMapping3.Count)
                {
                    tabPage.Tag = typeof(UnitBasicDataDto);
                    return dict1Mapping1;
                }
                else
                {
                    tabPage.Tag = typeof(WellDevelopDataDto);
                    return dictMapping3;
                }
            }
            else
            {
                if (dictMapping2.Count > dictMapping3.Count)
                {
                    tabPage.Tag = typeof(UnitDevelopDataDto);
                    return dict1Mapping1;
                }
                else
                {
                    tabPage.Tag = typeof(WellDevelopDataDto);
                    return dictMapping3;
                }
            }
        }

        /// <summary>
        /// 获取属性的字段特性映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeDto"></param>
        /// <returns></returns>
        private static Dictionary<string, DataFieldAttribute> GetPropertyDataFieldMapping<T>(T typeDto) where T : Type
        {
            Dictionary<string, DataFieldAttribute> dict = new Dictionary<string, DataFieldAttribute>();
            var piAry = typeDto.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var piItem in piAry)
            {
                var attrAry = piItem.GetCustomAttributes(typeof(DataFieldAttribute), false);
                if (attrAry.Length <= 0)
                    continue;
                var dataFieldAttribute = attrAry[0] as DataFieldAttribute;
                dict.Add(piItem.Name, dataFieldAttribute);
            }

            return dict;
        }

        /// <summary>
        /// 行检查，不匹配值为红色字体
        /// </summary>
        /// <param name="dto"></param>
        private void CheckDGVRows<T>(DataGridView dgView, Dictionary<string, string> dictMaping, T typeDto) where T : Type
        {
            Dictionary<string, DataFieldAttribute> dictFieldAttribute = GetPropertyDataFieldMapping(typeDto);
            var dataTable = dgView.DataSource as DataTable;

            for (int i = 2; i < dgView.Rows.Count; i++)
            {
                DataGridViewRow dgr = dgView.Rows[i];
                foreach (DataGridViewColumn dgvColumn in dgView.Columns)
                {
                    if (dictMaping.ContainsKey(dgvColumn.Name) == false)
                        continue;

                    string propertyName = dictMaping[dgvColumn.Name].ToString();
                    var dataFieldAttribute = dictFieldAttribute[propertyName];
                    if (dataFieldAttribute == null)
                        continue;
                    string cellValue = dgr.Cells[dgvColumn.Name].Value.ToString();
                    Type columnType = dataTable.Columns[dgvColumn.Name].DataType;
                    if (dataFieldAttribute.CheckDataValueValid(cellValue, columnType) == false)
                    {
                        dgr.DefaultCellStyle.BackColor = Color.LightYellow;
                        dgr.Cells[dgvColumn.Name].Style.ForeColor = Color.Red;
                    }

                }
            }
        }

        /// <summary>
        /// 列检查，不匹配值为浅黄色背景
        /// </summary>
        /// <param name="newView"></param>
        /// <param name="dto"></param>
        private void CheckDGVColumn(DataGridView dgView, Dictionary<string, string> dictMaping)
        {
            var dgr = dgView.Rows[0];
            foreach (DataGridViewColumn dgvColumn in dgView.Columns)
            {
                if (dictMaping.ContainsKey(dgvColumn.Name) == false)
                    dgvColumn.DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }

        /// <summary>
        /// 列检查，不匹配值为浅黄色背景
        /// </summary>
        /// <param name="newView"></param>
        /// <param name="dto"></param>
        private Dictionary<string, string> CheckDataColumn<T>(DataTable dataTable, T typeDto) where T : Type
        {
            Dictionary<string, string> dictMaping = new Dictionary<string, string>();
            //没有数据可以检查
            if (dataTable.Rows.Count <= 2)
                return dictMaping;

            Dictionary<string, string> dict = GetFieldDisplayAndPropertyMapping(typeDto);

            var curRow = dataTable.Rows[0];
            foreach (DataColumn dtColumn in dataTable.Columns)
            {
                string columName = curRow[dtColumn.ColumnName].ToString().Trim().ToUpper();
                if (dict.ContainsKey(columName))
                    dictMaping.Add(dtColumn.ColumnName, dict[columName]);
            }

            return dictMaping;
        }

        /// <summary>
        /// 获取字段显示值与属性的映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeDto"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetFieldDisplayAndPropertyMapping<T>(T typeDto) where T : Type
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var piAry = typeDto.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var piItem in piAry)
            {
                var attrAry = piItem.GetCustomAttributes(typeof(DisplayFieldAttribute), false);
                if (attrAry.Length <= 0)
                    continue;
                var dataFieldAttribute = attrAry[0] as DisplayFieldAttribute;
                //没有标注
                if (string.IsNullOrWhiteSpace(dataFieldAttribute.DisplayText))
                    continue;
                dict.Add(dataFieldAttribute.DisplayText.ToUpper(), piItem.Name);
            }

            return dict;
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
            string SheetName = "";
            try
            {
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

        public void SaveDataTable()
        {
            foreach (var tabPage in tab_ExcelPreView.TabPages)
            {

            }
        }

    }
}

