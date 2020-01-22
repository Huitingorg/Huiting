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
    public partial class UctNewTreeByFilter : UserControl
    {
        public UctNewTreeByFilter()
        {
            InitializeComponent();
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
