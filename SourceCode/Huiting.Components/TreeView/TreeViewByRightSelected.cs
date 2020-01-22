using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Huiting.Components
{
    public class TreeViewByRightSelected : TreeView
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
                this.SelectedNode = this.GetNodeAt(e.X, e.Y);
        }

        bool checkAllChildNodes = false;

        public bool CheckAllChildNodes
        {
            get { return checkAllChildNodes; }
            set { checkAllChildNodes = value; }
        }

        #region 处理双击checkBox的问题

        //左键双击
        private const int WM_LBUTTONDBLCLK = 0x0203;
        //右键点击
        private const int WM_RBUTTONDOWN = 0x0204;
        //左键点击
        private const int WM_LBUTTONDOWN = 0x0201;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                TreeViewHitTestInfo tvhti = HitTest(new Point((int)m.LParam));
                if (tvhti != null && tvhti.Location == TreeViewHitTestLocations.StateImage)
                {
                    m.Result = IntPtr.Zero;
                    //this.SelectedNode = tvhti.Node;
                    return;
                }
            }
            else if (m.Msg == WM_RBUTTONDOWN)
            {
                TreeViewHitTestInfo tvhti = HitTest(new Point((int)m.LParam));
                if (tvhti != null)
                    this.SelectedNode = tvhti.Node;
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 设置此节点下所有子节点的状态
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="Checked"></param>
        private void SetChildNodesAllChecked(TreeNode tn, bool Checked)
        {
            foreach (TreeNode tnChild in tn.Nodes)
            {
                if (tnChild.Checked != Checked)
                    tnChild.Checked = Checked;
                SetChildNodesAllChecked(tnChild, Checked);
            }
        }

        /// <summary>
        /// 根据子节点选中情况判断父节点是否应选中，若子节点全选中，则父节点也置于选中状态
        /// </summary>
        private void SetParentCheckStatusByChild(TreeNode tn, bool Checked)
        {
            // Set parent check status
            TreeNode tnParent = tn;
            int nNodeCount = 0;
            while (tnParent.Parent != null)
            {
                tnParent = (TreeNode)(tnParent.Parent);
                nNodeCount = 0;
                foreach (TreeNode tnTemp in tnParent.Nodes)
                {
                    if (tnTemp.Checked == Checked)
                        nNodeCount++;
                }
                if (nNodeCount == tnParent.Nodes.Count)
                    tnParent.Checked = Checked;
                else
                    tnParent.Checked = false;
            }
        }

        #endregion

        protected override void OnAfterCheck(TreeViewEventArgs e)
        {
            if (checkAllChildNodes == true)
            {
                if (e.Action == TreeViewAction.ByMouse||e.Action==TreeViewAction.ByKeyboard)
                {
                    SetChildNodesAllChecked(e.Node, e.Node.Checked);
                    SetParentCheckStatusByChild(e.Node, e.Node.Checked);
                }
            }

            //e.Node.Text = e.Node.Checked.ToString();

            base.OnAfterCheck(e);
        }
    }
}