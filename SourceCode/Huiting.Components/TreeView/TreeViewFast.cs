﻿using Huiting.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Huiting.Components
{
    public class TreeViewFast : TreeViewByRightSelected
    {
        protected Dictionary<string, TreeNode> dictNodes = new Dictionary<string, TreeNode>();

        public TreeViewFast()
        {
            this.ItemHeight = 20;
        }

        ///// <summary>
        ///// Load the TreeView with items.
        ///// </summary>
        ///// <typeparam name="T">Item type</typeparam>
        ///// <param name="items">Collection of items</param>
        ///// <param name="getId">Function to parse Id value from item object</param>
        ///// <param name="getParentId">Function to parse parentId value from item object</param>
        ///// <param name="getDisplayName">Function to parse display name value from item object. This is used as node text.</param>
        //public void LoadItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName)
        //{
        //    LoadItems(items, Nodes, getId, getParentId, getDisplayName, null);
        //}

        public void LoadItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, Func<T, Color> getForeColor)
        {
            LoadItems(items, Nodes, getId, getParentId, getDisplayName, getImageIndex, getForeColor);
        }

        public void LoadItems<T>(IEnumerable<T> items, TreeNodeCollection Nodes, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, Func<T, Color> getForeColor)
        {
            // Clear view and internal dictionary
            Nodes.Clear();
            dictNodes.Clear();
            //Func<T, Color> getForeColor = (x => Color.Black);
            LoadPartItems(items, Nodes, getId, getParentId, getDisplayName, getImageIndex, getForeColor);
        }

        //public void LoadPartItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex)
        //{
        //    LoadPartItems(items,Nodes,getId,getParentId,getDisplayName,getImageIndex,this.ForeColor);
        //}

        public void LoadPartItems<T>(IEnumerable<T> items, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, Func<T, Color> getForeColor)
        {
            LoadPartItems(items, Nodes, getId, getParentId, getDisplayName, getImageIndex, getForeColor);
        }

        public void LoadPartItems<T>(IEnumerable<T> items, TreeNodeCollection Nodes, Func<T, string> getId, Func<T, string> getParentId, Func<T, string> getDisplayName, Func<T, int> getImageIndex, Func<T, Color> getForeColor)
        {
            this.BeginUpdate();
            this.SuspendLayout();

            #region 将TreeNode放到字典中

            //记录新增加的项的起始位置
            int start = dictNodes.Count;
            foreach (var item in items)
            {
                var id = getId(item);
                if (dictNodes.ContainsKey(id))
                    continue;
                var displayName = getDisplayName(item);
                var imageIndex = -1;
                if (getImageIndex != null)
                    imageIndex = getImageIndex(item);
                var node = new TreeNode { Name = id.ToString(), Text = displayName, Tag = item };
                if (imageIndex >= 0)
                {
                    node.ImageIndex = imageIndex;
                    node.SelectedImageIndex = imageIndex;
                }
                //设置新增节点颜色
                node.ForeColor = getForeColor(item);

                dictNodes.Add(id, node);
            }

            #endregion

            #region 组装TreeNode
            
            //计数器，用于定位到新增加项前位置 
            int counter=0;
            foreach (var id in dictNodes.Keys)
            {
                try
                {
                    if (counter < start)
                    {
                        counter++;
                        continue;
                    }

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
                        //if (!this.Nodes.Contains(node))
                        Nodes.Add(node);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            #endregion

            this.ResumeLayout(true);
            this.EndUpdate();
        }

        //递归删除不包含非叶子节点的节点
        public void RemoveTreeNode<T>(List<T> items, Func<T, string> getId)
        {
            this.BeginUpdate();
            this.SuspendLayout();

            if (items.Count <= 0)
                return;
            //倒序删除
            for (int i = items.Count - 1; i >= 0; i--)
            {
                var id = getId(items[i]);
                if (!dictNodes.ContainsKey(id))
                    continue;
                TreeNode tn = dictNodes[id.ToString()];
                SubRemoveTreeNode(tn);
            }

            UpdateDictionary();

            this.ResumeLayout(true);
            this.EndUpdate();
        }

        //递归删除不包含非叶子节点的节点
        private void SubRemoveTreeNode(TreeNode tn)
        {
            if (tn == null || tn.Level==0)
                return;
            if (tn.Parent.Parent == null)
                tn.Remove();
            else if (tn.Parent.Nodes.Count == 1)
                SubRemoveTreeNode(tn.Parent);
            else
                tn.Remove();
        }

        //更新字典表
        private void UpdateDictionary()
        {
            //Dictionary<string, TreeNode> dictTreeNode = new Dictionary<string, TreeNode>();
            dictNodes.Clear();
            foreach (TreeNode tn in this.Nodes)
                SubUpdateDictionary(tn, ref dictNodes);
            //dictNodes = dictTreeNode;
        }

        private void SubUpdateDictionary(TreeNode tn, ref Dictionary<string, TreeNode> dictTreeNode)
        {
            dictTreeNode.Add(tn.Name, tn);
            foreach (TreeNode tnChild in tn.Nodes)
                SubUpdateDictionary(tnChild, ref dictTreeNode);
        }

        /// <summary>
        /// Get a handle to the object collection.
        /// This is convenient if you want to search the object collection.
        /// </summary>
        public IQueryable<T> GetItems<T>()
        {
            return dictNodes.Values.Select(x => (T)x.Tag).AsQueryable();
        }

        /// <summary>
        /// Retrieve TreeNode by Id.
        /// Useful when you want to select a specific node.
        /// </summary>
        /// <param name="id">Item id</param>
        public TreeNode GetNode(string id)
        {
            if (!dictNodes.ContainsKey(id))
                return null;
            return dictNodes[id];
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

        public void SetNodeChecked<T>(List<T> LstT)
        {
            foreach (T item in LstT)
            {
                
            }
        }

        ///// <summary>
        ///// Retrieve descendants to specified item.
        ///// </summary>
        ///// <typeparam name="T">Item type</typeparam>
        ///// <param name="id">Item id</param>
        ///// <param name="deepLimit">Number of generations to traverse down. 1 means only direct children. Null means no limit.</param>
        ///// <returns>List of item objects</returns>
        //public List<T> GetDescendants<T>(string id) where T:class
        //{
        //    var items = new List<T>();
        //    var node = GetNode(id);
        //    if (node == null)
        //        return items;
        //    var enumerator = node.Nodes.GetEnumerator();
        //    while (enumerator.MoveNext())
        //    {
        //        // Add child
        //        var childNode = (TreeNode)enumerator.Current;
        //        var childItem = childNode.Tag as T;
        //        if (childItem != null)
        //        {
        //            items.Add(childItem);
        //            continue;
        //        }

        //        // If requested add grandchildren recursively
        //        var childId = childNode.Name;
        //        var descendants = GetDescendants<T>(childId, childDeepLimit);
        //        items.AddRange(descendants);
        //    }
        //    return items;
        //}

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