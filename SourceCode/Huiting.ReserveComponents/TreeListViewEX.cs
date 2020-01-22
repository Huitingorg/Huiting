using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Huiting.Components;
using ReserveCommon;
using Huiting.Common;

namespace ReserveComponents
{
    [Serializable]
    public class TreeListViewEX : TreeListViewFast, IAssetsControl
    {
        public TreeListViewEX()
        {
            this.MultiSelect = true;
        } 

        public List<AssetsData> GetLstLeafData(object item)
        {
            List<AssetsData> lstData = new List<AssetsData>();
            TreeListViewItem tlvi = item as TreeListViewItem;
            if (tlvi == null)
                return lstData;

            SubGetLstLeafData(tlvi, ref lstData);
            return lstData;
        }

        private void SubGetLstLeafData(TreeListViewItem tlvi, ref List<AssetsData> lstData)
        {
            AssetsData data = tlvi.Tag as AssetsData;
            if (data != null)
                lstData.Add(data);

            foreach (TreeListViewItem tlviChild in tlvi.Items)
                SubGetLstLeafData(tlviChild, ref lstData);
        }

        public List<AssetsData> GetLstLeafData()
        {
            List<AssetsData> lstData = new List<AssetsData>();
            foreach (KeyValuePair<string,TreeListViewItem> item in dictItems)
            {
                if(item.Value==null)
                    continue;

                AssetsData data = item.Value.Tag as AssetsData;
                if (data == null)
                    continue;
                lstData.Add(data);
            }

            return lstData;
        }

        public void SetContrlItemChecked(List<AssetsData> lstAssetsData)
        {
            foreach (AssetsData item in lstAssetsData)
            {
                if (dictItems.ContainsKey(item.ID) == false)
                    continue;
                dictItems[item.ID].Checked = true;
            }
        }

        public List<IEntityData> GetLstTreeDataToUp(object item)
        {
            List<IEntityData> lstEntity = new List<IEntityData>();
            TreeListViewItem tn = item as TreeListViewItem;
            if (tn != null)
                SubGetLstTreeDataToUp(tn, ref lstEntity);
            return lstEntity;
        }

        private void SubGetLstTreeDataToUp(TreeListViewItem tn, ref List<IEntityData> lstEntity)
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
            TreeListViewItem tn = item as TreeListViewItem;
            foreach (TreeListViewItem tnChild in tn.Items)
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
            TreeListViewItem tn = item as TreeListViewItem;
            if (tn != null)
                SubGetLstTreeDataToDown(tn, ref lstEntity);
            return lstEntity;
        }

        private void SubGetLstTreeDataToDown(TreeListViewItem tn, ref List<IEntityData> lstEntity)
        {
            if (tn == null)
                return;
            IEntityData data = tn.Tag as IEntityData;
            if (data != null)
                lstEntity.Add(data);

            foreach (TreeListViewItem tnChild in tn.Items)
            {
                SubGetLstTreeDataToDown(tnChild, ref lstEntity);
            }
        }

        public object GetControlItem(string ID)
        {
            if (dictItems.ContainsKey(ID))
                return dictItems[ID];
            return null;
        }

        public void SetContrlItemSelected(object item)
        {
            TreeListViewItem tn = item as TreeListViewItem;
            if (tn == null)
                return;

            //TreeListViewItem tlvi2 = this.SelectedItems[0];
            //int count1 = this.SelectedIndices.Count;
            //int count2 = this.SelectedItems.Count;
            //if (count2 > 0)
            //{
            //    TreeListViewItem tlvi = this.SelectedItems[0];
            //}

            tn.Focused = true;
            tn.Selected = true;
            tn.EnsureVisible();

            //if (count2 > 0)
            //{
            //    TreeListViewItem tlvi = this.SelectedItems[0];
            //}
        }


        public void UpdateItems(SortInfoQueue sortInfoQueue)
        {
            Dictionary<string, string> dictPropertyName = sortInfoQueue.GetDictPropertyName();
            this.SuspendLayout();
            foreach (KeyValuePair<string, TreeListViewItem> item in dictItems)
            {
                UpdateTreeListViewItem(item.Value, dictPropertyName);
            }
            this.ResumeLayout();
        }

        private void UpdateTreeListViewItem(TreeListViewItem treeListViewItem, Dictionary<string, string> dictPropertyName)
        {
            IAssetsData data = treeListViewItem.Tag as IAssetsData;
            if (data == null)
                return;
            int columnCounter = 0;
            foreach (KeyValuePair<string, string> dictItem in dictPropertyName)
            {
                object objValue = PublicMethods.GetPropertyValue(data, dictItem.Key);
                string strValue = objValue == null ? "" : objValue.ToString();
                if (columnCounter == 0)
                    treeListViewItem.Text = strValue;
                else
                    treeListViewItem.SubItems[columnCounter].Text = strValue;
                columnCounter++;
            }
        }

        private void SubUpdateItems(TreeListViewItem tlvi, SortInfoQueue sortInfoQueue)
        {

        }


        public IEntityData GetSelectedEntityData()
        {
            if (this.SelectedItems.Count <= 0)
                return null;
            return this.SelectedItems[0].Tag as IEntityData;
        }


        public void SetSelectedItemForeColor(System.Drawing.Color clr)
        {
            if (this.SelectedItems.Count > 0)
                this.SelectedItems[0].ForeColor = clr;
        }
    }
}
