﻿namespace Huiting.DataEditor.Controls
{
    partial class UC_ExcelFileSel
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ExcelFileSel));
            this.label1 = new System.Windows.Forms.Label();
            this.text_UserSelPath = new System.Windows.Forms.TextBox();
            this.btn_SelFile = new System.Windows.Forms.Button();
            this.group_DataType = new System.Windows.Forms.GroupBox();
            this.radio_WellDevelopData = new System.Windows.Forms.RadioButton();
            this.radio_UnitDevolopData = new System.Windows.Forms.RadioButton();
            this.radio_UnitBase = new System.Windows.Forms.RadioButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_FieldConfig = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_GetTempleate = new System.Windows.Forms.Button();
            this.tab_ExcelPreView = new Huiting.Components.RoundedTabControl();
            this.tabPage_Sheet1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.group_DataType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab_ExcelPreView.SuspendLayout();
            this.tabPage_Sheet1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择Excel文件：";
            // 
            // text_UserSelPath
            // 
            this.text_UserSelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.text_UserSelPath.Location = new System.Drawing.Point(158, 3);
            this.text_UserSelPath.Name = "text_UserSelPath";
            this.text_UserSelPath.ReadOnly = true;
            this.text_UserSelPath.Size = new System.Drawing.Size(681, 25);
            this.text_UserSelPath.TabIndex = 1;
            // 
            // btn_SelFile
            // 
            this.btn_SelFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelFile.Location = new System.Drawing.Point(845, 3);
            this.btn_SelFile.Name = "btn_SelFile";
            this.btn_SelFile.Size = new System.Drawing.Size(103, 25);
            this.btn_SelFile.TabIndex = 2;
            this.btn_SelFile.Text = "选择文件";
            this.btn_SelFile.UseVisualStyleBackColor = true;
            this.btn_SelFile.Click += new System.EventHandler(this.btn_SelFile_Click);
            // 
            // group_DataType
            // 
            this.group_DataType.BackColor = System.Drawing.Color.Transparent;
            this.group_DataType.Controls.Add(this.radio_WellDevelopData);
            this.group_DataType.Controls.Add(this.radio_UnitDevolopData);
            this.group_DataType.Controls.Add(this.radio_UnitBase);
            this.group_DataType.Enabled = false;
            this.group_DataType.Location = new System.Drawing.Point(3, 36);
            this.group_DataType.Name = "group_DataType";
            this.group_DataType.Size = new System.Drawing.Size(139, 232);
            this.group_DataType.TabIndex = 4;
            this.group_DataType.TabStop = false;
            this.group_DataType.Text = " 导入类型选择 ";
            // 
            // radio_WellDevelopData
            // 
            this.radio_WellDevelopData.AutoSize = true;
            this.radio_WellDevelopData.Location = new System.Drawing.Point(12, 98);
            this.radio_WellDevelopData.Name = "radio_WellDevelopData";
            this.radio_WellDevelopData.Size = new System.Drawing.Size(118, 19);
            this.radio_WellDevelopData.TabIndex = 6;
            this.radio_WellDevelopData.Text = "单井开发数据";
            this.radio_WellDevelopData.UseVisualStyleBackColor = true;
            // 
            // radio_UnitDevolopData
            // 
            this.radio_UnitDevolopData.AutoSize = true;
            this.radio_UnitDevolopData.Location = new System.Drawing.Point(12, 64);
            this.radio_UnitDevolopData.Name = "radio_UnitDevolopData";
            this.radio_UnitDevolopData.Size = new System.Drawing.Size(118, 19);
            this.radio_UnitDevolopData.TabIndex = 7;
            this.radio_UnitDevolopData.Text = "单元开发数据";
            this.radio_UnitDevolopData.UseVisualStyleBackColor = true;
            // 
            // radio_UnitBase
            // 
            this.radio_UnitBase.AutoSize = true;
            this.radio_UnitBase.Checked = true;
            this.radio_UnitBase.Location = new System.Drawing.Point(12, 30);
            this.radio_UnitBase.Name = "radio_UnitBase";
            this.radio_UnitBase.Size = new System.Drawing.Size(118, 19);
            this.radio_UnitBase.TabIndex = 8;
            this.radio_UnitBase.TabStop = true;
            this.radio_UnitBase.Text = "单元资产数据";
            this.radio_UnitBase.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Gear_16px_1134479_easyicon.net.png");
            this.imageList1.Images.SetKeyName(1, "编辑.bmp");
            // 
            // btn_FieldConfig
            // 
            this.btn_FieldConfig.Enabled = false;
            this.btn_FieldConfig.FlatAppearance.BorderSize = 0;
            this.btn_FieldConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FieldConfig.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_FieldConfig.ImageIndex = 0;
            this.btn_FieldConfig.ImageList = this.imageList1;
            this.btn_FieldConfig.Location = new System.Drawing.Point(6, 34);
            this.btn_FieldConfig.Name = "btn_FieldConfig";
            this.btn_FieldConfig.Size = new System.Drawing.Size(108, 23);
            this.btn_FieldConfig.TabIndex = 6;
            this.btn_FieldConfig.Text = "字段映射配置";
            this.btn_FieldConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_FieldConfig.UseVisualStyleBackColor = true;
            this.btn_FieldConfig.Click += new System.EventHandler(this.btn_FieldConfig_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btn_GetTempleate);
            this.groupBox2.Controls.Add(this.btn_FieldConfig);
            this.groupBox2.Location = new System.Drawing.Point(3, 274);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 203);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "辅助功能";
            // 
            // btn_GetTempleate
            // 
            this.btn_GetTempleate.FlatAppearance.BorderSize = 0;
            this.btn_GetTempleate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GetTempleate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_GetTempleate.ImageIndex = 1;
            this.btn_GetTempleate.ImageList = this.imageList1;
            this.btn_GetTempleate.Location = new System.Drawing.Point(6, 63);
            this.btn_GetTempleate.Name = "btn_GetTempleate";
            this.btn_GetTempleate.Size = new System.Drawing.Size(108, 23);
            this.btn_GetTempleate.TabIndex = 6;
            this.btn_GetTempleate.Text = "获取业务模板";
            this.btn_GetTempleate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_GetTempleate.UseVisualStyleBackColor = true;
            this.btn_GetTempleate.Click += new System.EventHandler(this.btn_GetTempleate_Click);
            // 
            // tab_ExcelPreView
            // 
            this.tab_ExcelPreView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_ExcelPreView.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tab_ExcelPreView.BackColor = System.Drawing.Color.Transparent;
            this.tab_ExcelPreView.BaseColor = System.Drawing.Color.White;
            this.tab_ExcelPreView.BorderColor = System.Drawing.Color.Silver;
            this.tab_ExcelPreView.Controls.Add(this.tabPage_Sheet1);
            this.tab_ExcelPreView.Location = new System.Drawing.Point(158, 36);
            this.tab_ExcelPreView.Name = "tab_ExcelPreView";
            this.tab_ExcelPreView.SelectedIndex = 0;
            this.tab_ExcelPreView.Size = new System.Drawing.Size(790, 440);
            this.tab_ExcelPreView.TabIndex = 8;
            // 
            // tabPage_Sheet1
            // 
            this.tabPage_Sheet1.Controls.Add(this.dataGridView1);
            this.tabPage_Sheet1.Location = new System.Drawing.Point(4, 30);
            this.tabPage_Sheet1.Name = "tabPage_Sheet1";
            this.tabPage_Sheet1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Sheet1.Size = new System.Drawing.Size(782, 406);
            this.tabPage_Sheet1.TabIndex = 0;
            this.tabPage_Sheet1.Text = "数据";
            this.tabPage_Sheet1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(776, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.text_UserSelPath);
            this.pnlTop.Controls.Add(this.btn_SelFile);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(955, 36);
            this.pnlTop.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(955, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgressBar1
            // 
            this.tsProgressBar1.Name = "tsProgressBar1";
            this.tsProgressBar1.Size = new System.Drawing.Size(200, 18);
            this.tsProgressBar1.Visible = false;
            // 
            // UC_ExcelFileSel
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tab_ExcelPreView);
            this.Controls.Add(this.group_DataType);
            this.Controls.Add(this.pnlTop);
            this.Name = "UC_ExcelFileSel";
            this.Size = new System.Drawing.Size(955, 501);
            this.Load += new System.EventHandler(this.UC_ExcelFileSel_Load);
            this.group_DataType.ResumeLayout(false);
            this.group_DataType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tab_ExcelPreView.ResumeLayout(false);
            this.tabPage_Sheet1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_UserSelPath;
        private System.Windows.Forms.Button btn_SelFile;
        private System.Windows.Forms.GroupBox group_DataType;
        private System.Windows.Forms.RadioButton radio_WellDevelopData;
        private System.Windows.Forms.RadioButton radio_UnitDevolopData;
        private System.Windows.Forms.RadioButton radio_UnitBase;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_FieldConfig;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_GetTempleate;
        private Huiting.Components.RoundedTabControl tab_ExcelPreView;
        private System.Windows.Forms.TabPage tabPage_Sheet1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar1;
    }
}
