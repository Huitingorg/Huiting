using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveCommon
{
    public partial class UctNewTreeByTree : UserControl
    {
        public UctNewTreeByTree()
        {
            InitializeComponent();
            InitControls();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //uctTree1.LoadFast();
        }

        private void InitControls()
        {
            int w = (this.Width - pnlMiddle.Width) / 2;
            this.pnlLeft.Width = w;
            this.pnlRight.Width = w;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            InitControls();
        }

    }
}
