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
    public partial class FrmAssetsGroup : FrmChildWithOutMinAndMax
    {
        GroupInfoQueue groupInfoQueue;
        public GroupInfoQueue SortInfoQueue
        {
            get { return groupInfoQueue; }
        }

        public FrmAssetsGroup(GroupInfoQueue groupInfoQueue)
        {
            InitializeComponent();
            this.groupInfoQueue = groupInfoQueue;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.uctSort1.InitCheckedListBox(groupInfoQueue, true);
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            groupInfoQueue = uctSort1.GetLstSortInfo<GroupInfo, GroupInfoQueue>();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}