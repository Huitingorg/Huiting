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
    public partial class FrmLevel : FrmChildWithOutMinAndMax
    {
        List<SortInfo> lstSortInfo;

        public List<SortInfo> LstSortInfo
        {
            get { return lstSortInfo; }
        }
        public FrmLevel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstSortInfo = uctLevel1.GetLstSortInfo();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
