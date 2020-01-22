using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BDSoft.Common;

namespace ReserveAnalysis
{
    public partial class FrmNewProject : FrmChild
    {
        public FrmNewProject()
        {
            InitializeComponent();
        }

        public FrmNewProject(string ProjectName)
        {
            InitializeComponent();
            this.txtProjectName.Text = ProjectName;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitFirst();
        }


        private void InitFirst()
        {
            this.Size = new Size(600,400);
            this.uctSecond.Visible = false;
            this.uctThree.Visible = false;

            this.pnlFirst.Visible = true;
            this.pnlFirst.Dock = DockStyle.Fill;
            this.button1.Visible = false;
            this.button2.Text = "下一步(&N)";
        }

        private void InitSecond()
        {
            this.Size = new Size(800, 550);
            this.pnlFirst.Visible = false;
            this.uctThree.Visible = false;
            this.uctSecond.Visible = true;

            this.uctSecond.Dock = DockStyle.Fill;
            this.button1.Visible = true;
            this.button1.Text = "上一步(&P)";
            this.button2.Text = "完成(&F)";
        }

        private void InitThree()
        {
            this.Size = new Size(800, 550);
            this.pnlFirst.Visible = false;
            this.uctSecond.Visible = false;
            this.uctThree.Visible = true;
            this.uctThree.Dock = DockStyle.Fill;
            this.button1.Visible = true;
            this.button1.Text = "上一步(&P)";
            this.button2.Text = "完成(&F)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitFirst();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text.StartsWith("完成"))
            {
                this.DialogResult = DialogResult.OK;
                return;
            }

            if (radioButton1.Checked)
                InitSecond();
            else
                InitThree();
        }
    }
}
