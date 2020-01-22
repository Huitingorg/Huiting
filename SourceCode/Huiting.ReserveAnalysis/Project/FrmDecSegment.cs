using LocalDataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ReserveAnalysis
{
    public partial class FrmDecSegment : DockContent
    {
        public FrmDecSegment()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TmpDecSegmentService tmpDecSegment = new TmpDecSegmentService();
            DataTable dt= tmpDecSegment.GetDataTable();

            this.dgvDec.DataSource = dt;
        }
    }
}
