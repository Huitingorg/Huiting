using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huiting.Components;
using System.Drawing;
using System.Windows.Forms;
using ReserveCommon;
using Huiting.Common;
using Huiting.Components;

namespace ReserveAnalysis
{
    public class UnitFreeLayoutPanel : FreeLayoutPanel<IconItemPanel>
    {
        List<IconItemPanel> lstChildControl;
        public event EventHandler ItemDoubleClick;
        public event EventHandler ItemClick;
        ContextMenuStrip contextMenuStrip1;
        ToolStripMenuItem tsmDelete;
        ToolStripMenuItem tsmAdd;
        ToolStripMenuItem tsmEdit;

        public UnitFreeLayoutPanel()
        {
            lstChildControl = new List<IconItemPanel>();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.tsmAdd = new ToolStripMenuItem();
            this.tsmEdit = new ToolStripMenuItem();
            this.tsmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAdd,this.tsmEdit,this.tsmDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // tsmAdd
            // 
            this.tsmAdd.Name = "tsmAdd";
            this.tsmAdd.Size = new System.Drawing.Size(152, 22);
            this.tsmAdd.Text = "添加";
            this.tsmAdd.Click += tsmAdd_Click;
            this.contextMenuStrip1.ResumeLayout(false);
            // 
            // tsmEdit
            // 
            this.tsmEdit.Name = "tsmEdit";
            this.tsmEdit.Size = new System.Drawing.Size(152, 22);
            this.tsmEdit.Text = "编辑";
            this.tsmEdit.Click += tsmEdit_Click;
            this.contextMenuStrip1.ResumeLayout(false);
            // 
            // tsmDelete
            // 
            this.tsmDelete.Name = "tsmDelete";
            this.tsmDelete.Size = new System.Drawing.Size(152, 22);
            this.tsmDelete.Text = "删除";
            this.tsmDelete.Click += tsmDelete_Click;
            this.contextMenuStrip1.ResumeLayout(false);
        }

        public event EventHandler AddProjectItem;
        void tsmAdd_Click(object sender, EventArgs e)
        {
            if (AddProjectItem != null)
                AddProjectItem(sender, e);
        }

        public event EventHandler EditProjectItem;
        void tsmEdit_Click(object sender, EventArgs e)
        {
            IconItemPanel iconItem = contextMenuStrip1.SourceControl as IconItemPanel;
            if (iconItem == null)
                return;

            if (EditProjectItem != null)
                EditProjectItem(iconItem.DataConverter, null);
        }

        public event EventHandler DeleteProjectItem;
        void tsmDelete_Click(object sender, EventArgs e)
        {
            IconItemPanel iconItem = contextMenuStrip1.SourceControl as IconItemPanel;
            if (iconItem == null)
                return;

            if (DeleteProjectItem != null)
            {
                DeleteProjectItem(iconItem.DataConverter.ID, null);
                this.ChildContrls.Remove(iconItem);
                this.Controls.Remove(iconItem);
                base.RefreshContols();
            }
        }

        public void InitInterface(IEnumerable<IEntityData> lstData, IconLayoutType IconLayoutType = IconLayoutType.LeftWordRightImage, bool LoadContextMenuStrip = false)
        {
            this.DisposeChildControls();
            this.MinChildControlSize = GetIconItemSize(IconLayoutType);
            foreach (IEntityData item in lstData)
            {
                IconItemPanel iip = AddChildControl(item, IconLayoutType, MinChildControlSize);
                if (LoadContextMenuStrip)
                    iip.ContextMenuStrip = this.contextMenuStrip1;
                else
                    iip.ContextMenuStrip = null;
                lstChildControl.Add(iip);
            }

            base.Init(lstChildControl);
        }

        private Size GetIconItemSize(IconLayoutType IconLayoutType)
        {
            Size sz = new Size(100,100);
            switch (IconLayoutType)
            {
                case IconLayoutType.LeftWordRightImage:
                case IconLayoutType.LeftImageRightWord:
                    sz = new Size(180, 96);
                    break;
                case IconLayoutType.TopWordBottomImage:
                case IconLayoutType.TopImageBottomWord:
                    sz = new Size(100, 128);
                    break;
                default:
                    break;
            }

            return sz;
        }

        private IconItemPanel AddChildControl(IEntityData dataConverter, IconLayoutType IconLayoutType, Size sz)
        {
            IconItemPanel iip = new IconItemPanel();
            iip.Init(dataConverter, IconLayoutType, sz);
            iip.DoubleClick -= iip_DoubleClick;
            iip.DoubleClick += iip_DoubleClick;

            iip.MouseUp -= iip_MouseUp;
            iip.MouseUp += iip_MouseUp;

            this.Controls.Add(iip);

            return iip;
        }

        void iip_MouseUp(object sender, MouseEventArgs e)
        {
            IconItemPanel fmp = sender as IconItemPanel;
            if (fmp == null)
                return;
            if (e.Button== System.Windows.Forms.MouseButtons.Left&& ItemClick != null)
                ItemClick(fmp.DataConverter, e);
        }

        public void RestoreAll()
        {
            foreach (IconItemPanel item in lstChildControl)
            {
                item.Restore();
            }
        }

        private void RestoreExceptOne(object sender)
        {
            foreach (IconItemPanel item in lstChildControl)
            {
                if (item == sender)
                    continue;
                item.Restore();
            }
        }

        void iip_DoubleClick(object sender, EventArgs e)
        {
            IconItemPanel fmp = sender as IconItemPanel;
            if (fmp == null)
                return;

            RestoreExceptOne(sender);
            if (ItemDoubleClick != null)
                ItemDoubleClick(fmp.DataConverter, e);
        }

        public void DisposeChildControls()
        {
            this.Controls.Clear();
            this.lstChildControl.Clear();

            foreach (IconItemPanel item in lstChildControl)
                item.Dispose();
        }

        int lastRightPanelVerticalScrollValue = -1;//为鼠标滚动事件提供一个静态变量，用来存储上次滚动后的VerticalScroll.Value
        protected override void OnMouseWheel(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.AutoScroll == false)
            {
                base.OnMouseWheel(e);
                return;
            }

            //如果没有滚动条
            if (this.VerticalScroll.Visible == false)
                return;

            //如果滚动条超上下限
            if((this.VerticalScroll.Value == 0 && e.Delta > 0) ||
                (this.VerticalScroll.Value == lastRightPanelVerticalScrollValue && e.Delta < 0))
                return;

            this.VerticalScroll.Value += 10;
            lastRightPanelVerticalScrollValue = this.VerticalScroll.Value;

            base.OnMouseWheel(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Focus();
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.Focus();
        }


    }

    public class EventArgsForDrawing : EventArgs
    {
        object sender = null;

        public object Sender
        {
            get { return sender; }
            set { sender = value; }
        }
    }
}
