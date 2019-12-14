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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewColumnNode dgvcn0 = new DataGridViewColumnNode("油气（含税）0");
            DataGridViewColumnNode dgvcn1 = new DataGridViewColumnNode("油气（含税）1");
            DataGridViewColumnNode dgvcn2 = new DataGridViewColumnNode("油气（含税）2");
            DataGridViewColumnNode dgvcn3 = new DataGridViewColumnNode("油气（含税）3");
            DataGridViewColumnNode dgvcn4 = new DataGridViewColumnNode("油气（含税）4");
            DataGridViewColumnNode dgvcn5 = new DataGridViewColumnNode("油气（含税）5");
            DataGridViewColumnNode dgvcn6 = new DataGridViewColumnNode("油气（含税）6");

            dgvcn0.AddChildColumn(dgvcn5);
            dgvcn1.AddChildColumn(dgvcn2);
            dgvcn1.AddChildColumn(dgvcn3);
            dgvcn0.AddChildColumn(dgvcn1);
            dgvcn0.AddChildColumn(dgvcn4);
            dgvcn0.AddChildColumn(dgvcn6);
            

            this.treeHeadDataGridView1.SetTreeHeadRootColumn(dgvcn0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewColumnNode dgcnTemp;
            DataGridViewColumnNode dgcnRoot = new DataGridViewColumnNode();

            DataGridViewColumnNode dgcnPJND = new DataGridViewColumnNode("评价年度");
            dgcnPJND.DataPropertyName = "pjnd";
            dgcnRoot.AddChildColumn(dgcnPJND);

            //string columnTitle = "采油厂";
            //DataGridViewColumnNode dgcnCYC = new DataGridViewColumnNode(columnTitle);
            //dgcnCYC.DataPropertyName = "nodetext";
            //dgcnRoot.AddChildColumn(dgcnCYC);

            //DataGridViewColumnNode dgcnCZCB = new DataGridViewColumnNode("操作成本");
            //dgcnTemp = new DataGridViewColumnNode("万元");
            //dgcnTemp.DataPropertyName = "czcb";
            //dgcnCZCB.AddChildColumn(dgcnTemp);
            //dgcnRoot.AddChildColumn(dgcnCZCB);

            //DataGridViewColumnNode dgcnNCYL = new DataGridViewColumnNode("年产油量");
            //dgcnTemp = new DataGridViewColumnNode("万吨");
            //dgcnTemp.DataPropertyName = "ncyl";
            //dgcnNCYL.AddChildColumn(dgcnTemp);
            //dgcnRoot.AddChildColumn(dgcnNCYL);

            //DataGridViewColumnNode dgcnCZCBBL = new DataGridViewColumnNode("固定成本比例");
            //dgcnTemp = new DataGridViewColumnNode("%");
            //dgcnTemp.DataPropertyName = "gdbl";
            //dgcnCZCBBL.AddChildColumn(dgcnTemp);
            //dgcnRoot.AddChildColumn(dgcnCZCBBL);

            //DataGridViewColumnNode dgcnYYMD = new DataGridViewColumnNode("原油密度");
            //dgcnTemp = new DataGridViewColumnNode(" ");
            //dgcnTemp.DataPropertyName = "yymd";
            //dgcnYYMD.AddChildColumn(dgcnTemp);
            //dgcnRoot.AddChildColumn(dgcnYYMD);

            DataGridViewColumnNode dgcnGDCB = new DataGridViewColumnNode("固定成本");
            dgcnTemp = new DataGridViewColumnNode("万元");
            dgcnTemp.DataPropertyName = "gdcb";
            dgcnTemp.ReadOnly = true;
            dgcnTemp.BackColor = Color.FromArgb(240, 240, 240);
            dgcnGDCB.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnGDCB);

            DataGridViewColumnNode dgcnKBD = new DataGridViewColumnNode("每吨可变成本");
            dgcnTemp = new DataGridViewColumnNode("万元/吨");
            dgcnTemp.DataPropertyName = "tonkbcb";
            dgcnTemp.ReadOnly = true;
            dgcnTemp.BackColor = Color.FromArgb(240, 240, 240);
            dgcnKBD.AddChildColumn(dgcnTemp);
            dgcnRoot.AddChildColumn(dgcnKBD);


            this.treeHeadDataGridView1.SetTreeHeadRootColumn(dgcnRoot);
        }

        private void bdNumBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
