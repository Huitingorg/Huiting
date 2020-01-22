namespace ReserveCommon
{
    partial class UctTree
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctTree));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbTree = new System.Windows.Forms.ToolStripButton();
            this.tsbNodeText = new System.Windows.Forms.ToolStripButton();
            this.tsbSwitch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TextBox_Query = new System.Windows.Forms.ToolStripTextBox();
            this.tsbReturn = new System.Windows.Forms.ToolStripButton();
            this.treeListView1 = new BDSoft.Components.TreeListViewFast();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeViewFast1 = new BDSoft.Components.TreeViewFast();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "open_project.png");
            this.imageList1.Images.SetKeyName(1, "oilField.png");
            this.imageList1.Images.SetKeyName(2, "unit.png");
            this.imageList1.Images.SetKeyName(3, "plant.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDel,
            this.toolStripSeparator3,
            this.tsbTree,
            this.tsbNodeText,
            this.tsbSwitch,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.TextBox_Query,
            this.tsbReturn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(456, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::ReserveCommon.Properties.Resources.add2;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbAdd.Tag = "0";
            this.tsbAdd.Text = "新建单元";
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = global::ReserveCommon.Properties.Resources.edit;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Tag = "0";
            this.tsbEdit.Text = "节点编辑";
            // 
            // tsbDel
            // 
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDel.Image = global::ReserveCommon.Properties.Resources.删除16;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(23, 22);
            this.tsbDel.Tag = "0";
            this.tsbDel.Text = "删除单元数据";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Tag = "0";
            // 
            // tsbTree
            // 
            this.tsbTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTree.Image = global::ReserveCommon.Properties.Resources.treenode;
            this.tsbTree.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTree.Name = "tsbTree";
            this.tsbTree.Size = new System.Drawing.Size(23, 22);
            this.tsbTree.Text = "分级显示";
            this.tsbTree.Click += new System.EventHandler(this.tsbTree_Click);
            // 
            // tsbNodeText
            // 
            this.tsbNodeText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNodeText.Image = global::ReserveCommon.Properties.Resources.edit2;
            this.tsbNodeText.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbNodeText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNodeText.Name = "tsbNodeText";
            this.tsbNodeText.Size = new System.Drawing.Size(23, 22);
            this.tsbNodeText.Text = "单元名称编辑";
            this.tsbNodeText.Click += new System.EventHandler(this.tsbNodeText_Click);
            // 
            // tsbSwitch
            // 
            this.tsbSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSwitch.Image = global::ReserveCommon.Properties.Resources._switch;
            this.tsbSwitch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitch.Name = "tsbSwitch";
            this.tsbSwitch.Size = new System.Drawing.Size(23, 22);
            this.tsbSwitch.Text = "树形列表结构";
            this.tsbSwitch.Click += new System.EventHandler(this.tsbSwitch_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "单元检索:";
            // 
            // TextBox_Query
            // 
            this.TextBox_Query.Name = "TextBox_Query";
            this.TextBox_Query.Size = new System.Drawing.Size(80, 25);
            // 
            // tsbReturn
            // 
            this.tsbReturn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReturn.Image = ((System.Drawing.Image)(resources.GetObject("tsbReturn.Image")));
            this.tsbReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReturn.Name = "tsbReturn";
            this.tsbReturn.Size = new System.Drawing.Size(23, 22);
            this.tsbReturn.Text = "返回主树目录";
            this.tsbReturn.Click += new System.EventHandler(this.tsbReturn_Click);
            // 
            // treeListView1
            // 
            this.treeListView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.HideSelection = false;
            this.treeListView1.Location = new System.Drawing.Point(3, 386);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(412, 97);
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.TabIndex = 15;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单元名称";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "油气藏类型";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "开发方式";
            this.columnHeader5.Width = 100;
            // 
            // treeViewFast1
            // 
            this.treeViewFast1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFast1.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewFast1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewFast1.ImageIndex = 0;
            this.treeViewFast1.ImageList = this.imageList1;
            this.treeViewFast1.ItemHeight = 20;
            this.treeViewFast1.Location = new System.Drawing.Point(0, 28);
            this.treeViewFast1.Name = "treeViewFast1";
            this.treeViewFast1.SelectedImageIndex = 0;
            this.treeViewFast1.Size = new System.Drawing.Size(407, 337);
            this.treeViewFast1.TabIndex = 14;
            // 
            // UctTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.treeViewFast1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "UctTree";
            this.Size = new System.Drawing.Size(456, 564);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDSoft.Components.TreeViewFast treeViewFast1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox TextBox_Query;
        private System.Windows.Forms.ToolStripButton tsbReturn;
        private System.Windows.Forms.ToolStripButton tsbSwitch;
        private System.Windows.Forms.ToolStripButton tsbTree;
        private System.Windows.Forms.ToolStripButton tsbNodeText;
        private BDSoft.Components.TreeListViewFast treeListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
