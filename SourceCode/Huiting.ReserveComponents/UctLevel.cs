using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;
using ReserveCommon;

namespace ReserveComponents
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



        public List<SortType> GetLstSortType()
        {
            return GetLstSortType(this.checkedListBox1);
        }

        private List<SortInfo> GetLstSortType(CheckedListBox checkedListBox1)
        {
            List<SortInfo> lstSortCategory = new List<SortInfo>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i) == false)
                    continue;
                CheckedListBoxItem clbi = checkedListBox1.Items[i] as CheckedListBoxItem;
                SortInfo si = new SortInfo();
                si.Type = clbi.Type;
                //si.Width
                lstSortCategory.Add(clbi.Type);
            }

            return lstSortCategory;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }

        private void btnHide_Click(object sender, EventArgs e)
        {

        }
    }

    class CheckedListBoxItem
    {
       public string Text;
       public SortType Type;
       public int Width = 120;

       public SortInfo GetSortInfo()
       {
           SortInfo si = new SortInfo();
           si.Type = this.Type;
           si.Width = this.Width;
           return si;
       }


       public override string ToString()
       {
           if (string.IsNullOrEmpty(Text))
               return base.ToString();
           return Text;
       }
    }
}