using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BDSoft.Common
{
    public class TreeListViewEX:TreeListView
    {
        protected readonly Dictionary<string, TreeListViewItem> dictItems = new Dictionary<string, TreeListViewItem>();

        public void LoadItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, List<string> lstPropertyName)
        {
            LoadItems(items, Items, getId, getParentId, getDisplayName, getImageIndex, lstPropertyName);
        }

        public void LoadItems<T>(IEnumerable<T> items, TreeListViewItemCollection Items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, List<string> lstPropertyName)
        {
            //List<string> lstPropertyName = new List<string>();
            Items.Clear();
            dictItems.Clear();

            foreach (var item in items)
            {
                var id = getId(item);
                var displayName = getDisplayName(item);
                var imageIndex=-1;
                if (getImageIndex != null)
                    imageIndex = getImageIndex(item);

                var treeListViewItem = new TreeListViewItem();
                treeListViewItem.Name = id;
                treeListViewItem.Text = displayName;
                treeListViewItem.Tag = item;
                if (imageIndex >= 0)
                    treeListViewItem.ImageIndex = imageIndex;

                foreach (string propertyName in lstPropertyName)
                {
                    object obj = PublicMethods.GetPropertyValue(item, propertyName); ;
                    string str="";
                    if (obj != null)
                        str = obj.ToString();
                    treeListViewItem.SubItems.Add(str);
                }

                dictItems.Add(id,treeListViewItem);
            }

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
    }
}
