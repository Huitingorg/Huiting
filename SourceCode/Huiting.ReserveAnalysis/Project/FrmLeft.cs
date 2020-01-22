using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using BDSoft.Common;
using ReserveCommon;

namespace ReserveAnalysis
{
    public partial class FrmLeft : DockContent
    {
        //ItemData data;

        //public ItemData Data
        //{
        //    get { return data; }
        //    set { data = value; }
        //}

        public FrmLeft()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public void LoadData(ItemData Data)
        {
            uctTree1.LoadFast(Data);
            uctTree1.SwitchProject -= uctTree1_SwitchProject;
            uctTree1.SwitchProject += uctTree1_SwitchProject;
        }

        public event EventHandler SwitchProject;
        void uctTree1_SwitchProject(object sender, EventArgs e)
        {
            if (SwitchProject != null)
                SwitchProject(sender, e);
        }

        private void tsmCreateProject_Click(object sender, EventArgs e)
        {
            //FrmCreateProject fcp = new FrmCreateProject();
            //fcp.ShowDialog(this);
            //treeViewFast1.Nodes.Add(Guid.NewGuid().ToString(), "工程" + (treeViewFast1.Nodes.Count + 1), 0);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<string> lstNames = this.uctTree1.TreeViewFast.GetListPropertyValue(null, "Text");
            string projectName = PublicMethods.CreateNewName(lstNames.ToArray(), "工程");


            FrmNewProject fnp = new FrmNewProject(projectName);
            if (fnp.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;

            TreeNode tn = new TreeNode();
            tn.Name = Guid.NewGuid().ToString();
            tn.Text = projectName;
            tn.ImageIndex = 0;

            this.uctTree1.TreeViewFast.Nodes.Add(tn);
            this.uctTree1.TreeViewFast.SelectedNode = tn;
        }
        
        private void tsmSelectCommon_Click(object sender, EventArgs e)
        {
            FrmSelectCommon fnp = new FrmSelectCommon();
            if (fnp.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
        }

        private void tsmSelectSql_Click(object sender, EventArgs e)
        {
            FrmSqlFilter fsf = new FrmSqlFilter();
            if (fsf.ShowDialog(this) != System.Windows.Forms.DialogResult.OK)
                return;
        }
    }
}