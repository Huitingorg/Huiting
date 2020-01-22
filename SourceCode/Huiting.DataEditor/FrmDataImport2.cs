using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.DataEditor
{
    public partial class FrmDataImport2 : DevExpress.XtraBars.TabForm
    {
        public FrmDataImport2()
        {
            InitializeComponent();
        }


        private void pnlExcel_Click(object sender, EventArgs e)
        {
            this.wizardControl1.SelectedPageIndex = 1;
        }

        private void pnlResult_Click(object sender, EventArgs e)
        {

        }

        private void pnlDB_Click(object sender, EventArgs e)
        {

        }

        private void pnlFormat_Click(object sender, EventArgs e)
        {

        }
    }
}
