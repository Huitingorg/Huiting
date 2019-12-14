using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BDSoft.Common
{
    public class TreeViewFast : TreeView
    {
        private System.ComponentModel.IContainer components;
        protected readonly Dictionary<string, TreeNode> _treeNodes = new Dictionary<string, TreeNode>();

        public TreeViewFast()
        {
            this.ItemHeight = 20;
        }

        /// <summary>
        /// Load the TreeView with items.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="items">Collection of items</param>
        /// <param name="getId">Function to parse Id value from item object</param>
        /// <param name="getParentId">Function to parse parentId value from item object</param>
        /// <param name="getDisplayName">Function to parse display name value from item object. This is used as node text.</param>
        public void LoadItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName)
        {
            LoadItems(items, Nodes, getId, getParentId, getDisplayName, null);
        }

        public void LoadItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex)
        {
            LoadItems(items,Nodes,getId,getParentId,getDisplayName,getImageIndex);
        }

        public void LoadItems<T>(IEnumerable<T> items, TreeNodeCollection Nodes, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex)
        {
            // Clear view and internal dictionary
            Nodes.Clear();
            _treeNodes.Clear();

            // Load internal dictionary with nodes
            foreach (var item in items)
            {
                var id = getId(item);
                var displayName = getDisplayName(item);
                var imageIndex=-1;
                if (getImageIndex != null)
                    imageIndex = getImageIndex(item);
                var node = new TreeNode { Name = id.ToString(), Text = displayName, Tag = item };
                if (imageIndex >= 0)
                {
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                }

                _treeNodes.Add(id, node);
            }

            // Create hierarchy and load into view
            foreach (var id in _treeNodes.Keys)
            {
                var node = GetNode(id);
                var obj = (T)node.Tag;
                var parentId = getParentId(obj);

                if (parentId != null)
                {
                    var parentNode = GetNode(parentId.ToString());
                    parentNode.Nodes.Add(node);
                }
                else
                {
                    Nodes.Add(node);
                }
            }
        }

        /// <summary>
        /// Get a handle to the object collection.
        /// This is convenient if you want to search the object collection.
        /// </summary>
        public IQueryable<T> GetItems<T>()
        {
            return _treeNodes.Values.Select(x => (T)x.Tag).AsQueryable();
        }

        /// <summary>
        /// Retrieve TreeNode by Id.
        /// Useful when you want to select a specific node.
        /// </summary>
        /// <param name="id">Item id</param>
        public TreeNode GetNode(string id)
        {
            return _treeNodes[id];
        }

        /// <summary>
        /// Retrieve item object by Id.
        /// Useful when you want to get hold of object for reading or further manipulating.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="id">Item id</param>
        /// <returns>Item object</returns>
        public T GetItem<T>(string id)
        {
            return (T)GetNode(id).Tag;
        }


        /// <summary>
        /// Get parent item.
        /// Will return NULL if item is at top level.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="id">Item id</param>
        /// <returns>Item object</returns>
        public T GetParent<T>(string id) where T : class
        {
            var parentNode = GetNode(id).Parent;
            return parentNode == null ? null : (T)Parent.Tag;
        }

        /// <summary>
        /// Retrieve descendants to specified item.
        /// </summary>
        /// <typeparam name="T">Item type</typeparam>
        /// <param name="id">Item id</param>
        /// <param name="deepLimit">Number of generations to traverse down. 1 means only direct children. Null means no limit.</param>
        /// <returns>List of item objects</returns>
        public List<T> GetDescendants<T>(string id, int? deepLimit = null)
        {
            var node = GetNode(id);
            var enumerator = node.Nodes.GetEnumerator();
            var items = new List<T>();

            if (deepLimit.HasValue && deepLimit.Value <= 0)
                return items;

            while (enumerator.MoveNext())
            {
                // Add child
                var childNode = (TreeNode)enumerator.Current;
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

        #region 右键选中

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
                this.SelectedNode = this.GetNodeAt(e.X, e.Y);
        }

        #endregion

        //获取属性值
        public List<string> GetListPropertyValue(TreeNode tn, string propertyName)
        {
            TreeNodeCollection tnc;
            if (tn == null)
                tnc = this.Nodes;
            else
                tnc = tn.Nodes;

            Type type = typeof(TreeNode);

            List<string> lstName = new List<string>();
            foreach (TreeNode item in tnc)
            {
                object obj = PublicMethods.GetPropertyValue(item, propertyName);
                if (obj == null)
                    continue;
                lstName.Add(obj.ToString());
            }

            return lstName;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}