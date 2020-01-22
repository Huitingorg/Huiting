using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;

namespace ReserveCommon
{
    public partial class FrmSplitText : FrmChildWithOutMinAndMax
    {
        public FrmSplitText()
        {
            InitializeComponent();
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitCheckedListBox(checkedListBox1);
        }

        private void InitCheckedListBox(CheckedListBox checkedListBox1)
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.Add("单元名称", true);
            checkedListBox1.Items.Add("单元代码", true);
            foreach (KeyValuePair<SortType, string> item in EnumDictionary<SortType>.Instance.Dictionary)
            {
                CheckedListBoxItem clbi = new CheckedListBoxItem();
                clbi.Text = item.Value;
                clbi.Type = item.Key;
                checkedListBox1.Items.Add(clbi, false);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            lblContent.Text = GetExampleString(e.Index);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                lblWarn.Visible = true;
                return;
            }

            lblWarn.Visible = false;
            lblContent.Text = GetExampleString(-1);
        }

        //public static string GetExampleString()
        //{

        //}

        private string GetExampleString(int curIndex)
        {
            string result=null;
            List<SortInfo> lstSortInfo= GetLstSortInfo(this.checkedListBox1,curIndex);
            foreach (SortInfo item in lstSortInfo)
            {
                if (!string.IsNullOrEmpty(result))
                    result += textBox1.Text.Trim() ;
                result += EnumDictionary<SortType>.Instance.GetDescription(item.Type);
            }

            return result;
        }


        //因为checkedListBox1仅有选中前发生事件（ItemCheck）没有选中后发生事件，所以要针对当前选中的Item进行反向处理
        private List<SortInfo> GetLstSortInfo(CheckedListBox checkedListBox1, int curIndex)
        {
            List<SortInfo> lstSortCategory = new List<SortInfo>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                CheckState cs = checkedListBox1.GetItemCheckState(i);
                //如果是
                if (i == curIndex)
                    cs = cs == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;

                if (cs != CheckState.Checked)
                    continue;
                CheckedListBoxItem clbi = checkedListBox1.Items[i] as CheckedListBoxItem;
                if (clbi == null)
                    continue;
                SortInfo sort = new SortInfo();
                sort.Type = clbi.Type;
                sort.Ascending = true;

                lstSortCategory.Add(sort);
            }

            return lstSortCategory;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }


    }
}
