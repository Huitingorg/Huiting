using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;

namespace ReserveCommon
{
    public partial class UctLevel : UserControl
    {
        public UctLevel()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //InitListViewItem(this.listView1);
            InitCheckedListBox(this.checkedListBox1);
        }

        private void InitListViewItem(ListView lv)
        {
            lv.Items.Clear();
            foreach (KeyValuePair<SortType, string> item in EnumDictionary<SortType>.Instance.Dictionary)
            {
                ListViewItem lvi = new ListViewItem(item.Value);
                lvi.SubItems.Add("升序");
                lvi.Tag = item.Key;
                lv.Items.Add(lvi);
            }
        }

        private void InitCheckedListBox(CheckedListBox checkedListBox1)
        {
            checkedListBox1.Items.Clear();
            foreach (KeyValuePair<SortType, string> item in EnumDictionary<SortType>.Instance.Dictionary)
            {
                CheckedListBoxItem clbi = new CheckedListBoxItem();
                clbi.Text = item.Value;
                clbi.Type = item.Key;
                checkedListBox1.Items.Add(clbi, false);
            }
        }

        public List<SortInfo> GetLstSortInfo()
        {
            return GetLstSortInfo(this.checkedListBox1);
        }

        private List<SortInfo> GetLstSortInfo(ListView lv)
        {
            List<SortInfo> lstSortCategory = new List<SortInfo>();
            foreach (ListViewItem lvi in lv.Items)
            {
                if (lvi.Tag == null)
                    continue;

                if (lvi.Checked == false)
                    continue;

                SortType groupType = (SortType)Enum.Parse(typeof(SortType), lvi.Tag.ToString());
                SortInfo sort = new SortInfo();
                sort.Type = groupType;
                sort.Ascending = true;

                lstSortCategory.Add(sort);
            }

            return lstSortCategory;
        }

        private List<SortInfo> GetLstSortInfo(CheckedListBox checkedListBox1)
        {
            List<SortInfo> lstSortCategory = new List<SortInfo>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == false)
                    continue;
                CheckedListBoxItem clbi = checkedListBox1.Items[i] as CheckedListBoxItem;
                SortInfo sort = new SortInfo();
                sort.Type = clbi.Type;
                sort.Ascending = true;

                lstSortCategory.Add(sort);
            }

            return lstSortCategory;
        }
    }

    class CheckedListBoxItem
    {
       public string Text;
       public SortType Type;

       public override string ToString()
       {
           if (string.IsNullOrEmpty(Text))
               return base.ToString();
           return Text;
       }
    }
}