using DevExpress.XtraEditors;
using Huiting.DataEditor.Controls;
using Huiting.DataEditor.Enum;
using Huiting.DataEditor.Models;
using Huiting.DevComponents;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Huiting.DataEditor.ExcelHelper
{
    public partial class ExcelFiledMappingConfig : DevXtraForm
    {
        DataSet curSet = null;
        string UserSelSheetName = "";
        BaseDataMappingTable opMap = null;
        DataImportOpType curImportType = DataImportOpType.None;
        DataTable curFiledTable = new DataTable();

        //Excel 配置对象
        public ExcelColumnMappingConfig curMappingConfig
        {
            get
            {
                return new ExcelColumnMappingConfig(comb_Sheets.Text,(int)num_ColumnRowsCount.Value,curFiledTable);
            }
            set
            {
                comb_Sheets.Text = value.SelSheetName;
                curFiledTable = value.ColumnConfig;
                num_ColumnRowsCount.Value = value.ColumnRows;
            }
        }

        public ExcelFiledMappingConfig(DataSet curSet, string UserSelSheetName, DataImportOpType curImportType)
        {
            InitializeComponent();
            this.curSet = curSet;
            InitSheets();
            this.UserSelSheetName = UserSelSheetName;
            opMap = new BaseDataMappingTable();
            this.curImportType = curImportType;
        }

        //初始化Sheet页
        private void InitSheets()
        {
            comb_Sheets.Items.Clear();
            foreach (DataTable curTable in curSet.Tables)
            {
                comb_Sheets.Items.Add(curTable.TableName);
            }

            comb_Sheets.SelectedText = UserSelSheetName;
        }

        //初始化ListView列表
        private void InitListViewList()
        {
            switch (curImportType)
            {
                case DataImportOpType.UnitBaseData:
                    curFiledTable = opMap.UnitBaseData;
                    break;
                case DataImportOpType.UnitDevelopData:
                    curFiledTable = opMap.UnitDevelopData;
                    break;
                case DataImportOpType.WellDevelopData:
                    curFiledTable = opMap.WellDevelopData;
                    break;
                default:
                    break;
            }
            //增加两个字段，用来存储映射信息
            curFiledTable.Columns.Add("MappingColumnName");//映射中文名
            curFiledTable.Columns.Add("MappingColumnUnit");//映射单位
            curFiledTable.Columns.Add("RealMappingColumn");//实际对应数据集中的映射字段
            FillListView();
        }

        private void FillListView()
        {
            listView_FieldList.BeginUpdate();
            listView_FieldList.Items.Clear();
            int Index = 0;
            foreach (DataRow curRow in curFiledTable.Rows)
            {
                Index++;
                ListViewItem newItem = new ListViewItem();
                newItem.Text = Index.ToString();
                //newItem.SubItems.Add(curRow["FiledName"].ToString());
                newItem.SubItems.Add(curRow["FiledTitle"].ToString());
                newItem.SubItems.Add(curRow["MappingColumnName"].ToString());
                newItem.SubItems.Add(curRow["MappingColumnUnit"].ToString());
                newItem.ImageIndex = 0;
                newItem.Tag = curRow;
                if(curRow["NotNull"].ToString() == "1")
                {
                    newItem.ForeColor = Color.Red;
                }


                listView_FieldList.Items.Add(newItem);
            }

            listView_FieldList.EndUpdate();
        }

        private void ExcelFiledMappingConfig_Shown(object sender, EventArgs e)
        {
            if(curFiledTable.Columns.Count == 0)
            {
                //新调用，未配置
                InitSheets();
                InitListViewList();

            }
            else
            {
                //用户已经传过来配置信息
                FillListView();
            }

        }

        private void listView_FieldList_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listView_FieldList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void RunFileSel()
        {
            if (listView_FieldList.SelectedItems.Count == 0)
                return;
            DataRow curRow = (DataRow)listView_FieldList.SelectedItems[0].Tag;
            ExcelFiledMappingEditForm form = new ExcelFiledMappingEditForm(curRow, curSet.Tables[comb_Sheets.Text], (int)(num_ColumnRowsCount.Value));
            form.ShowDialog(this);
            if(form.DialogResult == DialogResult.OK)
            {
                listView_FieldList.SelectedItems[0].SubItems[2].Text = curRow["FiledTitle"].ToString();
                listView_FieldList.SelectedItems[0].SubItems[3].Text = curRow["MappingColumnUnit"].ToString();
            }
            form.Dispose();
        }

        private void listView_FieldList_Click(object sender, EventArgs e)
        {
            RunFileSel();

        }

        private void btn_AutoPP_Click(object sender, EventArgs e)
        {
            string TempValue = "";
            string ColumnTitle = "";

            //遍历所有需要对应的字段
            foreach(DataRow curRow in curFiledTable.Rows)
            {
                ColumnTitle = curRow["FiledTitle"].ToString().ToUpper().Trim();

                foreach(DataColumn curColumn in curSet.Tables[comb_Sheets.Text].Columns)
                {
                    TempValue = curSet.Tables[comb_Sheets.Text].Rows[0][curColumn.ColumnName].ToString().ToUpper().Trim();
                    if(TempValue == ColumnTitle)
                    {

                        curRow["RealMappingColumn"] = curColumn.ColumnName;
                        curRow["MappingColumnName"] = TempValue;
                    }
                }
            }

            FillListView();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }


}
