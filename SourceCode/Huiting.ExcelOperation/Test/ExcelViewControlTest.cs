using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Huiting.ExcelOperation
{
    public partial class ExcelViewControlTest : Form
    {
        public ExcelViewControlTest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this).Equals(DialogResult.OK))
            {
               // this.excelViewControl1.ViewExcelFile(ofd.FileName);
            }
        }
    }
}
