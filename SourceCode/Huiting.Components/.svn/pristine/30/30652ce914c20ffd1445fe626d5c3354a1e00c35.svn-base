using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace BDSoft.Components
{
    public class TreeViewEx : TreeView
    {
        private TreeNode SelectNode = null;
        private TreeNode MouseClickNode = null;
        public delegate void NodeMouseClickEx_New(TreeNode sender, MouseEventArgs e);
        public delegate void AfterExpandEx_New(TreeNode sender, MouseEventArgs e);
        public delegate void AfterCollapse_New(TreeNode sender, MouseEventArgs e);
        public event AfterExpandEx_New NodeMouseClickEx;
        public event AfterExpandEx_New AfterExpandEx;
        public event AfterCollapse_New AfterCollapseEx;

        public Color m_SelectFontColor = Color.MediumPurple;
        public Color m_SelectBackColor = Color.LightBlue;
        public Color m_UnSelectFontColor = Color.Black;
        public Color m_UnSelectBackColor = Color.White;
        /// <summary>
        /// 选中颜色
        /// </summary>
        public Color SelectNodeFontColor
        {
            get
            {
                return m_SelectFontColor;
            }
            set
            {
                m_SelectFontColor = value;
            }
        }
        /// <summary>
        /// 选中颜色
        /// </summary>
        public Color SelectNodeBackColor
        {
            get
            {
                return m_SelectBackColor;
            }
            set
            {
                m_SelectBackColor = value;
            }
        }


        public TreeViewEx()
            : base()
        {
            this.BeforeSelect += new TreeViewCancelEventHandler(TreeViewEx_BeforeSelect);
            this.AfterSelect += new TreeViewEventHandler(TreeViewEx_AfterSelect);
            this.MouseClick += new MouseEventHandler(TreeViewEx_MouseClick);
        }

        private void TreeViewEx_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NodeMouseClickEx != null)
            {
                NodeMouseClickEx(e.Node, null);
            }

            if (AfterExpandEx != null)
            {
                AfterExpandEx(e.Node, null);
            }

            if (AfterCollapseEx != null)
            {
                AfterCollapseEx(e.Node, null);
            }
        }

        private void TreeViewEx_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TreeNode ClickNode = this.GetNodeAt(e.Location);

                if (ClickNode == null)
                {
                    return;
                }
                if (ClickNode.Equals(SelectNode))
                {
                    if (NodeMouseClickEx != null)
                    {
                        NodeMouseClickEx(ClickNode, e);
                    }
                }
                if (AfterExpandEx != null)
                {
                    AfterExpandEx(ClickNode, e);
                }

                if (AfterCollapseEx != null)
                {
                    AfterCollapseEx(ClickNode, e);
                }


            }
        }

        void TreeViewEx_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SelectNode != null)
            {
                if (e.Node.Equals(SelectedNode))
                {
                    return;
                }
            }
            if (SelectNode != null)
            {
                SelectNode.ForeColor = m_UnSelectFontColor;
                SelectNode.BackColor = m_UnSelectBackColor;
            }
            m_UnSelectFontColor = e.Node.ForeColor;
            m_UnSelectBackColor = e.Node.BackColor;
            e.Node.ForeColor = m_SelectFontColor;
            e.Node.BackColor = m_SelectBackColor;
            SelectNode = e.Node;
        }
    }
}
