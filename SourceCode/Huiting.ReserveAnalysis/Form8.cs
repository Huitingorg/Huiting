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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            bdNumBoxEx1.TextChanged += bdNumBoxEx1_TextChanged;
        }

        void bdNumBoxEx1_TextChanged(object sender, EventArgs e)
        {
            bdNumBoxEx1.TextChanged -= bdNumBoxEx1_TextChanged;
            string str = bdNumBoxEx1.Text;
            bdNumBoxEx1.Text = str;
            bdNumBoxEx1.TextChanged += bdNumBoxEx1_TextChanged;
        }
    }
}
