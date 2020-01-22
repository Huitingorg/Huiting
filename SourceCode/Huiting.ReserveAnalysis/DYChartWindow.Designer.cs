namespace ReserveAnalysis
{
    partial class DYChartWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uctStatusBar2 = new BDSoft.Components.UctStatusBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.uctChart1 = new ReserveChartExpand.UctChart();
            this.collapsibleSplitter2 = new BDSoft.Components.CollapsibleSplitter();
            this.uctDecStatus1 = new ReserveChartExpand.UctDecStatus();
            this.collapsibleSplitter1 = new BDSoft.Components.CollapsibleSplitter();
            this.clumPjnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csrq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prelineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fieldID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 499);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1176, 238);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uctStatusBar2);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1168, 212);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 预测递减参数 ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uctStatusBar2
            // 
            this.uctStatusBar2.DataGridView = this.dataGridView1;
            this.uctStatusBar2.DecimalPlace = 5;
            this.uctStatusBar2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uctStatusBar2.FixDecimalPlace = false;
            this.uctStatusBar2.IsAvg = true;
            this.uctStatusBar2.IsCounter = true;
            this.uctStatusBar2.IsRowsCount = true;
            this.uctStatusBar2.IsSelectedRowsCount = false;
            this.uctStatusBar2.IsSum = true;
            this.uctStatusBar2.Location = new System.Drawing.Point(3, 187);
            this.uctStatusBar2.Name = "uctStatusBar2";
            this.uctStatusBar2.Size = new System.Drawing.Size(1162, 22);
            this.uctStatusBar2.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clumPjnd,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.csrq,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.prelineID,
            this.fieldID});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 17;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.Size = new System.Drawing.Size(1162, 206);
            this.dataGridView1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.uctChart1);
            this.panel1.Controls.Add(this.collapsibleSplitter2);
            this.panel1.Controls.Add(this.uctDecStatus1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1176, 491);
            this.panel1.TabIndex = 19;
            // 
            // uctChart1
            // 
            this.uctChart1.BDTemplateFile = null;
            this.uctChart1.ChartTemplateFile = null;
            this.uctChart1.decParams = null;
            this.uctChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uctChart1.Location = new System.Drawing.Point(0, 0);
            this.uctChart1.Name = "uctChart1";
            this.uctChart1.SeriesOptionsFile = null;
            this.uctChart1.Size = new System.Drawing.Size(918, 491);
            this.uctChart1.TabIndex = 0;
            this.uctChart1.ToolBarVisible = false;
            // 
            // collapsibleSplitter2
            // 
            this.collapsibleSplitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.collapsibleSplitter2.CollapseState = true;
            this.collapsibleSplitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.collapsibleSplitter2.IsCollapse = true;
            this.collapsibleSplitter2.Location = new System.Drawing.Point(918, 0);
            this.collapsibleSplitter2.Name = "collapsibleSplitter2";
            this.collapsibleSplitter2.Size = new System.Drawing.Size(8, 491);
            this.collapsibleSplitter2.TabIndex = 4;
            this.collapsibleSplitter2.TabStop = false;
            // 
            // uctDecStatus1
            // 
            this.uctDecStatus1.Dock = System.Windows.Forms.DockStyle.Right;
            this.uctDecStatus1.Location = new System.Drawing.Point(926, 0);
            this.uctDecStatus1.MinimumSize = new System.Drawing.Size(250, 0);
            this.uctDecStatus1.Name = "uctDecStatus1";
            this.uctDecStatus1.Padding = new System.Windows.Forms.Padding(3);
            this.uctDecStatus1.Size = new System.Drawing.Size(250, 491);
            this.uctDecStatus1.TabIndex = 5;
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.collapsibleSplitter1.CollapseState = true;
            this.collapsibleSplitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.collapsibleSplitter1.IsCollapse = true;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(0, 491);
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(1176, 8);
            this.collapsibleSplitter1.TabIndex = 3;
            this.collapsibleSplitter1.TabStop = false;
            // 
            // clumPjnd
            // 
            this.clumPjnd.DataPropertyName = "pjnd";
            this.clumPjnd.HeaderText = "评价年月";
            this.clumPjnd.Name = "clumPjnd";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "FieldText";
            this.dataGridViewTextBoxColumn1.HeaderText = "名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Fieldunit";
            this.dataGridViewTextBoxColumn2.HeaderText = "单位";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nhxlx";
            this.dataGridViewTextBoxColumn3.HeaderText = "拟合曲线类型";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "sqzs";
            this.dataGridViewTextBoxColumn4.HeaderText = "双曲指数";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cscl";
            this.dataGridViewTextBoxColumn7.HeaderText = "初始产量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // csrq
            // 
            this.csrq.DataPropertyName = "csrq";
            this.csrq.HeaderText = "开始日期";
            this.csrq.Name = "csrq";
            this.csrq.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "csdjl";
            this.dataGridViewTextBoxColumn5.HeaderText = "初始递减率";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "mqcl";
            this.dataGridViewTextBoxColumn8.HeaderText = "末期产量";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "mqrq";
            this.dataGridViewTextBoxColumn9.HeaderText = "结束日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "jdsykccl";
            this.dataGridViewTextBoxColumn11.HeaderText = "阶段剩余可采储量";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "yczqljcl";
            this.dataGridViewTextBoxColumn12.HeaderText = "预测之前累计产量";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "zzkccl";
            this.dataGridViewTextBoxColumn13.HeaderText = "最终可采储量";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // prelineID
            // 
            this.prelineID.DataPropertyName = "preLineID";
            this.prelineID.HeaderText = "预测线ID";
            this.prelineID.Name = "prelineID";
            this.prelineID.Visible = false;
            // 
            // fieldID
            // 
            this.fieldID.DataPropertyName = "FieldName";
            this.fieldID.HeaderText = "字段Name";
            this.fieldID.Name = "fieldID";
            this.fieldID.Visible = false;
            // 
            // DYChartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 737);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DYChartWindow";
            this.Text = "单元递减分析";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BDSoft.Components.CollapsibleSplitter collapsibleSplitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BDSoft.Components.UctStatusBar uctStatusBar2;
        private System.Windows.Forms.Panel panel1;
        public ReserveChartExpand.UctChart uctChart1;
        private BDSoft.Components.CollapsibleSplitter collapsibleSplitter2;
        private ReserveChartExpand.UctDecStatus uctDecStatus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clumPjnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn csrq;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn prelineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fieldID;

    }
}