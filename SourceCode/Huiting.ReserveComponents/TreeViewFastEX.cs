using Huiting.Components;

using ReserveCommon;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReserveComponents
{
    public interface IAssetsControl
    {
        bool CheckBoxes { get; set; }
        ///向上递归，获取所有父节点队列
        List<IEntityData> GetLstTreeDataToUp(object item);
        ///向下递归，获取所有子节点队列
        List<IEntityData> GetLstTreeDataToDown(object item);
        ///向下递归，获取子级子节点队列
        List<IEntityData> GetLstDataToDown(object item);
        //递归获取所有叶子节点队列
        List<AssetsData> GetLstLeafData(object item);
        //递归获取所有叶子节点队列
        List<AssetsData> GetLstLeafData();

        IEntityData GetSelectedEntityData();

        void UpdateItems(SortInfoQueue sortInfoQueue);

        object GetControlItem(string ID);

        void SetContrlItemSelected(object item);

        void SetContrlItemChecked(List<AssetsData> lstAssetsData);

        void SetSelectedItemForeColor(Color clr);
    }

    [Serializable]
    public class TreeViewFastEX : TreeViewFast, IAssetsControl
    {
        public new TreeNodeCollection Nodes
        {
            get
            {
                return base.Nodes;
            }
        }

        public TreeViewFastEX()
            : base()
        {
            this.FullRowSelect = true;
            this.HideSelection = false;
        }

        #region 获取当前所有的叶子节点

        //获取所有节点的数据队列
        public List<AssetsData> GetLstLeafData()
        {
            List<AssetsData> lstData = new List<AssetsData>();
            foreach (KeyValuePair<string, TreeNode> item in dictNodes)
            {
                if (item.Value == null)
                    continue;
                AssetsData data = item.Value.Tag as AssetsData;
                if (data == null)
                    continue;
                lstData.Add(data);
            }
            return lstData;
        }

        //获取指定节点下所有的数据队列
        public List<AssetsData> GetLstLeafData(object item)
        {
            List<AssetsData> lstAssetsData = new List<AssetsData>();
            TreeNode tn = item as TreeNode;
            if (tn == null)
                return lstAssetsData;

            SubGetLstAssetsData(tn, ref lstAssetsData);
            return lstAssetsData;
        }

        private void SubGetLstAssetsData(TreeNode tn, ref List<AssetsData> lstAssetsData)
        {
            AssetsData AssetsData = tn.Tag as AssetsData;
            if (AssetsData != null)
            {
                AssetsData dataCopy = AssetsData.Clone() as AssetsData;
                lstAssetsData.Add(dataCopy);
            }
            foreach (TreeNode tnChild in tn.Nodes)
                SubGetLstAssetsData(tnChild, ref lstAssetsData);
        }

        //设置节点处于选中状态
        public void SetContrlItemChecked(List<AssetsData> lstAssetsData)
        {
            foreach (AssetsData item in lstAssetsData)
            {
                if (dictNodes.ContainsKey(item.ID) == false)
                    continue;
                dictNodes[item.ID].Checked = true;
            }

            ////设置选中
            //foreach (TreeNode tn in this.Nodes)
            //{
            //    SubSetContrlItemChecked(tn, lstAssetsData);
            //}
        }

        //设置选中
        private void SubSetContrlItemChecked(TreeNode tn, List<AssetsData> lstAssetsData)
        {
            AssetsData data = tn.Tag as AssetsData;
            if (data != null)
                tn.Checked = lstAssetsData.Exists(x => x.ID == data.ID);
            foreach (TreeNode tnChild in tn.Nodes)
                SubSetContrlItemChecked(tnChild, lstAssetsData);
        }

        #endregion

        public List<IEntityData> GetLstTreeDataToUp(object item)
        {
            List<IEntityData> lstEntity = new List<IEntityData>();
            TreeNode tn = item as TreeNode;
            if (tn != null)
                SubGetLstTreeDataToUp(tn, ref lstEntity);
            return lstEntity;
        }

        private void SubGetLstTreeDataToUp(TreeNode tn, ref List<IEntityData> lstEntity)
        {
            if (tn == null)
                return;
            IEntityData data = tn.Tag as IEntityData;
            if (data != null)
                lstEntity.Add(data);
            SubGetLstTreeDataToUp(tn.Parent, ref lstEntity);
        }

        public List<IEntityData> GetLstDataToDown(object item)
        {
            List<IEntityData> lstEntity = new List<IEntityData>();
            TreeNode tn = item as TreeNode;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                IEntityData data = tnChild.Tag as IEntityData;
                if (data != null)
                    lstEntity.Add(data);
            }

            return lstEntity;
        }

        public List<IEntityData> GetLstTreeDataToDown(object item)
        {
            List<IEntityData> lstEntity = new List<IEntityData>();
            TreeNode tn = item as TreeNode;
            if (tn != null)
                SubGetLstTreeDataToDown(tn, ref lstEntity);
            return lstEntity;
        }

        private void SubGetLstTreeDataToDown(TreeNode tn, ref List<IEntityData> lstEntity)
        {
            if (tn == null)
                return;
            IEntityData data = tn.Tag as IEntityData;
            if (data != null)
                lstEntity.Add(data);

            foreach (TreeNode tnChild in tn.Nodes)
            {
                SubGetLstTreeDataToDown(tnChild, ref lstEntity);
            }
        }

        public object GetControlItem(string ID)
        {
            if (ID == null)
                return null;

            if (dictNodes.ContainsKey(ID))
                return dictNodes[ID];
            return null;
        }

        public void SetContrlItemSelected(object item)
        {
            TreeNode tn = item as TreeNode;
            if (tn == null)
                return;
            this.SelectedNode = tn;
        }


        public void UpdateItems(SortInfoQueue sortInfoQueue)
        {
            this.BeginUpdate();
            this.SuspendLayout();
            //方式一：遍历字典，缺点：界面闪烁
            //foreach (KeyValuePair<string, TreeNode> item in dictNodes)
            //{
            //    TreeNode treeNode = item.Value;
            //    IAssetsData assetsData = treeNode.Tag as IAssetsData;
            //    if (assetsData != null)
            //        treeNode.Text = assetsData.GetText(sortInfoQueue);
            //}

            //方式二：遍历节点
            foreach (TreeNode item in this.Nodes)
            {
                SubUpdateItems(item, sortInfoQueue);
            }

            this.ResumeLayout();
            this.EndUpdate();
        }

        private void SubUpdateItems(TreeNode treeNode, SortInfoQueue sortInfoQueue)
        {
            IAssetsData assetsData = treeNode.Tag as IAssetsData;
            if (assetsData != null)
                treeNode.Text = assetsData.GetText(sortInfoQueue);

            foreach (TreeNode item in treeNode.Nodes)
            {
                SubUpdateItems(item, sortInfoQueue);
            }
        }


        public IEntityData GetSelectedEntityData()
        {
            if (this.SelectedNode == null)
                return null;

            return this.SelectedNode.Tag as IEntityData;
        }


        public void SetSelectedItemForeColor(Color clr)
        {
            this.SelectedNode.ForeColor = clr;
        }
    }
}