namespace ReserveAnalysis
{
    partial class FrmForecastOutPut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmForecastOutPut));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExcelEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbExcelExport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUnitSwich = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFoucs = new System.Windows.Forms.ToolStripTextBox();
            this.treeHeadDataGridView1 = new BDSoft.Components.TreeHeadDataGridView();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip();
            this.tsm3Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm3Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm3Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmUnitSwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.uctStatusBar1 = new BDSoft.Components.UctStatusBar();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeHeadDataGridView1)).BeginInit();
            this.contextMenuStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCut,
            this.tsbPaste,
            this.tsbCopy,
            this.toolStripSeparator3,
            this.tsbExcelEdit,
            this.tsbExcelExport,
            this.toolStripSeparator2,
            this.tsbUnitSwich,
            this.toolStripSeparator1,
            this.tsbSave,
            this.tsbFoucs});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(574, 25);
            this.toolStrip2.TabIndex = 12;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbCut
            // 
            this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(52, 22);
            this.tsbCut.Text = "剪切";
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(52, 22);
            this.tsbPaste.Text = "粘贴";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(52, 22);
            this.tsbCopy.Text = "复制";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExcelEdit
            // 
            this.tsbExcelEdit.Image = global::ReserveAnalysis.Properties.Resources.excel;
            this.tsbExcelEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcelEdit.Name = "tsbExcelEdit";
            this.tsbExcelEdit.Size = new System.Drawing.Size(81, 22);
            this.tsbExcelEdit.Text = "Excel编辑";
            this.tsbExcelEdit.Click += new System.EventHandler(this.tsbExcelEdit_Click);
            // 
            // tsbExcelExport
            // 
            this.tsbExcelExport.Image = global::ReserveAnalysis.Properties.Resources.导入excel;
            this.tsbExcelExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcelExport.Name = "tsbExcelExport";
            this.tsbExcelExport.Size = new System.Drawing.Size(81, 22);
            this.tsbExcelExport.Text = "Excel导出";
            this.tsbExcelExport.Click += new System.EventHandler(this.tsbExcelExport_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUnitSwich
            // 
            this.tsbUnitSwich.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUnitSwich.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnitSwich.Image")));
            this.tsbUnitSwich.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUnitSwich.Name = "tsbUnitSwich";
            this.tsbUnitSwich.Size = new System.Drawing.Size(96, 22);
            this.tsbUnitSwich.Text = "切换为中式单位";
            this.tsbUnitSwich.Click += new System.EventHandler(this.tsbUnitSwich_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(52, 22);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbFoucs
            // 
            this.tsbFoucs.Name = "tsbFoucs";
            this.tsbFoucs.Size = new System.Drawing.Size(0, 25);
            // 
            // treeHeadDataGridView1
            // 
            this.treeHeadDataGridView1.AllowUserToAddRows = false;
            this.treeHeadDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.treeHeadDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.treeHeadDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.treeHeadDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.treeHeadDataGridView1.ContextMenuStrip = this.contextMenuStrip4;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.treeHeadDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.treeHeadDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeHeadDataGridView1.Location = new System.Drawing.Point(0, 25);
            this.treeHeadDataGridView1.Name = "treeHeadDataGridView1";
            this.treeHeadDataGridView1.RealHeadCellHeight = 25;
            this.treeHeadDataGridView1.RowTemplate.Height = 23;
            this.treeHeadDataGridView1.Size = new System.Drawing.Size(574, 583);
            this.treeHeadDataGridView1.TabIndex = 0;
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm3Cut,
            this.tsm3Copy,
            this.tsm3Paste,
            this.toolStripMenuItem1,
            this.tsmUnitSwitch});
            this.contextMenuStrip4.Name = "contextMenuStrip1";
            this.contextMenuStrip4.Size = new System.Drawing.Size(161, 98);
            // 
            // tsm3Cut
            // 
            this.tsm3Cut.Name = "tsm3Cut";
            this.tsm3Cut.Size = new System.Drawing.Size(160, 22);
            this.tsm3Cut.Text = "剪切";
            this.tsm3Cut.Click += new System.EventHandler(this.tsm3Cut_Click);
            // 
            // tsm3Copy
            // 
            this.tsm3Copy.Name = "tsm3Copy";
            this.tsm3Copy.Size = new System.Drawing.Size(160, 22);
            this.tsm3Copy.Text = "复制";
            this.tsm3Copy.Click += new System.EventHandler(this.tsm3Copy_Click);
            // 
            // tsm3Paste
            // 
            this.tsm3Paste.Name = "tsm3Paste";
            this.tsm3Paste.Size = new System.Drawing.Size(160, 22);
            this.tsm3Paste.Text = "粘贴";
            this.tsm3Paste.Click += new System.EventHandler(this.tsm3Paste_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 6);
            // 
            // tsmUnitSwitch
            // 
            this.tsmUnitSwitch.Name = "tsmUnitSwitch";
            this.tsmUnitSwitch.Size = new System.Drawing.Size(160, 22);
            this.tsmUnitSwitch.Text = "切换为英式单位";
            this.tsmUnitSwitch.Click += new System.EventHandler(this.tsmUnitSwitch_Click);
            // 
            // uctStatusBar1
            // 
            this.uctStatusBar1.DataGridView = this.treeHeadDataGridView1;
            this.uctStatusBar1.DecimalPlace = 5;
            this.uctStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uctStatusBar1.FixDecimalPlace = false;
            this.uctStatusBar1.IsAvg = true;
            this.uctStatusBar1.IsCounter = true;
            this.uctStatusBar1.IsRowsCount = true;
            this.uctStatusBar1.IsSelectedRowsCount = false;
            this.uctStatusBar1.IsSum = true;
            this.uctStatusBar1.Location = new System.Drawing.Point(0, 608);
            this.uctStatusBar1.Name = "uctStatusBar1";
            this.uctStatusBar1.Size = new System.Drawing.Size(574, 22);
            this.uctStatusBar1.TabIndex = 2;
            // 
            // FrmForecastOutPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 630);
            this.Controls.Add(this.treeHeadDataGridView1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.uctStatusBar1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmForecastOutPut";
            this.Text = "预测产量";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeHeadDataGridView1)).EndInit();
            this.contextMenuStrip4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDSoft.Components.TreeHeadDataGridView treeHeadDataGridView1;
        private BDSoft.Components.UctStatusBar uctStatusBar1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbCut;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbExcelEdit;
        private System.Windows.Forms.ToolStripButton tsbExcelExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripTextBox tsbFoucs;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem tsm3Cut;
        private System.Windows.Forms.ToolStripMenuItem tsm3Copy;
        private System.Windows.Forms.ToolStripMenuItem tsm3Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmUnitSwitch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbUnitSwich;
    }
}