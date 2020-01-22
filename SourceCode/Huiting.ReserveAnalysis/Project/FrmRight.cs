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
    public partial class FrmRight : DockContent
    {
        public FrmRight()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.panel1.Visible = true;
            this.panel2.Visible = false;

            this.panel1.Location = new Point(0,0);
            this.Width = this.panel1.Width;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = true;
            this.panel2.Location = new Point(0,0);
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel1.Visible = true;
            this.panel1.Location = new Point(0, 0);
        }
    }
}
