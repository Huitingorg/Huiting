namespace ReserveAnalysis
{
    partial class FrmDecParams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDecParams));
            this.uctStatusBar1 = new BDSoft.Components.UctStatusBar();
            this.dgvDec = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startNY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endNy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sykccl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yyzqdcl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zzkccl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.油分段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.气分段ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.油分段ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.气分段ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDec)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // uctStatusBar1
            // 
            this.uctStatusBar1.DataGridView = null;
            this.uctStatusBar1.DecimalPlace = 5;
            this.uctStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uctStatusBar1.FixDecimalPlace = false;
            this.uctStatusBar1.IsAvg = false;
            this.uctStatusBar1.IsCounter = false;
            this.uctStatusBar1.IsRowsCount = false;
            this.uctStatusBar1.IsSelectedRowsCount = false;
            this.uctStatusBar1.IsSum = false;
            this.uctStatusBar1.Location = new System.Drawing.Point(0, 229);
            this.uctStatusBar1.Name = "uctStatusBar1";
            this.uctStatusBar1.Size = new System.Drawing.Size(1014, 22);
            this.uctStatusBar1.TabIndex = 12;
            // 
            // dgvDec
            // 
            this.dgvDec.AllowUserToAddRows = false;
            this.dgvDec.AllowUserToDeleteRows = false;
            this.dgvDec.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDec.BackgroundColor = System.Drawing.Color.White;
            this.dgvDec.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDec.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.unit,
            this.Column3,
            this.Column4,
            this.initDec,
            this.startNY,
            this.initOutput,
            this.endOutput,
            this.endNy,
            this.endDec,
            this.sykccl,
            this.yyzqdcl,
            this.zzkccl});
            this.dgvDec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDec.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDec.EnableHeadersVisualStyles = false;
            this.dgvDec.Location = new System.Drawing.Point(0, 25);
            this.dgvDec.Name = "dgvDec";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvDec.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDec.RowTemplate.Height = 17;
            this.dgvDec.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDec.Size = new System.Drawing.Size(1014, 204);
            this.dgvDec.TabIndex = 13;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.name.Frozen = true;
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.unit.Frozen = true;
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "拟合曲线类型";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "双曲指数";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // initDec
            // 
            this.initDec.HeaderText = "初始递减率";
            this.initDec.Name = "initDec";
            this.initDec.ReadOnly = true;
            // 
            // startNY
            // 
            this.startNY.HeaderText = "开始日期";
            this.startNY.Name = "startNY";
            this.startNY.ReadOnly = true;
            // 
            // initOutput
            // 
            this.initOutput.HeaderText = "初始产量(吨)";
            this.initOutput.Name = "initOutput";
            this.initOutput.ReadOnly = true;
            // 
            // endOutput
            // 
            this.endOutput.HeaderText = "末期产量(吨)";
            this.endOutput.Name = "endOutput";
            this.endOutput.ReadOnly = true;
            // 
            // endNy
            // 
            this.endNy.HeaderText = "终止日期";
            this.endNy.Name = "endNy";
            this.endNy.ReadOnly = true;
            // 
            // endDec
            // 
            this.endDec.HeaderText = "末期递减率";
            this.endDec.Name = "endDec";
            this.endDec.ReadOnly = true;
            this.endDec.Visible = false;
            // 
            // sykccl
            // 
            this.sykccl.HeaderText = "阶段剩余可采储量(万吨)";
            this.sykccl.Name = "sykccl";
            this.sykccl.ReadOnly = true;
            // 
            // yyzqdcl
            // 
            this.yyzqdcl.HeaderText = "预测之前的累计产油量(万吨)";
            this.yyzqdcl.Name = "yyzqdcl";
            this.yyzqdcl.ReadOnly = true;
            // 
            // zzkccl
            // 
            this.zzkccl.HeaderText = "最终可采储量(万吨)";
            this.zzkccl.Name = "zzkccl";
            this.zzkccl.ReadOnly = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton4,
            this.toolStripButton7,
            this.toolStripSeparator4,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator5,
            this.toolStripButton8,
            this.toolStripTextBox1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip2.TabIndex = 14;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton1.Text = "剪切";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "复制";
            this.toolStripButton2.Visible = false;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton3.Text = "粘贴";
            this.toolStripButton3.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::ReserveAnalysis.Properties.Resources.excel;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton4.Text = "Excel编辑";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::ReserveAnalysis.Properties.Resources.导入excel;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton7.Text = "Excel导出";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.油分段ToolStripMenuItem,
            this.气分段ToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::ReserveAnalysis.Properties.Resources.add2;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(85, 22);
            this.toolStripDropDownButton1.Text = "增加分段";
            this.toolStripDropDownButton1.ToolTipText = "只能在油分段队列末尾增加分段";
            // 
            // 油分段ToolStripMenuItem
            // 
            this.油分段ToolStripMenuItem.Name = "油分段ToolStripMenuItem";
            this.油分段ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.油分段ToolStripMenuItem.Text = "油分段";
            // 
            // 气分段ToolStripMenuItem
            // 
            this.气分段ToolStripMenuItem.Name = "气分段ToolStripMenuItem";
            this.气分段ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.气分段ToolStripMenuItem.Text = "气分段";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.油分段ToolStripMenuItem1,
            this.气分段ToolStripMenuItem1});
            this.toolStripDropDownButton2.Image = global::ReserveAnalysis.Properties.Resources.delete_12x12;
            this.toolStripDropDownButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(81, 22);
            this.toolStripDropDownButton2.Text = "删除分段";
            this.toolStripDropDownButton2.ToolTipText = "只能从最后一段倒序删除油分段";
            // 
            // 油分段ToolStripMenuItem1
            // 
            this.油分段ToolStripMenuItem1.Name = "油分段ToolStripMenuItem1";
            this.油分段ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.油分段ToolStripMenuItem1.Text = "油分段";
            // 
            // 气分段ToolStripMenuItem1
            // 
            this.气分段ToolStripMenuItem1.Name = "气分段ToolStripMenuItem1";
            this.气分段ToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.气分段ToolStripMenuItem1.Text = "气分段";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton8.Text = "保存";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(0, 25);
            // 
            // FrmDecParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 251);
            this.Controls.Add(this.dgvDec);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.uctStatusBar1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmDecParams";
            this.Text = "递减段信息";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDec)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDSoft.Components.UctStatusBar uctStatusBar1;
        private System.Windows.Forms.DataGridView dgvDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn initDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn startNY;
        private System.Windows.Forms.DataGridViewTextBoxColumn initOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn endOutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn endNy;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn sykccl;
        private System.Windows.Forms.DataGridViewTextBoxColumn yyzqdcl;
        private System.Windows.Forms.DataGridViewTextBoxColumn zzkccl;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 油分段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 气分段ToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem 油分段ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 气分段ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
    }
}