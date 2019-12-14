
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor.ExcelHelper
{
    public partial class ExcelFiledMappingEditForm : Form
    {
        DataTable curTable = null;
        int HeadRowsCount = 1;
        DataRow curRow = null;

        public ExcelFiledMappingEditForm(DataRow curRow,DataTable curTable, int HeadRowsCount)
        {
            InitializeComponent();
            this.curTable = curTable;
            this.curRow = curRow;
            this.HeadRowsCount = HeadRowsCount;
            InitColumnTree();
            FillValue();
        }

        private void InitColumnTree()
        {
            tree_ExcelColumn.BeginUpdate();
            TreeNode RootNode = new TreeNode();
            RootNode.ImageIndex = 0;
            RootNode.SelectedImageIndex = 0;
            RootNode.Text = "Excel文件字段";

            string TempValue = "";
            foreach(DataColumn curColumn in curTable.Columns)
            {
                TempValue = GetColumnName(curColumn.ColumnName);

                TreeNode newNode = new TreeNode();
                newNode.Text = TempValue;
                newNode.Tag = curColumn.ColumnName;
                newNode.ImageIndex = 1;
                newNode.SelectedImageIndex = 2;
                RootNode.Nodes.Add(newNode);
            }

            tree_ExcelColumn.Nodes.Add(RootNode);
            tree_ExcelColumn.ExpandAll();
            tree_ExcelColumn.EndUpdate();
        }

        private string GetColumnName(string FieldName)
        {
            string ColumnName = "";
            string TempValue = "";
            for (int i = 0; i < HeadRowsCount; i++)
            {
                TempValue = curTable.Rows[i][FieldName].ToString();
                if (!string.IsNullOrEmpty(TempValue))
                {
                    if (!string.IsNullOrEmpty(ColumnName))
                    {
                        ColumnName += "-";
                    }
                    ColumnName += TempValue;
                }
            }

            if (string.IsNullOrEmpty(ColumnName))
            {
                ColumnName = FieldName;
            }
            return ColumnName;
        }

        private void FillValue()
        {
            string RealMappingColumn = curRow["RealMappingColumn"].ToString();
            string DBUnitName = curRow["Unit"].ToString();
            string FileUnitName = curRow["MappingColumnUnit"].ToString();

            if(string.IsNullOrEmpty(FileUnitName))
            {
                FileUnitName = DBUnitName;
            }

            foreach(TreeNode curNode in tree_ExcelColumn.Nodes[0].Nodes)
            {
                if(curNode.Tag.ToString() == RealMappingColumn)
                {
                    tree_ExcelColumn.SelectedNode = curNode;
                    break;
                }
            }

            if(string.IsNullOrEmpty(DBUnitName))
            {
                UC_UnitSel.Visible = false;
                return;
            }

            switch(DBUnitName)
            {
                case "吨":
                case "万吨":
                    UC_UnitSel.UnitStrList = "吨|万吨";
                    UC_UnitSel.SelUnit = FileUnitName;
                    break;
                case "方":
                case "千方":
                case "万方":
                    UC_UnitSel.UnitStrList = "方|千方|万方";
                    UC_UnitSel.SelUnit = FileUnitName;
                    break;
                default:
                    UC_UnitSel.Visible = false;
                    break;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if(tree_ExcelColumn.SelectedNode == null)
            {
                MessageBox.Show(this, "请选择对应的Excel列");
                return;
            }

            if(tree_ExcelColumn.SelectedNode.Parent == null)
            {
                MessageBox.Show(this, "请选择对应的Excel列");
                return;
            }

            curRow["RealMappingColumn"] = tree_ExcelColumn.SelectedNode.Tag.ToString();
            curRow["FiledTitle"] = tree_ExcelColumn.SelectedNode.Text;

            if(UC_UnitSel.Visible)
            {
                curRow["MappingColumnUnit"] = UC_UnitSel.SelUnit;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_CancelMapping_Click(object sender, EventArgs e)
        {
            curRow["RealMappingColumn"] = DBNull.Value;
            curRow["FiledTitle"] = DBNull.Value;


            curRow["MappingColumnUnit"] = DBNull.Value;
            this.DialogResult = DialogResult.OK;
        }
    }
}
