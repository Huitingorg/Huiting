﻿using Huiting.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    public partial class FrmTreeHeadColumnsEdit : Form
    {
        #region Properties

        //根节点
        TreeNode rootNode;
        
        DataGridViewColumnNode rootColumn;

        public DataGridViewColumnNode RootColumn
        {
            get { return rootColumn; }
            set { rootColumn = value; }
        }

        #endregion

        #region Constructor
        
        public FrmTreeHeadColumnsEdit(DataGridViewColumnNode hwvDgvc)
        {
            InitializeComponent();
            rootColumn = hwvDgvc;

            rootNode = treeView1.Nodes[0];
        }

        #endregion

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            TreeNode tnParent = treeView1.SelectedNode;
            if (tnParent == null)
                tnParent = rootNode;

            List<string> lstColumnName = GetGetLstDgvcName();
            string name = PublicMethods.CreateNewName(lstColumnName.ToArray(), "column");

            DataGridViewColumnNode hwvDgvc = new DataGridViewColumnNode();
            hwvDgvc.Name = name;

            TreeNode tn = new TreeNode();
            tn.Text = hwvDgvc.Text;
            tn.Tag = hwvDgvc;

            tnParent.Nodes.Add(tn);
            tnParent.Expand();

            treeView1.SelectedNode = tn;
            //this.propertyGrid1.Focus();
        }

        private void FrmTreeHeadColumnsEdit_Load(object sender, EventArgs e)
        {
            InitTreeView();
        }

        private void InitTreeView()
        {
            treeView1.Nodes.Clear();
            rootNode = InitTreeNode(rootColumn);
            treeView1.Nodes.Add(rootNode);
            treeView1.ExpandAll();
        }

        private TreeNode InitTreeNode(DataGridViewColumnNode treeColumn)
        {
            if (treeColumn == null)
                treeColumn = new DataGridViewColumnNode();
            DataGridViewColumnNode rootDgvcColumn = treeColumn.Clone();

            TreeNode tnRoot = new TreeNode();
            tnRoot.Text = "树形表头";
            tnRoot.Tag = rootDgvcColumn;

            SubInitTreeNode(treeColumn, ref tnRoot);

            return tnRoot;
        }

        private void SubInitTreeNode(DataGridViewColumnNode dgvcParent, ref TreeNode tnParent)
        {
            for (int i = 0; i < dgvcParent.ChildColumns.Count; i++)
            {
                DataGridViewColumnNode dgvc = dgvcParent.ChildColumns[i];

                DataGridViewColumnNode dgvcCopy = dgvc.Clone();
                TreeNode tn = new TreeNode();
                tn.Text = dgvcCopy.Text;
                tn.Tag = dgvcCopy;
                tnParent.Nodes.Add(tn);

                if (dgvc.IsLeafColumn)
                    continue;

                SubInitTreeNode(dgvc, ref tn);
            }
        }

        private List<string> GetGetLstDgvcName()
        {
            List<string> lstColumnName = new List<string>();
            SubGetGetLstDgvcName(rootNode,ref lstColumnName);

            return lstColumnName;
        }

        private void SubGetGetLstDgvcName(TreeNode tn, ref List<string> lstColumnName)
        {
            foreach (TreeNode item in tn.Nodes)
            {
                DataGridViewColumnNode hwvDgvc = item.Tag as DataGridViewColumnNode;
                if (!lstColumnName.Contains(hwvDgvc.Name))
                    lstColumnName.Add(hwvDgvc.Name);

                SubGetGetLstDgvcName(item, ref lstColumnName);
            }
        }

        public object GetSelectedObject(object selectedObject)
        {
            return selectedObject;
            //if (selectedObject == null)
                return selectedObject;
            ////获取属性
            //Dictionary<string, HWVPropertyAttribute> dictAttributes = PublicMethods.GetLstAttributeByObject<HWVPropertyAttribute>(selectedObject);
            ////过滤
            //MyCustomTypeDescriptor<HWVPropertyAttribute> myCustTypeDescProp = new MyCustomTypeDescriptor<HWVPropertyAttribute>(selectedObject, dictAttributes);
            //return myCustTypeDescProp;
        }

        public void SetSelectedObject(object selectedObject)
        {
            propertyGrid1.SelectedObject = GetSelectedObject(selectedObject);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            object selectedObject;
            if (e.Node.Parent == null)
                selectedObject = null;
            else
            {
                DataGridViewColumnNode hwvDgvc = e.Node.Tag as DataGridViewColumnNode;
                selectedObject = hwvDgvc;
            }
            SetSelectedObject(selectedObject);

            SetButtonEnabled(e.Node);
        }

        private void SetButtonEnabled(TreeNode tn)
        {
            if (tn.Parent == null)
            {
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            }
            else
            {
                btnUp.Enabled = tn == tn.Parent.FirstNode ? false : true;
                btnDown.Enabled = tn == tn.Parent.Nodes[tn.Parent.Nodes.Count - 1] ? false : true;
            }
        }

        private DataGridViewColumnNode GetHWVDataGridViewColumn()
        {
            DataGridViewColumnNode dgvc = new DataGridViewColumnNode();
            SubGetHWVDataGridViewColumn(rootNode,ref dgvc);

            return dgvc;
        }

        private void SubGetHWVDataGridViewColumn(TreeNode tnParent, ref DataGridViewColumnNode dgvcParent)
        {
            foreach (TreeNode tn in tnParent.Nodes)
            {
                DataGridViewColumnNode dgvc = tn.Tag as DataGridViewColumnNode;
                dgvcParent.AddChildColumn(dgvc);

                SubGetHWVDataGridViewColumn(tn, ref dgvc);
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            rootColumn = GetHWVDataGridViewColumn();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn == null || tn.Parent == null)
                return;

            TreeNode tnParent = tn.Parent;
            int intCur = tn.Index;
            int intNext = intCur - 1;

            if (intNext < 0)
                return;

            TreeNode tnTemp = tnParent.Nodes[intNext];
            tnParent.Nodes.RemoveAt(intNext);
            tnParent.Nodes.Insert(intCur, tnTemp);

            treeView1.SelectedNode = tnParent.Nodes[intNext];
            SetButtonEnabled(treeView1.SelectedNode);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            TreeNode tn = treeView1.SelectedNode;
            if (tn == null || tn.Parent == null)
                return;

            TreeNode tnParent = tn.Parent;
            int intCur = tn.Index;
            int intNext = intCur + 1;

            if (intNext > tnParent.Nodes.Count-1)
                return;

            TreeNode tnTemp = tnParent.Nodes[intCur];
            tnParent.Nodes.RemoveAt(intCur);
            tnParent.Nodes.Insert(intNext, tnTemp);


            treeView1.SelectedNode = tnParent.Nodes[intNext];
            SetButtonEnabled(treeView1.SelectedNode);
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            DeleteTreeNode();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteTreeNode();
        }

        private void DeleteTreeNode()
        {
            if (treeView1.SelectedNode == null)
                return;

            treeView1.SelectedNode.Remove();
        }

        private void lblCollapse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.treeView1.SelectedNode == null)
                return;
            treeView1.SelectedNode.Collapse();
        }

        private void lblExpand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.treeView1.SelectedNode == null)
                return;
            treeView1.SelectedNode.ExpandAll();
        }

    }
}