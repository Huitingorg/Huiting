using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReserveCommon;
using Huiting.Common;

namespace ReserveComponents
{
    public partial class UctSort : UserControl
    {
        public UctSort()
        {
            InitializeComponent();
        }

        
        private bool Exist<T>(BasicQueue<T> lstSortInfo, SortType type) where T:GroupInfo
        {
            foreach (T item in lstSortInfo)
            {
                if (item.Type == type)
                    return true;
            }
            return false;
        }

        public void InitCheckedListBox<T>(BasicQueue<T> lstSortInfo, bool onlyGroup) where T : GroupInfo
        {
            checkedListBox1.Items.Clear();
            foreach (T item in lstSortInfo)
            {
                checkedListBox1.Items.Add(item, true);
            }

            foreach (KeyValuePair<SortType, SortAttribute> item in EnumAttrDict<SortType, SortAttribute>.Instance.Dictionary)
            {
                if (Exist(lstSortInfo, item.Key))
                    continue;

                //如果只要分组，且当前属性不是分组，则返回
                if (onlyGroup && item.Value.OnlyGroup == false)
                    continue;
                SortInfo clbi = new SortInfo();
                clbi.Text = item.Value.Description;
                clbi.Type = item.Key;
                checkedListBox1.Items.Add(clbi, false);
            }

            checkedListBox1.Focus();
            if (checkedListBox1.SelectedItem == null)
                btnUp.Enabled = btnDown.Enabled = btnShow.Enabled = btnHide.Enabled = false;
        }

        //获取信息
        public K GetLstSortInfo<T, K>()
            where T : GroupInfo
            where K : BasicQueue<T>,new()
        {
            K lstSortInfo = new K();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == false)
                    continue;
                T clbi = checkedListBox1.Items[i] as T;
                lstSortInfo.Add(clbi);
            }

            return lstSortInfo;
        }

        //初始化按钮可用性
        private void InitButtonEnable()
        {
            if (checkedListBox1.SelectedIndex < 0 || checkedListBox1.SelectedIndex > checkedListBox1.Items.Count - 1)
            {
                btnUp.Enabled = btnDown.Enabled = btnHide.Enabled = btnShow.Enabled = true;
                return;
            }

            if (checkedListBox1.SelectedIndex <= 0)
                btnUp.Enabled = false;
            else
                btnUp.Enabled = true;

            if (checkedListBox1.SelectedIndex >= checkedListBox1.Items.Count - 1)
                btnDown.Enabled = false;
            else
                btnDown.Enabled = true;

            bool bolChecked = checkedListBox1.GetItemChecked(checkedListBox1.SelectedIndex);
            if (bolChecked)
            {
                btnShow.Enabled = false;
                btnHide.Enabled = true;
            }
            else
            {
                btnShow.Enabled = true;
                btnHide.Enabled = false;
            }
        }

        private void SwapItem(int index1,int index2)
        {
            bool checked1 = checkedListBox1.GetItemChecked(index1);
            bool checked2 = checkedListBox1.GetItemChecked(index2);

            object obj1Copy = PublicMethods.DeepClone(checkedListBox1.Items[index1]);
            checkedListBox1.Items[index1] = checkedListBox1.Items[index2];
            checkedListBox1.Items[index2] = obj1Copy;

            checkedListBox1.SetItemChecked(index1, checked2);
            checkedListBox1.SetItemChecked(index2, checked1);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex <= 0)
                return;

            int index1 = checkedListBox1.SelectedIndex;
            int index2 = index1 - 1;
            SwapItem(index1,index2);

            if (checkedListBox1.SelectedIndex > 0)
                checkedListBox1.SelectedIndex = checkedListBox1.SelectedIndex - 1;
            InitButtonEnable();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.SelectedIndex >=checkedListBox1.Items.Count-1)
                return;

            int index1 = checkedListBox1.SelectedIndex;
            int index2 = index1 + 1;
            SwapItem(index1, index2);

            if (checkedListBox1.SelectedIndex < checkedListBox1.Items.Count - 1)
                checkedListBox1.SelectedIndex = checkedListBox1.SelectedIndex + 1;
            InitButtonEnable();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex,true);
            btnShow.Enabled = false;
            btnHide.Enabled = true;
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            checkedListBox1.SetItemChecked(checkedListBox1.SelectedIndex, false);
            btnShow.Enabled = true;
            btnHide.Enabled = false;
        }

        public event EventHandler SelectedIndexChanged;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitButtonEnable();
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }

        public event ItemCheckEventHandler ItemChecked;
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ItemChecked != null)
            {
                SortInfoQueue lstSortInfo = GetSortInfoQueue(this.checkedListBox1, e.Index);
                ItemChecked(lstSortInfo,e);
            }
        }

        //因为checkedListBox1仅有选中前发生事件（ItemCheck）没有选中后发生事件，所以要针对当前选中的Item进行反向处理
        private SortInfoQueue GetSortInfoQueue(CheckedListBox checkedListBox1, int curIndex)
        {
            SortInfoQueue lstSortCategory = new SortInfoQueue();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                bool bolChecked = checkedListBox1.GetItemChecked(i);
                //如果是
                if (i == curIndex)
                    bolChecked = !bolChecked;

                //如果没有选中
                if (bolChecked==false)
                    continue;
                lstSortCategory.Add(checkedListBox1.Items[i] as SortInfo);
            }

            return lstSortCategory;
        }
    }
}