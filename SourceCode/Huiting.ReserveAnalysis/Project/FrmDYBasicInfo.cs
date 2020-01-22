using LocalDataService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveAnalysis
{
    public partial class FrmDYBasicInfo : Form
    {
        public FrmDYBasicInfo()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DataTable dt= new DYDAB01Service().GetDataTable(null);
            this.dataGridView1.DataSource = dt;
        }
    }
}