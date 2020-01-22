using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Huiting.Common;
using Huiting.Components;
using ReserveCommon;

namespace ReserveComponents
{
    public partial class FrmAssetsSort : FrmChildWithOutMinAndMax
    {
        SortInfo selectedSI;
        SortInfoQueue sortInfoQueue;
        public SortInfoQueue SortInfoQueue
        {
            get { return sortInfoQueue; }
        }

        public FrmAssetsSort(SortInfoQueue sortInfoQueue)
        {
            InitializeComponent();
            this.sortInfoQueue = sortInfoQueue;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.uctSort1.InitCheckedListBox(sortInfoQueue, false);
            this.uctSort1.SelectedIndexChanged -= uctSort1_SelectedIndexChanged;
            this.uctSort1.SelectedIndexChanged += uctSort1_SelectedIndexChanged;
            this.uctSort1.ItemChecked -= uctSort1_ItemChecked;
            this.uctSort1.ItemChecked += uctSort1_ItemChecked;
            InitCombox();
        }

        void uctSort1_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            SortInfoQueue siQueue = sender as SortInfoQueue;
            if (siQueue != null)
                lblContent.Text = GetExampleString(siQueue);
        }

        private void InitCombox()
        {
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                string str = comboBox1.Items[i] as string;
                if (str == sortInfoQueue.Separator)
                {
                    this.comboBox1.SelectedIndex = i;
                    return;
                }
            }
        }

        void uctSort1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckedListBox clb = sender as CheckedListBox;
            if (clb == null)
                return;

            if (clb.SelectedIndex < 0)
                return;

            selectedSI = clb.Items[clb.SelectedIndex] as SortInfo;
            bdNumBox1.Text = selectedSI.Width.ToString();
        }

        private string GetExampleString()
        {
            sortInfoQueue = uctSort1.GetLstSortInfo<SortInfo, SortInfoQueue>();
            return GetExampleString(sortInfoQueue);
        }

        private string GetExampleString(SortInfoQueue sortInfoQueue)
        {
            string result = null;
            foreach (SortInfo item in sortInfoQueue)
            {
                if (!string.IsNullOrEmpty(result))
                    result += " " + comboBox1.Text + " ";
                result += EnumAttrDict<SortType, SortAttribute>.Instance.GetAttribute(item.Type).Description;
            }

            return result;
        }

        //因为checkedListBox1仅有选中前发生事件（ItemCheck）没有选中后发生事件，所以要针对当前选中的Item进行反向处理
        private List<SortType> GetLstSortInfo(CheckedListBox checkedListBox1, int curIndex)
        {
            List<SortType> lstSortCategory = new List<SortType>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                CheckState cs = checkedListBox1.GetItemCheckState(i);
                //如果是
                if (i == curIndex)
                    cs = cs == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked;

                if (cs != CheckState.Checked)
                    continue;
                SortInfo clbi = checkedListBox1.Items[i] as SortInfo;
                if (clbi == null)
                    continue;

                lstSortCategory.Add(clbi.Type);
            }

            return lstSortCategory;
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            sortInfoQueue = uctSort1.GetLstSortInfo<SortInfo, SortInfoQueue>();
            if (sortInfoQueue.Count <= 0)
            {
                PublicMethods.WarnMessageBox(this, "当前选择显示内容不能为空！");
                return;
            }
            sortInfoQueue.Separator = comboBox1.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblContent.Text = GetExampleString();
        }

        private void bdNumBox1_TextChanged(object sender, EventArgs e)
        {
            if (selectedSI != null)
                selectedSI.Width = (int)bdNumBox1.Value;
        }
    }
}
