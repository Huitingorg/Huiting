namespace ReserveComponents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UctTree));
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSelect = new System.Windows.Forms.ToolStripButton();
            this.tsbGroup = new System.Windows.Forms.ToolStripButton();
            this.tsbOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSwitch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtQuery = new System.Windows.Forms.ToolStripTextBox();
            this.tsbReturn = new System.Windows.Forms.ToolStripButton();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip();
            this.tsmAddAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDelAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmSelectAssets = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssetSort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAssetCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowNext = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHideNext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmReName = new System.Windows.Forms.ToolStripMenuItem();
            this.treeListView1 = new ReserveComponents.TreeListViewEX();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeViewFast1 = new ReserveComponents.TreeViewFastEX();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.imageList1.Images.SetKeyName(4, "oil.png");
            this.imageList1.Images.SetKeyName(5, "gas.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDel,
            this.toolStripSeparator3,
            this.tsbSelect,
            this.tsbGroup,
            this.tsbOrder,
            this.toolStripSeparator4,
            this.tsbSwitch,
            this.toolStripSeparator1,
            this.tsbRefresh,
            this.tsbFilter,
            this.toolStripLabel1,
            this.txtQuery,
            this.tsbReturn,
            this.tsbSearch,
            this.tsbClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(608, 27);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = global::ReserveComponents.Properties.Resources.add2;
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(23, 24);
            this.tsbAdd.Tag = "0";
            this.tsbAdd.Text = "新建资产";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = global::ReserveComponents.Properties.Resources.edit;
            this.tsbEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 24);
            this.tsbEdit.Tag = "0";
            this.tsbEdit.Text = "节点编辑";
            this.tsbEdit.Visible = false;
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDel
            // 
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDel.Image = global::ReserveComponents.Properties.Resources.删除16;
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(23, 24);
            this.tsbDel.Tag = "0";
            this.tsbDel.Text = "删除资产";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator3.Tag = "0";
            // 
            // tsbSelect
            // 
            this.tsbSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelect.Image = global::ReserveComponents.Properties.Resources.资产导入;
            this.tsbSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelect.Name = "tsbSelect";
            this.tsbSelect.Size = new System.Drawing.Size(23, 24);
            this.tsbSelect.Text = "资产导入";
            this.tsbSelect.Click += new System.EventHandler(this.tsbSelect_Click);
            // 
            // tsbGroup
            // 
            this.tsbGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGroup.Image = global::ReserveComponents.Properties.Resources.blue_folder;
            this.tsbGroup.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbGroup.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGroup.Name = "tsbGroup";
            this.tsbGroup.Size = new System.Drawing.Size(23, 24);
            this.tsbGroup.Text = "分级显示";
            this.tsbGroup.Click += new System.EventHandler(this.tsbGroup_Click);
            // 
            // tsbOrder
            // 
            this.tsbOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOrder.Image = global::ReserveComponents.Properties.Resources.text_edit_net;
            this.tsbOrder.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbOrder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOrder.Name = "tsbOrder";
            this.tsbOrder.Size = new System.Drawing.Size(23, 24);
            this.tsbOrder.Text = "资产名称";
            this.tsbOrder.Click += new System.EventHandler(this.tsbOrder_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbSwitch
            // 
            this.tsbSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSwitch.Image = global::ReserveComponents.Properties.Resources._switch;
            this.tsbSwitch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsbSwitch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitch.Name = "tsbSwitch";
            this.tsbSwitch.Size = new System.Drawing.Size(23, 24);
            this.tsbSwitch.Text = "切换成列表模式";
            this.tsbSwitch.Click += new System.EventHandler(this.tsbSwitch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            this.toolStripSeparator1.Tag = "0";
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = global::ReserveComponents.Properties.Resources.arrow_refresh_small;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(23, 24);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbFilter
            // 
            this.tsbFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFilter.Image = global::ReserveComponents.Properties.Resources.Filter;
            this.tsbFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFilter.Name = "tsbFilter";
            this.tsbFilter.Size = new System.Drawing.Size(23, 24);
            this.tsbFilter.Text = "高级检索";
            this.tsbFilter.ToolTipText = "资产条件检索";
            this.tsbFilter.Visible = false;
            this.tsbFilter.Click += new System.EventHandler(this.tsbFilter_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabel1.Text = "检索";
            this.toolStripLabel1.ToolTipText = "资产关键字检索";
            this.toolStripLabel1.Visible = false;
            // 
            // txtQuery
            // 
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(105, 27);
            this.txtQuery.ToolTipText = "资产关键字检索";
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // tsbReturn
            // 
            this.tsbReturn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbReturn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReturn.Image = ((System.Drawing.Image)(resources.GetObject("tsbReturn.Image")));
            this.tsbReturn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReturn.Name = "tsbReturn";
            this.tsbReturn.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tsbReturn.Size = new System.Drawing.Size(23, 24);
            this.tsbReturn.Text = "返回主树目录";
            this.tsbReturn.Click += new System.EventHandler(this.tsbReturn_Click);
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(23, 24);
            this.tsbSearch.Text = "查询";
            this.tsbSearch.ToolTipText = "查询检索条件";
            this.tsbSearch.Visible = false;
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClear.Image = global::ReserveComponents.Properties.Resources.Cross;
            this.tsbClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(23, 24);
            this.tsbClear.Text = "清空检索条件";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAddAssets,
            this.tsmDelAssets,
            this.toolStripMenuItem1,
            this.tsmSelectAssets,
            this.tsmAssetSort,
            this.tsmAssetCustom,
            this.toolStripMenuItem2,
            this.tsmShowNext,
            this.tsmHideNext,
            this.toolStripMenuItem3,
            this.tsmShowAll,
            this.tsmHideAll,
            this.toolStripMenuItem4,
            this.tsmReName});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 268);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmAddAssets
            // 
            this.tsmAddAssets.Name = "tsmAddAssets";
            this.tsmAddAssets.Size = new System.Drawing.Size(168, 24);
            this.tsmAddAssets.Text = "新建资产";
            this.tsmAddAssets.Click += new System.EventHandler(this.tsmAddAssets_Click);
            // 
            // tsmDelAssets
            // 
            this.tsmDelAssets.Name = "tsmDelAssets";
            this.tsmDelAssets.Size = new System.Drawing.Size(168, 24);
            this.tsmDelAssets.Text = "删除资产";
            this.tsmDelAssets.Click += new System.EventHandler(this.tsmDelAssets_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 6);
            // 
            // tsmSelectAssets
            // 
            this.tsmSelectAssets.Name = "tsmSelectAssets";
            this.tsmSelectAssets.Size = new System.Drawing.Size(168, 24);
            this.tsmSelectAssets.Text = "资产导入";
            this.tsmSelectAssets.Click += new System.EventHandler(this.tsmSelectAssets_Click);
            // 
            // tsmAssetSort
            // 
            this.tsmAssetSort.Name = "tsmAssetSort";
            this.tsmAssetSort.Size = new System.Drawing.Size(168, 24);
            this.tsmAssetSort.Text = "资产排序";
            this.tsmAssetSort.Click += new System.EventHandler(this.tsmAssetSort_Click);
            // 
            // tsmAssetCustom
            // 
            this.tsmAssetCustom.Name = "tsmAssetCustom";
            this.tsmAssetCustom.Size = new System.Drawing.Size(168, 24);
            this.tsmAssetCustom.Text = "名称自定义";
            this.tsmAssetCustom.Click += new System.EventHandler(this.tsmAssetCustom_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 6);
            // 
            // tsmShowNext
            // 
            this.tsmShowNext.Name = "tsmShowNext";
            this.tsmShowNext.Size = new System.Drawing.Size(168, 24);
            this.tsmShowNext.Text = "展开本层节点";
            this.tsmShowNext.Click += new System.EventHandler(this.tsmShowNext_Click);
            // 
            // tsmHideNext
            // 
            this.tsmHideNext.Name = "tsmHideNext";
            this.tsmHideNext.Size = new System.Drawing.Size(168, 24);
            this.tsmHideNext.Text = "收起本层节点";
            this.tsmHideNext.Click += new System.EventHandler(this.tsmHideNext_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 6);
            // 
            // tsmShowAll
            // 
            this.tsmShowAll.Name = "tsmShowAll";
            this.tsmShowAll.Size = new System.Drawing.Size(168, 24);
            this.tsmShowAll.Text = "展开全部节点";
            this.tsmShowAll.Click += new System.EventHandler(this.tsmShowAll_Click);
            // 
            // tsmHideAll
            // 
            this.tsmHideAll.Name = "tsmHideAll";
            this.tsmHideAll.Size = new System.Drawing.Size(168, 24);
            this.tsmHideAll.Text = "收起全部节点";
            this.tsmHideAll.Click += new System.EventHandler(this.tsmHideAll_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(165, 6);
            this.toolStripMenuItem4.Visible = false;
            // 
            // tsmReName
            // 
            this.tsmReName.Name = "tsmReName";
            this.tsmReName.Size = new System.Drawing.Size(168, 24);
            this.tsmReName.Text = "重命名";
            this.tsmReName.Visible = false;
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
            this.treeListView1.Location = new System.Drawing.Point(4, 482);
            this.treeListView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.Size = new System.Drawing.Size(539, 200);
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.TabIndex = 15;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.AfterCheck += new System.Windows.Forms.TreeListViewEventHandler(this.treeListView1_AfterCheck);
            this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单元名称";
            this.columnHeader1.Width = 264;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "油气藏类型";
            this.columnHeader3.Width = 132;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "开发方式";
            this.columnHeader5.Width = 132;
            // 
            // treeViewFast1
            // 
            this.treeViewFast1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewFast1.BackColor = System.Drawing.SystemColors.Window;
            this.treeViewFast1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewFast1.CheckAllChildNodes = false;
            this.treeViewFast1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewFast1.FullRowSelect = true;
            this.treeViewFast1.HideSelection = false;
            this.treeViewFast1.ImageIndex = 0;
            this.treeViewFast1.ImageList = this.imageList1;
            this.treeViewFast1.ItemHeight = 20;
            this.treeViewFast1.Location = new System.Drawing.Point(0, 35);
            this.treeViewFast1.Margin = new System.Windows.Forms.Padding(4);
            this.treeViewFast1.Name = "treeViewFast1";
            this.treeViewFast1.SelectedImageIndex = 0;
            this.treeViewFast1.Size = new System.Drawing.Size(543, 421);
            this.treeViewFast1.TabIndex = 14;
            this.treeViewFast1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFast1_AfterCheck);
            this.treeViewFast1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFast1_AfterSelect);
            this.treeViewFast1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewFast1_MouseUp);
            // 
            // UctTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListView1);
            this.Controls.Add(this.treeViewFast1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UctTree";
            this.Size = new System.Drawing.Size(608, 705);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private ReserveComponents.TreeViewFastEX treeViewFast1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox txtQuery;
        private System.Windows.Forms.ToolStripButton tsbReturn;
        private System.Windows.Forms.ToolStripButton tsbSwitch;
        private System.Windows.Forms.ToolStripButton tsbGroup;
        private System.Windows.Forms.ToolStripButton tsbOrder;
        private ReserveComponents.TreeListViewEX treeListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbFilter;
        private System.Windows.Forms.ToolStripButton tsbSelect;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmAddAssets;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectAssets;
        private System.Windows.Forms.ToolStripMenuItem tsmAssetCustom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmShowNext;
        private System.Windows.Forms.ToolStripMenuItem tsmHideNext;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmShowAll;
        private System.Windows.Forms.ToolStripMenuItem tsmHideAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmReName;
        private System.Windows.Forms.ToolStripMenuItem tsmAssetSort;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripMenuItem tsmDelAssets;
    }
}
