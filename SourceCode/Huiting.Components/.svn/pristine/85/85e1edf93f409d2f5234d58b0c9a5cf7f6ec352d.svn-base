using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewColumnNode dgvcn0 = new DataGridViewColumnNode("c0");
            DataGridViewColumnNode dgvcn1 = new DataGridViewColumnNode("c1");
            DataGridViewColumnNode dgvcn2 = new DataGridViewColumnNode("c2");
            DataGridViewColumnNode dgvcn3 = new DataGridViewColumnNode("c3");
            DataGridViewColumnNode dgvcn4 = new DataGridViewColumnNode("c4");

            dgvcn1.AddChildColumn(dgvcn2);
            dgvcn1.AddChildColumn(dgvcn3);
            dgvcn0.AddChildColumn(dgvcn1);
            dgvcn0.AddChildColumn(dgvcn4);



            //this.treeHeadDataGridView1.TreeHeadRootColumn = dgvcn0;

        }
    }
}
