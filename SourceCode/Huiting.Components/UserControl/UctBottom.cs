using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    public partial class UctBottom : UserControl
    {
        public UctBottom()
        {
            InitializeComponent();
            this.Dock = DockStyle.Bottom;
        }

        public event EventHandler BtnSure;
        public event EventHandler BtnCancle;

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (BtnCancle != null)
                BtnCancle(sender, e);
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (BtnSure != null)
                BtnSure(sender, e);
        }
    }
}