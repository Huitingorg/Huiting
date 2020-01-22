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
    public partial class FrmChart : DockContent
    {
        int count = 0;

        public FrmChart()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (count==0)
                this.BackgroundImage = Properties.Resources.b1;
            else if (count == 1)
                this.BackgroundImage = Properties.Resources.b2;
            else if (count == 2)
                this.BackgroundImage = Properties.Resources.b3;
            else if (count == 3)
                this.BackgroundImage = Properties.Resources.b4;
            else if (count == 4)
                this.BackgroundImage = Properties.Resources.b0;
            count++;

            if (count > 4)
                count = 0;
        }
    }
}
