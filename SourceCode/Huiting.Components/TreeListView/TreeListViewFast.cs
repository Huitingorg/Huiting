using Huiting.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    public class TreeListViewFast : TreeListView
    {
        protected Dictionary<string, TreeListViewItem> dictItems = new Dictionary<string, TreeListViewItem>();

        public void LoadItems<T, K>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Dictionary<string, string> dictPropertyName, Func<T, int> getImageIndex, Func<T, Color> getForeColor) where K : class
        {
            LoadItems<T, K>(items, Items, getId, getParentId, getDisplayName, dictPropertyName, getImageIndex,getForeColor);
        }

        public void LoadItems<T, K>(IEnumerable<T> items, TreeListViewItemCollection Items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Dictionary<string, string> dictPropertyName, Func<T, int> getImageIndex, Func<T, Color> getForeColor) where K : class
        {
            Items.Clear();
            dictItems.Clear();
            LoadPartItems<T, K>(items, Items, getId, getParentId, getDisplayName, dictPropertyName, getImageIndex, getForeColor);
        }
        //jiazia
        public void LoadPartItems<T, K>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Dictionary<string, string> dictPropertyName, Func<T, int> getImageIndex, Func<T, Color> getForeColor) where K : class
        {
            LoadPartItems<T, K>(items, Items, getId, getParentId, getDisplayName, dictPropertyName, getImageIndex, getForeColor);
        }

        public void LoadPartItems<T, K>(IEnumerable<T> items, TreeListViewItemCollection Items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Dictionary<string, string> dictPropertyName, Func<T, int> getImageIndex, Func<T, Color> getForeColor) where K : class
        {
            this.BeginUpdate();
            this.SuspendLayout();

            #region 将TreeListViewItem放到字典中

            this.Columns.Clear();
            int columnWidth = (this.Width - 10) / (dictPropertyName.Count + 1);
            int coulumnCounter = 0;
            //先初始化列
            foreach (KeyValuePair<string, string> dictItem in dictPropertyName)
            {
                ColumnHeader ch = new ColumnHeader();
                ch.Text = dictItem.Value;
                if (coulumnCounter == 0)
                    ch.Width = columnWidth * 2;
                else
                    ch.Width = columnWidth;
                coulumnCounter++;

                this.Columns.Add(ch);
            }

            //再初始化数据行
            foreach (var item in items)
            {
                var id = getId(item);
                var imageIndex = -1;
                if (getImageIndex != null)
                    imageIndex = getImageIndex(item);

                var treeListViewItem = new TreeListViewItem();
                treeListViewItem.Name = id;
                treeListViewItem.Tag = item;
                if (imageIndex >= 0)
                    treeListViewItem.ImageIndex = imageIndex;
                treeListViewItem.ForeColor = getForeColor(item);

                K clsK = item as K;
                if (clsK != null)
                {
                    #region TreeListViewItem

                    int columnCounter = 0;
                    foreach (KeyValuePair<string, string> dictItem in dictPropertyName)
                    {
                        object objValue = PublicMethods.GetPropertyValue(item, dictItem.Key);
                        string strValue = objValue == null ? "" : objValue.ToString();
                        if (columnCounter == 0)
                            treeListViewItem.Text = strValue;
                        else
                            treeListViewItem.SubItems.Add(strValue);
                        columnCounter++;
                    }
                    #endregion
                }
                else
                    treeListViewItem.Text = getDisplayName(item);

                dictItems.Add(id, treeListViewItem);
            }

            #endregion

            #region 将TreeListViewItem进行组装

            foreach (var id in dictItems.Keys)
            {
                var item = GetItem(id);
                var obj = (T)item.Tag;
                var parentId = getParentId(obj);

                if (parentId != null)
                {
                    var parentNode = GetItem(parentId.ToString());
                    parentNode.Items.Add(item);
                }
                else
                {
                    Items.Add(item);
                }
            }

            #endregion

            this.ResumeLayout(true);
            this.EndUpdate();
        }

        public TreeListViewItem GetItem(string id)
        {
            return dictItems[id];
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        private void AvgColumnWidth()
        {
            if (this.Columns.Count <= 0)
                return;
            //平均宽度
            int columnWidth = (this.Width - 10) / (this.Columns.Count + 1);
            for (int i = 0; i < Columns.Count; i++)
            {
                ColumnHeader item = Columns[i];
                if (i == 0)
                    item.Width = columnWidth * 2;
                else
                    item.Width = columnWidth;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            AvgColumnWidth();
        }

        public List<T> GetDescendants<T>(string id, int? deepLimit = null)
        {
            var node = GetItem(id);
            var enumerator = node.Items.GetEnumerator();
            var items = new List<T>();

            if (deepLimit.HasValue && deepLimit.Value <= 0)
                return items;

            while (enumerator.MoveNext())
            {
                // Add child
                var childNode = (TreeListViewItem)enumerator.Current;
                var childItem = (T)childNode.Tag;
                items.Add(childItem);

                // If requested add grandchildren recursively
                var childDeepLimit = deepLimit.HasValue ? deepLimit.Value - 1 : (int?)null;
                if (!deepLimit.HasValue || childDeepLimit > 0)
                {
                    var childId = childNode.Name;
                    var descendants = GetDescendants<T>(childId, childDeepLimit);
                    items.AddRange(descendants);
                }
            }
            return items;
        }

        public void RemoveTreeListViewItem<T>(List<T> items, Func<T, string> getId)
        {
            this.BeginUpdate();
            this.SuspendLayout();

            if (items.Count <= 0)
                return;

            //倒序删除
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var id = getId(items[i]);
                if (!dictItems.ContainsKey(id))
                    continue;
                TreeListViewItem tlvi = dictItems[id.ToString()];
                SubRemoveTreeNode(tlvi);
            }

            UpdateDictionary();

            this.ResumeLayout(true);
            this.EndUpdate();
        }

        //递归删除不包含非叶子节点的节点
        private void SubRemoveTreeNode(TreeListViewItem tn)
        {
            if (tn == null || tn.Level == 0)
                return;
            if (tn.Parent.Parent == null)
                tn.Remove();
            else if (tn.Parent.Items.Count == 1)
                SubRemoveTreeNode(tn.Parent);
            else
                tn.Remove();
        }


        //更新字典表
        private void UpdateDictionary()
        {
            dictItems.Clear();
            foreach (TreeListViewItem tn in this.Items)
                SubUpdateDictionary(tn, ref dictItems);
        }

        private void SubUpdateDictionary(TreeListViewItem tn, ref Dictionary<string, TreeListViewItem> dictTreeNode)
        {
            dictTreeNode.Add(tn.Name, tn);
            foreach (TreeListViewItem tnChild in tn.Items)
                SubUpdateDictionary(tnChild, ref dictTreeNode);
        }
    }
}