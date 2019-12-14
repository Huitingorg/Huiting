using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Common
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(string));
            byte[] data = Convert.FromBase64String(textBox1.Text);
            object instance = converter.ConvertFrom(null, CultureInfo.InvariantCulture, data);
        }
    }
}
